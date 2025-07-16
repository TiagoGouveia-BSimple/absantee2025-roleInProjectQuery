using Domain.Factory;
using Domain.Models;
using Domain.Visitor;
using Moq;

namespace Domain.Tests.RoleInProjectTests;

public class RoleInProjectFactoryTests
{
    [Fact]
    public async Task WhenCreatingRoleInProjectWithValidArguments_ThenRoleInProjectIsCreated()
    {
        // Arrange
        var factory = new RoleInProjectFactory();

        var id = Guid.NewGuid();
        var period = new PeriodDate();

        // Act
        var result = await factory.Create(id, period, id, id);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(id, result.ProjectId);
        Assert.Equal(period, result.Period);
        Assert.Equal(id, result.UserId);
        Assert.Equal(id, result.RoleId);
    }

    [Fact]
    public void WhenCreatingRoleInProjectWithVisitor_ThenRoleInProjectIsCreated()
    {
        // Arrange
        var visitor = new Mock<IRoleInProjectVisitor>();

        var id = Guid.NewGuid();
        var period = new PeriodDate();

        visitor.Setup(v => v.Id).Returns(id);
        visitor.Setup(v => v.ProjectId).Returns(id);
        visitor.Setup(v => v.Period).Returns(period);
        visitor.Setup(v => v.UserId).Returns(id);
        visitor.Setup(v => v.RoleId).Returns(id);

        var factory = new RoleInProjectFactory();

        // Act
        var result = factory.Create(visitor.Object);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(id, result.Id);
        Assert.Equal(period, result.Period);
        Assert.Equal(id, result.ProjectId);
        Assert.Equal(id, result.UserId);
        Assert.Equal(id, result.RoleId);
    }
}
