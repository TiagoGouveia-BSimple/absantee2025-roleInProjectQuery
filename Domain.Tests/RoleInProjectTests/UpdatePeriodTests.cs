using Domain.Model;
using Domain.Models;

namespace Domain.Tests.RoleInProjectTests;

public class UpdatePeriodTests
{
    [Fact]
    public void WhenGivenCorrectParameters_ThenPeriodIsUpdated()
    {
        // Arrange
        var id = Guid.NewGuid();
        var period = new PeriodDate();

        var roleInProject = new RoleInProject(id, id, period, id, id);

        var newPeriod = new PeriodDate(DateOnly.FromDateTime(DateTime.UtcNow), DateOnly.FromDateTime(DateTime.UtcNow));

        // Act
        roleInProject.UpdatePeriod(newPeriod);

        // Assert
        Assert.Equal(newPeriod.InitDate, roleInProject.Period.InitDate);
        Assert.Equal(newPeriod.FinalDate, roleInProject.Period.FinalDate);
    }
}
