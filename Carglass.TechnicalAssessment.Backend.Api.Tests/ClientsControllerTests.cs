using Carglass.TechnicalAssessment.Api.Controllers;
using Carglass.TechnicalAssessment.Models.Dto;
using Carglass.TechnicalAssessment.Services.IServices;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Carglass.TechnicalAssessment.Api.Tests
{
    public class ClientsControllerTests
    {
        private readonly Mock<IClientService> _mockClientService;
        private readonly ClientsController _controller;

        public ClientsControllerTests()
        {
            _mockClientService = new Mock<IClientService>();
            _controller = new ClientsController(_mockClientService.Object);
        }

        [Fact]
        public void GetAll_ReturnsOkResult_WithListOfClients()
        {
            // Arrange
            var clients = new List<ClientDto>
                {
                    new ClientDto { Id = 1, GivenName = "John", FamilyName1 = "Doe" },
                    new ClientDto { Id = 2, GivenName = "Jane", FamilyName1 = "Doe" }
                };
            _mockClientService.Setup(service => service.GetAll()).Returns(clients);

            // Act
            var result = _controller.GetAll();

            // Assert
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            var returnValue = okResult.Value.Should().BeAssignableTo<List<ClientDto>>().Subject;
            returnValue.Should().HaveCount(2);
        }

        [Fact]
        public void GetById_ReturnsOkResult_WithClient()
        {
            // Arrange
            var client = new ClientDto { Id = 1, GivenName = "John", FamilyName1 = "Doe" };
            _mockClientService.Setup(service => service.GetById(1)).Returns(client);

            // Act
            var result = _controller.GetById(1);

            // Assert
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            var returnValue = okResult.Value.Should().BeAssignableTo<ClientDto>().Subject;
            returnValue.Id.Should().Be(1);
        }

        [Fact]
        public void Create_ReturnsCreatedAtActionResult()
        {
            // Arrange
            var client = new ClientDto { Id = 1, GivenName = "John", FamilyName1 = "Doe" };

            // Act
            var result = _controller.Create(client);

            // Assert
            var createdAtActionResult = result.Should().BeOfType<CreatedAtActionResult>().Subject;
            createdAtActionResult.ActionName.Should().Be(nameof(_controller.GetById));
            createdAtActionResult.RouteValues["id"].Should().Be(client.Id);
        }

        [Fact]
        public void Update_ReturnsOkResult()
        {
            // Arrange
            var client = new ClientDto { Id = 1, GivenName = "John", FamilyName1 = "Doe" };

            // Act
            var result = _controller.Update(client);

            // Assert
            result.Should().BeOfType<OkResult>();
        }

        [Fact]
        public void Delete_ReturnsNoContentResult()
        {
            // Arrange
            var client = new ClientDto { Id = 1, GivenName = "John", FamilyName1 = "Doe" };

            // Act
            var result = _controller.Delete(client);

            // Assert
            result.Should().BeOfType<NoContentResult>();
        }
    }
}
