using Domain.Models;

namespace Application.DTO;

public record CreatedRoleInProjectDTO(Guid roleInProjectId, Guid projectId, PeriodDate period, Guid userId, Guid roleId);
