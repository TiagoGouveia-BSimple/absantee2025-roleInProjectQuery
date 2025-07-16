using Domain.Model;
using Domain.Models;

namespace Domain.Tests.RoleInProjectTests;

public class UpdateRoleTests
{
    [Fact]
    public void WhenGivenCorrectParameters_ThenRoleIsUpdated()
    {
        // Arrange
        var id = Guid.NewGuid();
        var period = new PeriodDate();

        var roleInProject = new RoleInProject(id, id, period, id, id);

        var newRoleId = Guid.NewGuid();

        // Act
        roleInProject.UpdateRole(newRoleId);

        // Assert
        Assert.Equal(newRoleId, roleInProject.RoleId);
    }
}
