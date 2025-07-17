using Infrastructure.Repository;

namespace Infrastructure.Tests.RepositoryTests;

public class ConstructorTests : RepositoryTestBase
{
    [Fact]
    public void WhenGivenCorrectParameters_ThenObjectIsInstantiated()
    {
        // Arrange


        // Act
        new RoleInProjectRepository(context, mapper.Object);
    
        // Assert
    }
}
