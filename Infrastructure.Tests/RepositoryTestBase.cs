using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;

namespace Infrastructure.Tests;

public class RepositoryTestBase
{
    protected readonly IMapper mapper;
    protected readonly RoleInProjectContext context;

    protected RepositoryTestBase()
    {
        // Configure AutoMapper
        var loggingFactory = NullLoggerFactory.Instance;

        var config = new MapperConfiguration(cfg =>
        {
           cfg.AddProfile<DataModelMappingProfile>();
        }, loggingFactory);
        mapper = config.CreateMapper();

        // Configure in-memory database
        var options = new DbContextOptionsBuilder<RoleInProjectContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()) // unique DB per test
            .Options;

        context = new RoleInProjectContext(options);
    }
}
