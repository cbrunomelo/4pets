﻿using Domain.Commands.CategoryCommands;
using Domain.Commands.HistoryCommands;
using Domain.Entitys;
using Domain.Handlers;
using Domain.Handlers.Contracts;
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
    public class CategoryHandlerTest
    {
        private readonly Mock<ICategoryRepository> mockCategoryRepository = new Mock<ICategoryRepository>();
        private readonly Mock<IMediator> _mediator;

        public CategoryHandlerTest()
        {
            mockCategoryRepository.Setup(x => x.CreateCategory(It.IsAny<Category>())).Returns(1);
            mockCategoryRepository.Setup(x => x.CategoryExists(It.IsAny<string>())).Returns(false);
            _mediator = new Mock<IMediator>();
        }

        [Theory]
        [MemberData(nameof(ValidCategoryData.GetData), MemberType = typeof(ValidCategoryData))]
        public async void CreateCategory_WithValidData_ShouldCreateCategory(CreateCategoryCommand command)
        {
            // Arrange

            CategoryHandler handler = new CategoryHandler(mockCategoryRepository.Object, _mediator.Object);

            // Act
            var ctn = new CancellationToken();
            var result = await handler.Handle(command, ctn);

            // Assert
            Assert.True(result.Sucess);
            Assert.All(result.Errors, x => string.IsNullOrEmpty(x));
        }

        [Theory]
        [MemberData(nameof(InvalidCategoryData.GetData), MemberType = typeof(InvalidCategoryData))]
        public async void CreateCategory_WithInvalidData_ShouldNotCreateCategory(CreateCategoryCommand command)
        {
            // Arrange

            CategoryHandler handler = new CategoryHandler(mockCategoryRepository.Object, _mediator.Object);

            // Act
            var ctn = new CancellationToken();
            var result = await handler.Handle(command, ctn);

            // Assert
            Assert.False(result.Sucess);
            Assert.NotEmpty(result.Message);
            Assert.NotEmpty(result.Errors);
            mockCategoryRepository.Verify(x => x.CreateCategory(It.IsAny<Category>()), Times.Never);
            mockCategoryRepository.Verify(x => x.CategoryExists(It.IsAny<string>()), Times.Never);
        }

        [Theory]
        [MemberData(nameof(ValidCategoryData.GetData), MemberType = typeof(ValidCategoryData))]
        public async void CreateCategory_alreadyExists_ShouldNotCreateCategory(CreateCategoryCommand command)
        {
            // Arrange
            mockCategoryRepository.Setup(x => x.CategoryExists(It.IsAny<string>())).Returns(true);

            CategoryHandler handler = new CategoryHandler(mockCategoryRepository.Object, _mediator.Object);

            // Act
            var ctn = new CancellationToken();
            var result = await handler.Handle(command, ctn);

            // Assert
            Assert.False(result.Sucess);
            Assert.NotEmpty(result.Message);
            Assert.NotEmpty(result.Errors);
            mockCategoryRepository.Verify(x => x.CreateCategory(It.IsAny<Category>()), Times.Never);
        }

        [Theory]
        [MemberData(nameof(ValidCategoryData.GetData), MemberType = typeof(ValidCategoryData))]
        public async void CreateCategory_InternalError_ShouldNotCreateCategory(CreateCategoryCommand command)
        {
            // Arrange
            mockCategoryRepository.Setup(x => x.CreateCategory(It.IsAny<Category>())).Returns(0);

            CategoryHandler handler = new CategoryHandler(mockCategoryRepository.Object, _mediator.Object);

            // Act
            var ctn = new CancellationToken();
            var result = await handler.Handle(command, ctn);

            // Assert
            Assert.False(result.Sucess);
            Assert.NotEmpty(result.Message);
            Assert.NotEmpty(result.Errors);
        }

    }
}
