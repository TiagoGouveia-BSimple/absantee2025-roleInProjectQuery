using System.Threading.Tasks;
using Domain.Models;
using Infrastructure.DataModel;
using Infrastructure.Repository;
using Moq;

namespace Infrastructure.Tests.RepositoryTests;

public class GetByIdTests : RepositoryTestBase
{
    [Fact]
    public void WhenGivenExistingId_ThenReturnObject()
    {
        // Arrange
        var id = Guid.NewGuid();
        var roleInProject = new RoleInProjectDataModel(id, id, It.IsAny<PeriodDate>(), id, id);

        context.Add(roleInProject);
        context.SaveChanges();

        var roleInProjectRepository = new RoleInProjectRepository(context, mapper);

        // Act
        var result = roleInProjectRepository.GetById(id);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(roleInProject.Id, result.Id);
        Assert.Equal(roleInProject.ProjectId, result.ProjectId);
        Assert.Equal(roleInProject.UserId, result.UserId);
        Assert.Equal(roleInProject.RoleId, result.RoleId);
    }
}
