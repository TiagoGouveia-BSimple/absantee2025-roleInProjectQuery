using System.Threading.Tasks;
using Application.IService;
using Application.Service;
using Domain.Message;
using Domain.Models;
using InterfaceAdapters.Consumer;
using MassTransit;
using Moq;
using Xunit;

namespace InterfaceAdapters.Tests.RoleInProjectCreatedConsumerTests;

public class UserCreatedConsumerConsumeTest
{
    [Fact]
    public async Task WhenMessageIsConsumed_ThenServiceMethodIsCalledWithData()
    {
        // Arrange
        var serviceMock = new Mock<IRoleInProjectService>();
        var consumer = new RoleInProjectCreatedConsumer(serviceMock.Object);

        var id = new Guid();
        var period = It.IsAny<PeriodDate>();

        var message = new RoleInProjectCreatedMessage(id, id, period, id, id);

        var contextMock = Mock.Of<ConsumeContext<RoleInProjectCreatedMessage>>(c => c.Message == message);

        // Act
        await consumer.Consume(contextMock);

        // Assert
        serviceMock.Verify(s => s.CreateRoleInProjectConsumed(id, id, period, id, id));
    }
}
