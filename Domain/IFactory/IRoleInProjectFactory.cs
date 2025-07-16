using Domain.IModel;
using Domain.Visitor;

namespace Domain.IFactory;

public interface IRoleInProjectFactory
{
    Task<IRoleInProject> Create(Guid projectId, Guid period, Guid userId, Guid roleId);
    IRoleInProject Create(IRoleInProjectVisitor visitor);
}
