using Domain.Commands;
using Domain.Commands.HistoryCommands;
using Domain.Entitys;
using Domain.Handlers;
using Domain.Handlers.Contracts;
using Domain.Queries.CategoryQuerys;
using Domain.Repository;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Domain.Handlers.Data;

namespace Test.Domain.Handlers
{
    public class ProductHandlerTest
    {
        private Mock<IProductRepository> _productRepository;
        private readonly Mock<IMediator> _mediator;
        public ProductHandlerTest() 
        {
            _productRepository = new Mock<IProductRepository>();
            _productRepository.Setup(x => x.Create(It.IsAny<Product>())).Returns(1);
            _mediator = new Mock<IMediator>();
            _mediator.Setup(x => x.Send(It.IsAny<VerifyCategoryExist>(), It.IsAny<CancellationToken>())).ReturnsAsync(true);

        }

        [Theory]
        [MemberData(nameof(ValidProductData.GetData), MemberType = typeof(ValidProductData))]
        public async void CreateProductCommand_WithValidData_ShouldPass(CreateProductCommand command)
        {
            // Arrange
            var handler = new ProductHandler(_productRepository.Object, _mediator.Object);

            // Act
            var ctn = new CancellationToken();
            var result =await handler.Handle(command, ctn);

            // Assert
            Assert.True(result.Sucess);
            Assert.True(result.Data is Product);
            
        }

        [Theory]
        [MemberData(nameof(InvalidProductData.GetData), MemberType = typeof(InvalidProductData))]
        public async void CreateProductCommand_WithInvalidData_ShouldFail(CreateProductCommand command)
        {
            // Arrange
            var handler = new ProductHandler(_productRepository.Object, _mediator.Object);

            // Act
            var ctn = new CancellationToken();
            var result =await handler.Handle(command, ctn);

            // Assert
            Assert.False(result.Sucess);
            Assert.True(result.Errors.Count > 0);
            _productRepository.Verify(x => x.Create(It.IsAny<Product>()), Times.Never);
        }

        [Theory]
        [MemberData(nameof(ValidProductData.GetData), MemberType = typeof(ValidProductData))]
        public async void CreateProductCommand_alreadyExist_ShouldFail(CreateProductCommand command)
        {
            // Arrange
            _productRepository.Setup(x => x.VerifyProductExist(It.IsAny<string>())).Returns(true);
            var handler = new ProductHandler(_productRepository.Object, _mediator.Object);

            // Act
            var ctn = new CancellationToken();
            var result = await handler.Handle(command, ctn);

            // Assert
            Assert.False(result.Sucess);
            Assert.True(result.Errors.Count > 0);
            _productRepository.Verify(x => x.Create(It.IsAny<Product>()), Times.Never);
        }

        [Theory]
        [MemberData(nameof(ValidProductData.GetData), MemberType = typeof(ValidProductData))]
        public async void CreateProductCommand_WithRepositoryError_ShouldFail(CreateProductCommand command)
        {
            // Arrange
            _productRepository.Setup(x => x.Create(It.IsAny<Product>())).Returns(0);
            var handler = new ProductHandler(_productRepository.Object, _mediator.Object);

            // Act
            var ctn = new CancellationToken();
            var result = await handler.Handle(command, ctn);

            // Assert
            Assert.False(result.Sucess);
            Assert.True(result.Errors.Count > 0);
            _productRepository.Verify(x => x.Create(It.IsAny<Product>()), Times.Never);
        }

    }
}
