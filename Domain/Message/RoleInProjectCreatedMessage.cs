using Domain.Models;

namespace Domain.Message;

public record RoleInProjectCreatedMessage(Guid Id, Guid ProjectId, PeriodDate Period, Guid UserId, Guid RoleId);
