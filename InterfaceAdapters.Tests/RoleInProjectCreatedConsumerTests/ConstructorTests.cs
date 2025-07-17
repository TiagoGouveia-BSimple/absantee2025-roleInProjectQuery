using Application.IService;
using InterfaceAdapters.Consumer;
using Moq;

namespace InterfaceAdapters.Tests.RoleInProjectCreatedConsumerTests;

public class ConstructorTests
{
    [Fact]
    public void WhenConstructorIsCalled_ThenObjectIsInstantiated()
    {
        // Arrange
        var serviceMock = new Mock<IRoleInProjectService>();

        // Act
        new RoleInProjectCreatedConsumer(serviceMock.Object);

        // Assert
    }
}
