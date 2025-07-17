using Application.IService;
using Domain.Message;
using Domain.Model;
using MassTransit;

namespace InterfaceAdapters.Consumer;

public class RoleInProjectCreatedConsumer : IConsumer<RoleInProjectCreatedMessage>
{
    private readonly IRoleInProjectService _roleInProjectService;

    public RoleInProjectCreatedConsumer(IRoleInProjectService roleInProjectService)
    {
        _roleInProjectService = roleInProjectService;
    }

    public async Task Consume(ConsumeContext<RoleInProjectCreatedMessage> context)
    {
        var msg = context.Message;
        await _roleInProjectService.CreateRoleInProjectConsumed(msg.Id,
            msg.ProjectId, msg.Period, msg.UserId, msg.RoleId);
    }
}
