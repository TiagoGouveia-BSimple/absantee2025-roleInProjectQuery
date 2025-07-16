using Application.Service;
using Domain.IFactory;
using Domain.IRepository;
using Moq;

namespace Application.Tests.ServiceTests;

public class ConstructorTests
{
    [Fact]
    public void WhenGivenCorrectArguments_ThenObjectIsInstantiated()
    {
        // Arrange
        var roleInProjectRepository = new Mock<IRoleInProjectRepository>();
        var roleInProjectFactory = new Mock<IRoleInProjectFactory>();

        // Act
        new RoleInProjectService(roleInProjectRepository.Object, roleInProjectFactory.Object);
    
        // Assert
    }
}
