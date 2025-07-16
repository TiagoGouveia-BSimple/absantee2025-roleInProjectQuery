using Domain.Model;
using Domain.Models;

namespace Domain.Tests.RoleInProjectTests;

public class UpdateUserTests
{
    [Fact]
    public void WhenGivenCorrectParameters_ThenUserIsUpdated()
    {
        // Arrange
        var id = Guid.NewGuid();
        var period = new PeriodDate();

        var roleInProject = new RoleInProject(id, id, period, id, id);

        var newUserId = Guid.NewGuid();

        // Act
        roleInProject.UpdateUser(newUserId);

        // Assert
        Assert.Equal(newUserId, roleInProject.UserId);
    }
}
