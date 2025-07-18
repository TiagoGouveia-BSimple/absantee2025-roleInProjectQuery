using Application.DTO;
using Application.IPublisher;
using Application.IService;
using Domain.IFactory;
using Domain.IRepository;
using Domain.Models;
using Infrastructure.DataModel;

namespace Application.Service;

public class RoleInProjectService : IRoleInProjectService
{
    private readonly IRoleInProjectRepository RoleInProjectRepository;
    private readonly IRoleInProjectFactory RoleInProjectFactory;
    private readonly IMessagePublisher MessagePublisher;

    public RoleInProjectService(IRoleInProjectRepository roleInProjectRepository,
        IRoleInProjectFactory roleInProjectFactory, IMessagePublisher messagePublisher)
    {
        RoleInProjectRepository = roleInProjectRepository;
        RoleInProjectFactory = roleInProjectFactory;
        MessagePublisher = messagePublisher;
    }

    public async Task<Result<CreatedRoleInProjectDTO>> Create(CreateRoleInProjectDTO createRoleInProjectDTO)
    {
        try
        {
            var roleInProject = await RoleInProjectFactory.Create(
                createRoleInProjectDTO.projectId, createRoleInProjectDTO.period,
                createRoleInProjectDTO.userId, createRoleInProjectDTO.roleId
                );
            roleInProject = await RoleInProjectRepository.AddAsync(roleInProject);

            var res = new CreatedRoleInProjectDTO(roleInProject.Id, 
                roleInProject.ProjectId, roleInProject.Period,
                roleInProject.UserId, roleInProject.RoleId);

            await MessagePublisher.PublishRoleInProjectCreatedMessageAsync(roleInProject.Id, 
                roleInProject.ProjectId, roleInProject.Period,
                roleInProject.UserId, roleInProject.RoleId);

            return Result<CreatedRoleInProjectDTO>.Success(res);
        }
        catch (ArgumentException ex)
        {
            return Result<CreatedRoleInProjectDTO>.Failure(Error.InternalServerError(ex.Message));
        }
    }

    public async Task CreateRoleInProjectConsumed(Guid id, Guid projectId, PeriodDate period, Guid userId, Guid roleId)
    {
        if (await RoleInProjectRepository.ExistsById(id)) return;

        var roleInProjectDM = new RoleInProjectDataModel(id, projectId, period, userId, roleId);

        var roleInProject = RoleInProjectFactory.Create(roleInProjectDM);

        await RoleInProjectRepository.AddAsync(roleInProject);
    }

    public async Task<Result<IEnumerable<RoleInProjectDTO>>> GetAll()
    {
        try
        {
            var rolesInProject = await RoleInProjectRepository.GetAllAsync();
            var res = rolesInProject.Select(r => new RoleInProjectDTO(r.Id, r.ProjectId, r.Period, r.UserId, r.RoleId));

            return Result<IEnumerable<RoleInProjectDTO>>.Success(res);
        }
        catch (ArgumentException ex)
        {
            return Result<IEnumerable<RoleInProjectDTO>>.Failure(Error.InternalServerError(ex.Message));
        }
    }

    public async Task<Result<RoleInProjectDTO?>> GetById(Guid id)
    {
        try
        {
            var roleInProject = await RoleInProjectRepository.GetByIdAsync(id);

            if (roleInProject == null)
                return Result<RoleInProjectDTO?>.Success(null);

            var res = new RoleInProjectDTO(roleInProject.Id,
                roleInProject.ProjectId, roleInProject.Period,
                roleInProject.UserId, roleInProject.RoleId);

            return Result<RoleInProjectDTO?>.Success(res);
        }
        catch (ArgumentException ex)
        {
            return Result<RoleInProjectDTO?>.Failure(Error.InternalServerError(ex.Message));
        }
    }

    public async Task<Result<UpdatedRoleInProjectDTO>> Update(Guid id, UpdateRoleInProjectDTO updateRoleInProjectDTO)
    {
        try
        {
            var roleInProject = await RoleInProjectRepository.UpdateRoleInProject(id,
                updateRoleInProjectDTO.projectId, updateRoleInProjectDTO.period,
                updateRoleInProjectDTO.userId, updateRoleInProjectDTO.roleId);

            var res = new UpdatedRoleInProjectDTO(roleInProject.Id,
                roleInProject.ProjectId, roleInProject.Period,
                roleInProject.UserId, roleInProject.RoleId);
            
            await MessagePublisher.PublishRoleInProjectUpdatedMessageAsync(roleInProject.Id, 
                roleInProject.ProjectId, roleInProject.Period,
                roleInProject.UserId, roleInProject.RoleId);

            return Result<UpdatedRoleInProjectDTO>.Success(res);
        }
        catch (ArgumentException ex)
        {
            return Result<UpdatedRoleInProjectDTO>.Failure(Error.InternalServerError(ex.Message));
        }
    }

    public async Task UpdateConsumed(Guid id, Guid projectId, PeriodDate period, Guid userId, Guid roleId)
    {
        var dm = await RoleInProjectRepository.GetByIdAsync(id);

        if (dm.Id == id && dm.ProjectId == projectId && dm.Period == period &&
            dm.UserId == userId && dm.RoleId == roleId) return;

        await RoleInProjectRepository.UpdateRoleInProject(id,
            projectId, period,
            userId, roleId);
    }
}
