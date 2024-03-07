using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PintosTechnicalApp.DTOs;
using PintosTechnicalApp.DTOs.Filters;
using PintosTechnicalApp.Entities;
using PintosTechnicalApp.Exceptions;
using PintosTechnicalApp.Interfaces.Services;

namespace PintosTechnicalApp.Controllers;

public class PlayerController : Controller
{
    private readonly IPlayerService _playerService;
    private readonly IMapper _mapper;

    public PlayerController(IPlayerService playerService, IMapper mapper)
    {
        _playerService = playerService;
        _mapper = mapper;
    }

    [HttpPost("Player")]
    public async Task<Guid> CreatePlayer([FromBody] PlayerPostDTO playerDto)
    {
        return await _playerService.Insert(playerDto);
    }

    [HttpPut("Player/{id}")]
    public async Task<PlayerDTO> UpdatePlayerById([FromBody] PlayerDTO playerDto, Guid id)
    {
        if (id != playerDto.Id) throw new NotFoundException("id not equal at dto id");
        return await _playerService.Update(playerDto);
    }

    [HttpDelete("Player/{id}")]
    public async Task<bool> DeletePlayerById(Guid id)
    {
        return await _playerService.Delete(id);
    }

    [HttpGet("Player/{id}")]
    public async Task<PlayerDTO> GetPlayerById(Guid id)
    {
        return await _playerService.GetById(id);
    }

    [HttpGet("Players")]
    public async Task<List<PlayerDTO>> GetPlayersByFilters([FromQuery] FilterPlayerDTO filters)
    {
        return (List<PlayerDTO>)await _playerService.GetByFilters(filters);
    }
}
