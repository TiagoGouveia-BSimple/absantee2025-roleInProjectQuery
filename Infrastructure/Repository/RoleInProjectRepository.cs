using AutoMapper;
using Domain.IModel;
using Domain.IRepository;
using Domain.Model;
using Infrastructure.DataModel;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

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
}
