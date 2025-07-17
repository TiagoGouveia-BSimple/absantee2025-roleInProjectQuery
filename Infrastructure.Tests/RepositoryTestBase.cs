using AutoMapper;
using Domain.IModel;
using Domain.Model;
using Infrastructure.DataModel;
using Infrastructure.Resolver;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;

namespace Infrastructure.Tests;

public class RepositoryTestBase
{
    protected readonly Mock<IMapper> mapper;
    protected readonly RoleInProjectContext context;

    protected RepositoryTestBase()
    {
        // Configure AutoMapper
        // var loggingFactory = NullLoggerFactory.Instance;

        // var converter = new RoleInProjectDataModelConverter();

        // var config = new MapperConfiguration(cfg =>
        // {
        //     cfg.AddProfile<DataModelMappingProfile>();
        //     cfg.CreateMap<RoleInProjectDataModel, IRoleInProject>().ConvertUsing(converter);
            
        // }, loggingFactory);
        // mapper = config.CreateMapper();
        mapper = new Mock<IMapper>();

        // Configure in-memory database
        var options = new DbContextOptionsBuilder<RoleInProjectContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()) // unique DB per test
            .Options;

        context = new RoleInProjectContext(options);
    }
}
