using AutoMapper;
using Domain.IFactory;
using Domain.IModel;
using Infrastructure.DataModel;

namespace Infrastructure.Resolver;

public class RoleInProjectDataModelConverter : ITypeConverter<RoleInProjectDataModel, IRoleInProject>
{
    private readonly IRoleInProjectFactory _roleInProjectFactory;

    public RoleInProjectDataModelConverter(IRoleInProjectFactory roleInProjectFactory)
    {
        _roleInProjectFactory = roleInProjectFactory;
    }

    public IRoleInProject Convert(RoleInProjectDataModel source, IRoleInProject destination, ResolutionContext context)
    {
        var res = _roleInProjectFactory.Create(source);
        return res;
    }

    public bool UpdateDataModel(RoleInProjectDataModel userDataModel, IRoleInProject userDomain)

    {
        userDataModel.Id = userDomain.Id;

        // pode ser necessário mais atualizações, e com isso o retorno não ser sempre true
        // contudo, porque userDataModel está a ser gerido pelo DbContext, para atualizarmos a DB, é este que tem de ser alterado, e não criar um novo

        userDataModel.Period.InitDate = userDomain.Period.InitDate;
        userDataModel.Period.FinalDate = userDomain.Period.FinalDate;
        return true;
    }
}
