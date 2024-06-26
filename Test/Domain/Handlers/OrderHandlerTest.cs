﻿using Domain.Commands.OrderCommands;
using Domain.Entitys;
using Domain.Handlers;
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
    public class OrderHandlerTest
    {
        private readonly Mock<IOrderRepository> _OrderRepositoryMock;
        private readonly Mock<IProductRepository> _ProductRepositoryMock;
        public OrderHandlerTest() 
        {
            _OrderRepositoryMock = new Mock<IOrderRepository>();
            _ProductRepositoryMock = new Mock<IProductRepository>();
        }


        [Theory]
        [MemberData(nameof(ValidOrderData.GetData), MemberType = typeof(ValidOrderData))]
        public void CreateOrderCommand_WithValidOrder_ShouldReturnOrder(List<Product> products, int clientId)
        {
            //arrange
            var command = new CreateOrderCommand(products, clientId);
            _OrderRepositoryMock.Setup(x => x.Create(It.IsAny<Order>())).Returns(1);
            _ProductRepositoryMock.Setup(x => x.GetUnavailables(It.IsAny<List<Product>>())).Returns(new List<Product>());
            var handler = new OrderHandler(_OrderRepositoryMock.Object, _ProductRepositoryMock.Object);

            //Act
            var result = (HandleResult)handler.Handle(command);

            //Assert
            Assert.True(result.Sucess);
            Assert.Equal("Pedido criado com sucesso", result.Message);
            Assert.Empty(result.Errors);
            _OrderRepositoryMock.Verify(x => x.Create(It.IsAny<Order>()), Times.Once);
            _ProductRepositoryMock.Verify(x => x.GetUnavailables(It.IsAny<List<Product>>()), Times.Once);
        }


        [Theory]
        [MemberData(nameof(InvalidOrderData.Data), MemberType = typeof(InvalidOrderData))]
        public void CreateOrderCommand_WithInvalidData_ShouldNotCreateOrder(List<Product> products, int clientId)
        {
            //Arrange
            var command = new CreateOrderCommand(products, clientId);
            _OrderRepositoryMock.Setup(x => x.Create(It.IsAny<Order>())).Returns(1);
            _ProductRepositoryMock.Setup(x => x.GetUnavailables(It.IsAny<List<Product>>())).Returns(new List<Product>());
            var handler = new OrderHandler(_OrderRepositoryMock.Object, _ProductRepositoryMock.Object);

            //Act
            var result = (HandleResult)handler.Handle(command);

            //Assert
            Assert.False(result.Sucess);
            Assert.Equal("Não foi possível criar o pedido", result.Message);
            Assert.NotEmpty(result.Errors);
            _OrderRepositoryMock.Verify(x => x.Create(It.IsAny<Order>()), Times.Never);
            _ProductRepositoryMock.Verify(x => x.GetUnavailables(It.IsAny<List<Product>>()), Times.Never);
        }

        [Theory]
        [MemberData(nameof(ValidOrderData.GetData), MemberType = typeof(ValidOrderData))]
        public void CreateOrderCommand_WithUnavailableProduct_ShouldNotCreateOrder(List<Product> products, int clientId)
        {
            //Arrange
            var command = new CreateOrderCommand(products, clientId);
            _OrderRepositoryMock.Setup(x => x.Create(It.IsAny<Order>())).Returns(1);
            _ProductRepositoryMock.Setup(x => x.GetUnavailables(It.IsAny<List<Product>>())).Returns(products);
            var handler = new OrderHandler(_OrderRepositoryMock.Object, _ProductRepositoryMock.Object);

            //Act
            var result = (HandleResult)handler.Handle(command);


            //Assert
            Assert.False(result.Sucess);
            Assert.Equal("Não foi possível criar o pedido, um ou mais produto indisponível", result.Message);
            Assert.NotEmpty(result.Errors);
            _OrderRepositoryMock.Verify(x => x.Create(It.IsAny<Order>()), Times.Never);
            _ProductRepositoryMock.Verify(x => x.GetUnavailables(It.IsAny<List<Product>>()), Times.Once);
        }




    }
}
