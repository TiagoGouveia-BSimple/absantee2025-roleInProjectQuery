using Domain.Models;

namespace Application.DTO;

public record CreateRoleInProjectDTO(Guid projectId, PeriodDate period, Guid userId, Guid roleId);
