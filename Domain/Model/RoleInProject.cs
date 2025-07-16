using Domain.IModel;
using Domain.Models;

namespace Domain.Model;

public class RoleInProject : IRoleInProject
{
    public Guid Id { get; private set; }

    public Guid ProjectId { get; private set; }

    public PeriodDate Period { get; private set; }

    public Guid UserId { get; private set; }

    public Guid RoleId { get; private set; }

    public RoleInProject(Guid id, Guid projectId, PeriodDate period, Guid userId, Guid roleId)
    {
        Id = id;
        ProjectId = projectId;
        Period = period;
        UserId = userId;
        RoleId = roleId;
    }

    public void UpdatePeriod(PeriodDate period)
    {
        Period = period;
    }

    public void UpdateRole(Guid roleId)
    {
        RoleId = roleId;
    }

    public void UpdateUser(Guid userId)
    {
        UserId = userId;
    }
}
