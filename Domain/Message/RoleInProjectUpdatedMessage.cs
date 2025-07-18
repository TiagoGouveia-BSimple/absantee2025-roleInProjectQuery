using Domain.Models;

namespace Domain.Message;

public record RoleInProjectUpdatedMessage(Guid Id, Guid ProjectId, PeriodDate Period, Guid UserId, Guid RoleId);
