using Microsoft.AspNetCore.Mvc;
using PintosTechnicalApp.DTOs;
using PintosTechnicalApp.Exceptions;
using PintosTechnicalApp.Interfaces.Services;

namespace PintosTechnicalApp.Controllers;

public class TeamController : Controller
{
    private readonly ITeamService _TeamService;

    public TeamController(ITeamService TeamService)
    {
        _TeamService = TeamService;
    }

    [HttpPost("Team")]
    public async Task<Guid> CreateTeam([FromBody] TeamDTO TeamDto)
    {
        return await _TeamService.Insert(TeamDto);
    }

    [HttpPut("Team/{id}")]
    public async Task<TeamDTO> UpdateTeamById([FromBody] TeamDTO TeamDto, Guid id)
    {
        if (id != TeamDto.Id) throw new NotFoundException("id not equal at dto id");
        return await _TeamService.Update(TeamDto);
    }

    [HttpDelete("Team/{id}")]
    public async Task<bool> DeleteTeamById(Guid id)
    {
        return await _TeamService.Delete(id);
    }

    [HttpGet("Team/{id}")]
    public async Task<TeamDTO> GetTeamById(Guid id)
    {
        return await _TeamService.GetById(id);
    }

    [HttpGet("Teams")]
    public async Task<List<TeamDTO>> GetTeamsByFilters()
    {
        return (List<TeamDTO>)await _TeamService.GetAll();
    }
}
