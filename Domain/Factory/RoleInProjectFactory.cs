using Domain.IFactory;
using Domain.IModel;
using Domain.Model;
using Domain.Models;
using Domain.Visitor;

namespace Domain.Factory;

public class RoleInProjectFactory : IRoleInProjectFactory
{
    public async Task<IRoleInProject> Create(Guid projectId, PeriodDate period, Guid userId, Guid roleId)
    {
        return new RoleInProject(Guid.NewGuid(), projectId, period, userId, roleId);
    }

    public IRoleInProject Create(IRoleInProjectVisitor visitor)
    {
        return new RoleInProject(visitor.Id, visitor.ProjectId, visitor.Period, visitor.UserId, visitor.RoleId);
    }
}
