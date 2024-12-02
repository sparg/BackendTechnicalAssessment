using Carglass.TechnicalAssessment.Api.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace Carglass.TechnicalAssessment.Api.Tests;

public class HealthCheckControllerTests
{
    [Fact]
    public void KeepAlive_ReturnsOkResult()
    {
        // Arrange
        var controller = new HealthCheckController();

        // Act
        var result = controller.KeepAlive();

        // Assert
        result.Should().BeOfType<OkResult>();
    }

    [Fact]
    public void KeepAlive_ReturnsStatusCode200()
    {
        // Arrange
        var controller = new HealthCheckController();

        // Act
        var result = controller.KeepAlive() as OkResult;

        // Assert
        result.Should().NotBeNull();
        result?.StatusCode.Should().Be(200);
    }

    [Fact]
    public void KeepAlive_HandlesExceptionGracefully()
    {
        // Arrange
        var controller = new HealthCheckController();
        // Simulate an exception scenario if applicable

        // Act
        Action act = () => controller.KeepAlive();

        // Assert
        act.Should().NotThrow();
    }
}
