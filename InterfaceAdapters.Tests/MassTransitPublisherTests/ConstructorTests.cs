using InterfaceAdapters.Publisher;
using MassTransit;
using Moq;
using Xunit;

namespace InterfaceAdapters.Tests.MassTransitPublisherTests;

public class ConstructorTest
{
    [Fact]
    public void WhenConstructorIsCalled_ThenObjectIsInstantiated()
    {
        // Arrange
        var endpointMock = new Mock<IPublishEndpoint>();

        // Act
        new MassTransitPublisher(endpointMock.Object);

        // Assert
    }
}
