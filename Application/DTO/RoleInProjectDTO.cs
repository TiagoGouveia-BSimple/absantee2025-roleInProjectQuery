using Domain.Models;

namespace Application.DTO;

public record RoleInProjectDTO(Guid roleInProjectId, Guid projectId, PeriodDate period, Guid userId, Guid roleId);
