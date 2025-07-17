using Application.DTO;
using Application.Service;
using Domain.IFactory;
using Domain.IModel;
using Domain.IRepository;
using Domain.Model;
using Domain.Models;
using Domain.Visitor;
using Moq;

namespace Application.Tests.ServiceTests;

public class CreateTests
{
    [Fact]
    public async Task WhenGivenCorrectArguments_ThenSuccessIsReturned()
    {
        // Arrange
        var id = Guid.NewGuid();
        var period = new PeriodDate(DateOnly.FromDateTime(DateTime.UtcNow), DateOnly.FromDateTime(DateTime.UtcNow));

        var roleInProject = new Mock<IRoleInProject>();
        roleInProject.Setup(e => e.Id).Returns(id);
        roleInProject.Setup(e => e.ProjectId).Returns(id);
        roleInProject.Setup(e => e.Period).Returns(period);
        roleInProject.Setup(e => e.UserId).Returns(id);
        roleInProject.Setup(e => e.RoleId).Returns(id);

        var roleInProjectRepository = new Mock<IRoleInProjectRepository>();
        roleInProjectRepository.Setup(r => r.AddAsync(It.IsAny<IRoleInProject>())).ReturnsAsync(roleInProject.Object);
        
        var roleInProjectFactory = new Mock<IRoleInProjectFactory>();
        roleInProjectFactory.Setup(f => f.Create(It.IsAny<IRoleInProjectVisitor>())).Returns(roleInProject.Object);

        var createRoleInProjectDTO = new CreateRoleInProjectDTO(id, period, id, id);

        var roleInProjectService = new RoleInProjectService(roleInProjectRepository.Object, roleInProjectFactory.Object);

        // Act
        var result = await roleInProjectService.Create(createRoleInProjectDTO);

        // Assert
        Assert.NotNull(result);
        Assert.True(result.IsSuccess);
        Assert.Equal(id, result.Value.roleInProjectId);
        Assert.Equal(id, result.Value.projectId);
        Assert.Equal(period, result.Value.period);
        Assert.Equal(id, result.Value.userId);
        Assert.Equal(id, result.Value.roleId);
    }
}
