using AutoMapper;
using Domain.IModel;
using Domain.Models;
using Infrastructure.DataModel;
using Infrastructure.Resolver;

namespace Infrastructure;

public class DataModelMappingProfile : Profile
{
    public DataModelMappingProfile()
    {
        CreateMap<IRoleInProject, RoleInProjectDataModel>();
        CreateMap<RoleInProjectDataModel, IRoleInProject>()
            .ConvertUsing<RoleInProjectDataModelConverter>();
    }

}