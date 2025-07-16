using Domain.Models;

namespace Application.DTO;

public record CreatedRoleInProjectDTO(Guid id, Guid projectId, PeriodDate period, Guid userId, Guid roleId);
