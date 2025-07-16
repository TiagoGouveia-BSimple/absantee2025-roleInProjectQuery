using Domain.Models;

namespace Domain.IModel;

public interface IRoleInProject
{
    Guid Id { get; }
    Guid ProjectId { get; }
    PeriodDate Period { get; }
    Guid UserId { get; }
    Guid RoleId { get; }

    void UpdatePeriod(PeriodDate period);
    void UpdateUser(Guid userId);
    void UpdateRole(Guid roleId);
}
