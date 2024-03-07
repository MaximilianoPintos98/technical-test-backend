using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PintosTechnicalApp.Config;
using PintosTechnicalApp.DTOs;
using PintosTechnicalApp.Entities;
using PintosTechnicalApp.Exceptions;
using PintosTechnicalApp.Interfaces.Repositories;

namespace PintosTechnicalApp.Implements.Repositories;

public class TeamRepository : ITeamRepository
{
    private readonly AppDbContext _appDbContext;
    private readonly IMapper _mapper;

    public TeamRepository(AppDbContext appDbContext, IMapper mapper)
    {
        _appDbContext = appDbContext;
        _mapper = mapper;
    }

    public async Task<Guid> Insert(TeamDTO TeamDto)
    {
        Team Team = _mapper.Map<Team>(TeamDto);
        _appDbContext.Teams.Add(Team);
        await _appDbContext.SaveChangesAsync();

        return Team.Id;
    }

    public async Task<TeamDTO> Update(TeamDTO TeamDto)
    {
        Team TeamToUpdate = _mapper.Map<Team>(TeamDto);

        if (TeamToUpdate == null)
        {
            throw new NotFoundException($"Entity {TeamDto.Id} not found");
        }

        _appDbContext.Teams.Update(TeamToUpdate);
        await _appDbContext.SaveChangesAsync();

        return TeamDto;
    }

    public async Task<bool> Delete(Guid id)
    {
        Team? TeamToDelete = await _appDbContext.Teams.Where(w => w.Id == id).FirstOrDefaultAsync();

        if (TeamToDelete == null)
        {
            throw new NotFoundException($"Entity with id: {id} -> Not found");
        }

        _appDbContext.Teams.Remove(TeamToDelete);
        var res = await _appDbContext.SaveChangesAsync();

        return res > 0;
    }

    public async Task<IEnumerable<TeamDTO>> GetAll()
    {
        List<TeamDTO> Teams = await _appDbContext.Teams.Where(w => w.Enabled).ProjectTo<TeamDTO>(_mapper.ConfigurationProvider).ToListAsync();
        return Teams;
    }

    public async Task<TeamDTO> GetById(Guid id)
    {
        TeamDTO? Team = await _appDbContext.Teams.Where(w => w.Id == id && w.Enabled).ProjectTo<TeamDTO>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();
        return Team;
    }
}
