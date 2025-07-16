using Domain.Models;

namespace Domain.Visitor;

public interface IRoleInProjectVisitor
{
    Guid Id { get; }
    Guid ProjectId { get; }
    PeriodDate Period { get; }
    Guid UserId { get; }
    Guid RoleId { get; }
}
