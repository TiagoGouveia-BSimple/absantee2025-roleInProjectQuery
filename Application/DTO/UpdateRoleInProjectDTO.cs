using Domain.Models;

namespace Application.DTO;

public record UpdateRoleInProjectDTO(Guid id, Guid projectId, PeriodDate period, Guid userId, Guid roleId);
