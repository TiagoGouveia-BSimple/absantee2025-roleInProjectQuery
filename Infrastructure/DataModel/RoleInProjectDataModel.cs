using Domain.Models;
using Domain.Visitor;

namespace Infrastructure.DataModel;

public class RoleInProjectDataModel : IRoleInProjectVisitor
{
    public Guid Id { get; set; }

    public Guid ProjectId { get; set; }

    public PeriodDate Period { get; set; }

    public Guid UserId { get; set; }

    public Guid RoleId { get; set; }

    public RoleInProjectDataModel(Guid id, Guid projectId, PeriodDate period, Guid userId, Guid roleId)
    {
        Id = id;
        ProjectId = projectId;
        Period = period;
        UserId = userId;
        RoleId = roleId;
    }

    public RoleInProjectDataModel()
    {

    }
}
