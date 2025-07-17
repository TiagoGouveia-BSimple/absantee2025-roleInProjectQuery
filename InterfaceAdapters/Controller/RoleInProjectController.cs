using Application.DTO;
using Application.IService;
using Microsoft.AspNetCore.Mvc;

namespace InterfaceAdapters.Controller;

[Route("api/role-in-project")]
[ApiController]
public class RoleInProjectController : ControllerBase
{
    private readonly IRoleInProjectService _roleInProjectService;
    List<string> _errorMessages = new List<string>();

    public RoleInProjectController(IRoleInProjectService roleInProjectService)
    {
        _roleInProjectService = roleInProjectService;
    }

    // Get: api/role-in-project
    [HttpGet]
    public async Task<ActionResult<IEnumerable<RoleInProjectDTO>>> GetAll()
    {
        var result = await _roleInProjectService.GetAll();
        return result.ToActionResult();
    }

    // Get: api/role-in-project/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<RoleInProjectDTO>> GetById(Guid id)
    {
        var result = await _roleInProjectService.GetById(id);

        return result.ToActionResult();
    }
}
