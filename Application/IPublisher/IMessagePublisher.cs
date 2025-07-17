using Domain.Models;

namespace Application.IPublisher;

public interface IMessagePublisher
{
    Task PublishRoleInProjectCreatedMessageAsync(Guid id, Guid projectId, PeriodDate period, Guid userId, Guid roleId);
}
