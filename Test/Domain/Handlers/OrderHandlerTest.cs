using Domain.Commands.HistoryCommands;
using Domain.Commands.OrderCommands;
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
    public class OrderHandlerTest
    {
        private readonly Mock<IOrderRepository> _OrderRepositoryMock;
        private readonly Mock<IProductRepository> _ProductRepositoryMock;
        private readonly Mock<IHandler<CreateHistoryCommand>> _historyHandle;
        private readonly Mock<IOrderItemRepository> _orderItemRepoMock;
        private readonly Mock<IStockRepository> _stockRepository;
        public OrderHandlerTest() 
        {
            _OrderRepositoryMock = new Mock<IOrderRepository>();
            _ProductRepositoryMock = new Mock<IProductRepository>();
            _historyHandle = new Mock<IHandler<CreateHistoryCommand>>();
            _orderItemRepoMock = new Mock<IOrderItemRepository>();
            _stockRepository = new Mock<IStockRepository>();
        }


        [Theory]
        [MemberData(nameof(ValidOrderData.GetData), MemberType = typeof(ValidOrderData))]
        public void CreateOrderCommand_WithValidOrder_ShouldReturnOrder(List<OrderItem> orderItens, int clientId, int userId)
        {
            //arrange
            var command = new CreateOrderCommand(orderItens, clientId, userId);
            _OrderRepositoryMock.Setup(x => x.Create(It.IsAny<Order>())).Returns(1);
            _orderItemRepoMock.Setup(x => x.LoadProductsWithStock(It.IsAny<List<OrderItem>>())).Returns(orderItens);            
            var handler = new OrderHandler(_OrderRepositoryMock.Object, _orderItemRepoMock.Object, _historyHandle.Object, _stockRepository.Object);

            //Act
            var result = (HandleResult)handler.Handle(command);

            //Assert
            Assert.True(result.Sucess);
            Assert.Equal("Pedido criado com sucesso", result.Message);
            Assert.Empty(result.Errors);
            _OrderRepositoryMock.Verify(x => x.Create(It.IsAny<Order>()), Times.Once);
            _stockRepository.Verify(x => x.DecreaseStock(It.IsAny<int>(), It.IsAny<int>()), Times.Exactly(orderItens.Count));
        }


        [Theory]
        [MemberData(nameof(InvalidOrderData.Data), MemberType = typeof(InvalidOrderData))]
        public void CreateOrderCommand_WithInvalidData_ShouldNotCreateOrder(List<OrderItem> orderItens, int clientId, int userId)
        {
            //Arrange
            var command = new CreateOrderCommand(orderItens, clientId, userId);
            _OrderRepositoryMock.Setup(x => x.Create(It.IsAny<Order>())).Returns(1);
            _ProductRepositoryMock.Setup(x => x.GetUnavailables(It.IsAny<List<Product>>())).Returns(new List<Product>());
            var handler = new OrderHandler(_OrderRepositoryMock.Object,  _orderItemRepoMock.Object, _historyHandle.Object, _stockRepository.Object);

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
        [MemberData(nameof(ValidOrderWithoutStockData.GetData), MemberType = typeof(ValidOrderWithoutStockData))]
        public void CreateOrderCommand_WithUnavailableProductInStock_ShouldNotCreateOrder(List<OrderItem> orderItems, int clientId, int userId)
        {
            //Arrange
            var command = new CreateOrderCommand(orderItems, clientId, userId);
            _OrderRepositoryMock.Setup(x => x.Create(It.IsAny<Order>())).Returns(1);
            _orderItemRepoMock.Setup(x => x.LoadProductsWithStock(It.IsAny<List<OrderItem>>())).Returns(orderItems);
            var handler = new OrderHandler(_OrderRepositoryMock.Object, _orderItemRepoMock.Object, _historyHandle.Object, _stockRepository.Object);

            //Act
            var result = (HandleResult)handler.Handle(command);


            //Assert
            Assert.False(result.Sucess);
            Assert.Equal("Não foi possível criar o pedido, um ou mais produto indisponível", result.Message);
            Assert.NotEmpty(result.Errors);
            _OrderRepositoryMock.Verify(x => x.Create(It.IsAny<Order>()), Times.Never);
            _stockRepository.Verify(x => x.DecreaseStock(It.IsAny<int>(), It.IsAny<int>()), Times.Never);
        }




    }
}
