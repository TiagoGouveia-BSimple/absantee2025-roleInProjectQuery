using Domain.IModel;
using Domain.Models;
using Domain.Visitor;

namespace Domain.IFactory;

public interface IRoleInProjectFactory
{
    Task<IRoleInProject> Create(Guid projectId, PeriodDate period, Guid userId, Guid roleId);
    IRoleInProject Create(IRoleInProjectVisitor visitor);
}
