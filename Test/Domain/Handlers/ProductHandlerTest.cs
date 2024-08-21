using Domain.Commands;
using Domain.Commands.HistoryCommands;
using Domain.Entitys;
using Domain.Handlers;
using Domain.Handlers.Contracts;
using Domain.Repository;
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
        private readonly Mock<IHandler<CreateHistoryCommand>> _historyHandleMock;
        public ProductHandlerTest() 
        {
            _productRepository = new Mock<IProductRepository>();
            _productRepository.Setup(x => x.Create(It.IsAny<Product>())).Returns(1);
            _historyHandleMock = new Mock<IHandler<CreateHistoryCommand>>();

        }

        [Theory]
        [MemberData(nameof(ValidProductData.GetData), MemberType = typeof(ValidProductData))]
        public void CreateProductCommand_WithValidData_ShouldPass(CreateProductCommands command)
        {
            // Arrange
            var handler = new ProductHandler(_productRepository.Object, _historyHandleMock.Object);

            // Act
            var result = handler.Handle(command);

            // Assert
            Assert.True(result.Sucess);
            Assert.True(result.Data is Product);
            
        }

        [Theory]
        [MemberData(nameof(InvalidProductData.GetData), MemberType = typeof(InvalidProductData))]
        public void CreateProductCommand_WithInvalidData_ShouldFail(CreateProductCommands command)
        {
            // Arrange
            var handler = new ProductHandler(_productRepository.Object, _historyHandleMock.Object);

            // Act
            var result = handler.Handle(command);

            // Assert
            Assert.False(result.Sucess);
            Assert.True(result.Errors.Count > 0);
            _productRepository.Verify(x => x.Create(It.IsAny<Product>()), Times.Never);
        }

        [Theory]
        [MemberData(nameof(ValidProductData.GetData), MemberType = typeof(ValidProductData))]
        public void CreateProductCommand_alreadyExist_ShouldFail(CreateProductCommands command)
        {
            // Arrange
            _productRepository.Setup(x => x.VerifyProductExist(It.IsAny<string>())).Returns(true);
            var handler = new ProductHandler(_productRepository.Object, _historyHandleMock.Object);

            // Act
            var result = handler.Handle(command);

            // Assert
            Assert.False(result.Sucess);
            Assert.True(result.Errors.Count > 0);
            _productRepository.Verify(x => x.Create(It.IsAny<Product>()), Times.Never);
        }

        [Theory]
        [MemberData(nameof(ValidProductData.GetData), MemberType = typeof(ValidProductData))]
        public void CreateProductCommand_WithRepositoryError_ShouldFail(CreateProductCommands command)
        {
            // Arrange
            _productRepository.Setup(x => x.Create(It.IsAny<Product>())).Returns(0);
            var handler = new ProductHandler(_productRepository.Object, _historyHandleMock.Object);

            // Act
            var result = handler.Handle(command);

            // Assert
            Assert.False(result.Sucess);
            Assert.True(result.Errors.Count > 0);
            _productRepository.Verify(x => x.Create(It.IsAny<Product>()), Times.Once);
        }

    }
}
