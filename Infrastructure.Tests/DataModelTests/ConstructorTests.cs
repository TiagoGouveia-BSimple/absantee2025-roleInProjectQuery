using Domain.Models;
using Infrastructure.DataModel;
using Moq;

namespace Infrastructure.Tests.DataModelTests;

public class ConstructorTests
{
    [Fact]
    public void WhenGivenCorrectParameters_ThenObjectIsInstantiated()
    {
        // Arrange

        // Act
        new RoleInProjectDataModel(It.IsAny<Guid>(), It.IsAny<Guid>(), It.IsAny<PeriodDate>(), It.IsAny<Guid>(), It.IsAny<Guid>());
    
        // Assert
    }
}
