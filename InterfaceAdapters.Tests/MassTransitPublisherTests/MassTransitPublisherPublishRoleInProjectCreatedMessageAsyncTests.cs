using Domain.Message;
using Domain.Models;
using InterfaceAdapters.Publisher;
using MassTransit;
using Moq;
using Xunit;

namespace InterfaceAdapters.Tests.MassTransitPublisherTests;

public class MassTransitPublisherPublishRoleInProjectCreatedMessageAsyncTests
{
    [Fact]
    public async Task WhenPublisherIsCalled_ThenPublishUser()
    {
        // Arrange
        var endpointMock = new Mock<IPublishEndpoint>();
        var publisher = new MassTransitPublisher(endpointMock.Object);

        var id = Guid.NewGuid();
        var period = It.IsAny<PeriodDate>();

        // Act
        await publisher.PublishRoleInProjectCreatedMessageAsync(id, id, period, id, id);

        // Assert
        endpointMock.Verify(p => p.Publish(
            It.Is<RoleInProjectCreatedMessage>(m =>
            m.Id == id),
            It.IsAny<CancellationToken>()),
            Times.Once
        );
    }
}
