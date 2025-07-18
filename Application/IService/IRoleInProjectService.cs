using Application.DTO;
using Domain.Models;

namespace Application.IService;

public interface IRoleInProjectService
{
    Task<Result<CreatedRoleInProjectDTO>> Create(CreateRoleInProjectDTO createRoleInProjectDTO);
    Task<Result<UpdatedRoleInProjectDTO>> Update(Guid id, UpdateRoleInProjectDTO updateRoleInProjectDTO);
    Task CreateRoleInProjectConsumed(Guid id, Guid projectId, PeriodDate period, Guid userId, Guid roleId);
    Task UpdateConsumed(Guid id, Guid projectId, PeriodDate period, Guid userId, Guid roleId);
    Task<Result<IEnumerable<RoleInProjectDTO>>> GetAll();
    Task<Result<RoleInProjectDTO?>> GetById(Guid id);
    Task<Result<IEnumerable<RoleInProjectDTO>>> GetByProjectId(Guid projectId);
}
