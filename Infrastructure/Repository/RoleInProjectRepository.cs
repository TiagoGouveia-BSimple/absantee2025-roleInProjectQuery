using AutoMapper;
using Domain.IModel;
using Domain.IRepository;
using Domain.Model;
using Domain.Models;
using Infrastructure.DataModel;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure.Internal;

namespace Infrastructure.Repository;

public class RoleInProjectRepository : GenericRepositoryEF<IRoleInProject, RoleInProject, RoleInProjectDataModel>, IRoleInProjectRepository
{
    private readonly IMapper _mapper;

    public RoleInProjectRepository(RoleInProjectContext context, IMapper mapper) : base(context, mapper)
    {
        _mapper = mapper;
    }

    public async Task<bool> ExistsById(Guid id)
    {
        var roleInProjectDM = await _context.Set<RoleInProjectDataModel>().FirstOrDefaultAsync(r => r.Id == id);
        if (roleInProjectDM == null)
            return false;
        return true;
    }

    public async Task<IEnumerable<RoleInProject>> GetAllByProjectId(Guid projectId)
    {
        var roleInProjectDMs = await _context.Set<RoleInProjectDataModel>().Where(r => r.ProjectId == projectId).ToListAsync();

        return roleInProjectDMs.Select(_mapper.Map<RoleInProjectDataModel, RoleInProject>);
    }

    public override IRoleInProject? GetById(Guid id)
    {
        var roleInProjectDM = _context.Set<RoleInProjectDataModel>().FirstOrDefault(r => r.Id == id);

        if (roleInProjectDM == null)
            return null;

        var roleInProject = _mapper.Map<RoleInProjectDataModel, RoleInProject>(roleInProjectDM);
        return roleInProject;
    }

    public override async Task<IRoleInProject?> GetByIdAsync(Guid id)
    {
        var roleInProjectDM = await _context.Set<RoleInProjectDataModel>().FirstOrDefaultAsync(r => r.Id == id);

        if (roleInProjectDM == null)
            return null;

        var roleInProject = _mapper.Map<RoleInProjectDataModel, RoleInProject>(roleInProjectDM);
        return roleInProject;
    }

    public async Task<RoleInProject> UpdateRoleInProject(Guid id, Guid projectId, PeriodDate period, Guid userId, Guid roleId)
    {
        var dm = await _context.Set<RoleInProjectDataModel>()
            .FirstAsync(r => r.Id == id);

        dm.ProjectId = projectId;
        dm.Period = period;
        dm.UserId = userId;
        dm.RoleId = roleId;
        _context.Entry(dm).State = EntityState.Modified;

        await _context.SaveChangesAsync();

        return _mapper.Map<RoleInProjectDataModel, RoleInProject>(dm);
    }
}
