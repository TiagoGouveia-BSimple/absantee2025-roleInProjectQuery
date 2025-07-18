using Application.IPublisher;
using Domain.Message;
using Domain.Models;
using MassTransit;

namespace InterfaceAdapters.Publisher;

public class MassTransitPublisher : IMessagePublisher
{
    private readonly IPublishEndpoint _publishEndpoint;

    public MassTransitPublisher(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }

    public async Task PublishRoleInProjectCreatedMessageAsync(Guid id, Guid projectId, PeriodDate period, Guid userId, Guid roleId)
    {
        await _publishEndpoint.Publish(new RoleInProjectCreatedMessage(id, projectId, period, userId, roleId));
    }

    public async Task PublishRoleInProjectUpdatedMessageAsync(Guid id, Guid projectId, PeriodDate period, Guid userId, Guid roleId)
    {
        await _publishEndpoint.Publish(new RoleInProjectUpdatedMessage(id, projectId, period, userId, roleId));
    }
}
