using System.Runtime.CompilerServices;
using Domain.Model;
using Domain.Models;
using Moq;

namespace Domain.Tests.RoleInProjectTests;

public class ConstructorTests
{
    [Fact]
    public void WhenGivenCorrectParameters_ThenObjectIsInstantiated()
    {
        // Arrange

        // Act
        new RoleInProject(It.IsAny<Guid>(), It.IsAny<Guid>(), It.IsAny<PeriodDate>(), It.IsAny<Guid>(), It.IsAny<Guid>());
    
        // Assert 
    }
}
