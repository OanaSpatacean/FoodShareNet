using FoodShareNet.Application.Interfaces;
using FoodShareNet.Application.Services;
using FoodShareNet.Domain.Entities;
using Moq;

namespace FoodShareNET.UnitTest
{
    [TestFixture]
    public class OrderServiceTests
    {
        private Mock<IFoodShareDbContext> _contextMock;
        private IOrderService _orderService;

        [SetUp]
        public void Setup()
        {
            _contextMock = new Mock<IFoodShareDbContext>();
            _orderService = new OrderService(_contextMock.Object);
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}