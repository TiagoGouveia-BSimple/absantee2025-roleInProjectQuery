using Domain.IModel;
using Domain.Model;
using Domain.Visitor;

namespace Domain.IRepository;

public interface IRoleInProjectRepository : IGenericRepositoryEF<IRoleInProject, RoleInProject, IRoleInProjectVisitor>
{
    Task<bool> ExistsById(Guid id);
}
