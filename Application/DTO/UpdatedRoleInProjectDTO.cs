using Domain.Models;

namespace Application.DTO;

public record UpdatedRoleInProjectDTO(Guid id, Guid projectId, PeriodDate period, Guid userId, Guid roleId);
