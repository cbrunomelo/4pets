using Domain.Commands.CategoryCommands;
using Domain.Entitys;
using Domain.Handlers;
using Domain.Repository;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Domain.Handlers
{    
    public class CategoryHandlerTest
    {

        [Fact]
        public void CreateCategory_WithValidData_ShouldCreateCategory()
        {
            // Arrange
            CreateCategoryCommand command = new CreateCategoryCommand("Category 1", "Description 1");
            var mockCategoryRepository = new Mock<ICategoryRepository>();
            mockCategoryRepository.Setup(x => x.CategoryExists(command.Name)).Returns(false);
            mockCategoryRepository.Setup(x => x.CreateCategory(It.IsAny<Category>())).Returns(1);
            CategoryHandler handler = new CategoryHandler(mockCategoryRepository.Object);

            // Act
            var result = handler.Handle(command);
            

            // Assert
            Assert.True(result.Sucess);
            
        }
        
        
    }
}
