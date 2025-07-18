using Domain.IModel;
using Domain.Model;
using Domain.Models;
using Domain.Visitor;

namespace Domain.IRepository;

public interface IRoleInProjectRepository : IGenericRepositoryEF<IRoleInProject, RoleInProject, IRoleInProjectVisitor>
{
    Task<bool> ExistsById(Guid id);
    Task<IEnumerable<RoleInProject>> GetAllByProjectId(Guid projectId);
    Task<RoleInProject> UpdateRoleInProject(Guid id, Guid projectId, PeriodDate period, Guid userId, Guid roleId);
}
