using Domain.IModel;
using Domain.Model;
using Domain.Models;
using Infrastructure.DataModel;
using Infrastructure.Repository;
using Moq;

namespace Infrastructure.Tests.RepositoryTests;

public class ExistsByIdTests : RepositoryTestBase
{
    [Fact]
    public async Task WhenGivenExistingId_ThenReturnTrue()
    {
        // Arrange
        var id = Guid.NewGuid();
        var roleInProject = new RoleInProjectDataModel(id, id, It.IsAny<PeriodDate>(), id, id);
        
        mapper.Setup(m => m.Map<RoleInProjectDataModel, IRoleInProject>(It.IsAny<RoleInProjectDataModel>()))
            .Returns(new RoleInProject(id, id, It.IsAny<PeriodDate>(), id, id));

        context.Add(roleInProject);
        context.SaveChanges();

        var roleInProjectRepository = new RoleInProjectRepository(context, mapper.Object);

        // Act
        var result = await roleInProjectRepository.ExistsById(id);

        // Assert
        Assert.True(result);
    }
}
