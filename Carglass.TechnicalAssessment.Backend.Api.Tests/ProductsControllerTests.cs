using Carglass.TechnicalAssessment.Api.Controllers;
using Carglass.TechnicalAssessment.Models.Dto;
using Carglass.TechnicalAssessment.Services.IServices;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Carglass.TechnicalAssessment.Api.Tests
{
    public class ProductsControllerTests
    {
        private readonly Mock<IProductService> _mockProductService;
        private readonly ProductsController _controller;

        public ProductsControllerTests()
        {
            _mockProductService = new Mock<IProductService>();
            _controller = new ProductsController(_mockProductService.Object);
        }

        [Fact]
        public void GetAll_ReturnsOkResult_WithListOfProducts()
        {
            // Arrange
            var products = new List<ProductDto>
                    {
                        new ProductDto { Id = 1, ProductName = "Product1", ProductType = 1, NumTerminal = 100, SoldAt = DateTime.Now },
                        new ProductDto { Id = 2, ProductName = "Product2", ProductType = 2, NumTerminal = 200, SoldAt = DateTime.Now }
                    };
            _mockProductService.Setup(service => service.GetAll()).Returns(products);

            // Act
            var result = _controller.GetAll();

            // Assert
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            var returnValue = okResult.Value.Should().BeAssignableTo<List<ProductDto>>().Subject;
            returnValue.Should().HaveCount(2);
        }

        [Fact]
        public void GetById_ReturnsOkResult_WithProduct()
        {
            // Arrange
            var product = new ProductDto { Id = 1, ProductName = "Product1", ProductType = 1, NumTerminal = 100, SoldAt = DateTime.Now };
            _mockProductService.Setup(service => service.GetById(1)).Returns(product);

            // Act
            var result = _controller.GetById(1);

            // Assert
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            var returnValue = okResult.Value.Should().BeAssignableTo<ProductDto>().Subject;
            returnValue.Id.Should().Be(1);
        }

        [Fact]
        public void Create_ReturnsCreatedAtActionResult()
        {
            // Arrange
            var product = new ProductDto { Id = 1, ProductName = "Product1", ProductType = 1, NumTerminal = 100, SoldAt = DateTime.Now };

            // Act
            var result = _controller.Create(product);

            // Assert
            var createdAtActionResult = result.Should().BeOfType<CreatedAtActionResult>().Subject;
            createdAtActionResult.ActionName.Should().Be(nameof(_controller.GetById));
            createdAtActionResult.RouteValues["id"].Should().Be(product.Id);
        }

        [Fact]
        public void Update_ReturnsOkResult()
        {
            // Arrange
            var product = new ProductDto { Id = 1, ProductName = "Product1", ProductType = 1, NumTerminal = 100, SoldAt = DateTime.Now };

            // Act
            var result = _controller.Update(product);

            // Assert
            result.Should().BeOfType<OkResult>();
        }

        [Fact]
        public void Delete_ReturnsNoContentResult()
        {
            // Arrange
            var product = new ProductDto { Id = 1, ProductName = "Product1", ProductType = 1, NumTerminal = 100, SoldAt = DateTime.Now };

            // Act
            var result = _controller.Delete(product);

            // Assert
            result.Should().BeOfType<NoContentResult>();
        }
    }
}
