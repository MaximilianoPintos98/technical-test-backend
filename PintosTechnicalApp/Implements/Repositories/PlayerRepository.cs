using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PintosTechnicalApp.Config;
using PintosTechnicalApp.DTOs;
using PintosTechnicalApp.Entities;
using PintosTechnicalApp.Exceptions;
using PintosTechnicalApp.Interfaces.Repositories;

namespace PintosTechnicalApp.Implements.Repositories;

public class PlayerRepository : IPlayerRepository
{
    private readonly AppDbContext _appDbContext;
    private readonly IMapper _mapper;

    public PlayerRepository(AppDbContext appDbContext, IMapper mapper)
    {
        _appDbContext = appDbContext;
        _mapper = mapper;
    }

    public async Task<Guid> Insert(PlayerPostDTO playerDto)
    {
        Player player = _mapper.Map<Player>(playerDto);
        
        player.Enabled = true; 

        _appDbContext.Players.Add(player);
        await _appDbContext.SaveChangesAsync();

        return player.Id;
    }

    public async Task<PlayerDTO> Update(PlayerDTO playerDto)
    {
        Player playerToUpdate = _mapper.Map<Player>(playerDto);

        if (playerToUpdate == null)
        {
            throw new NotFoundException($"Entity {playerDto.Id} not found");
        }

        _appDbContext.Players.Update(playerToUpdate);
        await _appDbContext.SaveChangesAsync();

        return playerDto;
    }

    public async Task<bool> Delete(Guid id)
    {
        Player? playerToDelete = await _appDbContext.Players.Where(w => w.Id == id).FirstOrDefaultAsync();

        if (playerToDelete == null)
        {
            throw new NotFoundException($"Entity with id: {id} -> Not found");
        }

        _appDbContext.Players.Remove(playerToDelete);
        var res = await _appDbContext.SaveChangesAsync();

        return res > 0;
    }

    public async Task<IEnumerable<PlayerDTO>> GetAll()
    {
        List<PlayerDTO> players = await _appDbContext.Players.Where(w => w.Enabled).ProjectTo<PlayerDTO>(_mapper.ConfigurationProvider).ToListAsync();
        return players;
    }

    public async Task<PlayerDTO> GetById(Guid id)
    {
        PlayerDTO? player = await _appDbContext.Players.Include(i => i.Team).Where(w => w.Id == id && w.Enabled).ProjectTo<PlayerDTO>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();
        return player;
    }
}
