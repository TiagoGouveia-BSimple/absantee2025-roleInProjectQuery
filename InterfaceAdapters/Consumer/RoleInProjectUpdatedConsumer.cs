using Application.IService;
using Domain.Message;
using Domain.Model;
using MassTransit;

namespace InterfaceAdapters.Consumer;

public class RoleInProjectUpdatedConsumer : IConsumer<RoleInProjectUpdatedMessage>
{
    private readonly IRoleInProjectService _roleInProjectService;

    public RoleInProjectUpdatedConsumer(IRoleInProjectService roleInProjectService)
    {
        _roleInProjectService = roleInProjectService;
    }

    public async Task Consume(ConsumeContext<RoleInProjectUpdatedMessage> context)
    {
        var msg = context.Message;
        await _roleInProjectService.UpdateConsumed(msg.Id,
            msg.ProjectId, msg.Period, msg.UserId, msg.RoleId);
    }
}
