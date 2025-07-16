using Domain.Models;

namespace Application.DTO;

public record RoleInProjectDTO(Guid id, Guid projectId, PeriodDate period, Guid userId, Guid roleId);
