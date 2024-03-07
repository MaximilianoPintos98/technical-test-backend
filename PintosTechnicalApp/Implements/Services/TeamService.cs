using PintosTechnicalApp.DTOs;
using PintosTechnicalApp.Interfaces.Repositories;
using PintosTechnicalApp.Interfaces.Services;

namespace PintosTechnicalApp.Implements.Services;

public class TeamService : ITeamService
{
    private readonly ITeamRepository _TeamRepository;

    public TeamService(ITeamRepository TeamRepository)
    {
        _TeamRepository = TeamRepository;
    }

    public Task<Guid> Insert(TeamDTO entity)
    {
        return _TeamRepository.Insert(entity);
    }

    public async Task<TeamDTO> Update(TeamDTO entity)
    {
        TeamDTO existingTeam = await _TeamRepository.GetById((Guid)entity.Id) ?? throw new ArgumentException($"Team: {entity.Id} Not Found");

        existingTeam.Name = entity.Name;
        existingTeam.City = entity.City;
        existingTeam.Stadium = entity.Stadium;
        existingTeam.Trainer = entity.Trainer;

        await _TeamRepository.Update(existingTeam);

        return existingTeam;
    }

    public Task<bool> Delete(Guid id)
    {
        return _TeamRepository.Delete(id);
    }

    public async Task<IEnumerable<TeamDTO>> GetAll()
    {
        return await _TeamRepository.GetAll();
    }

    public async Task<TeamDTO> GetById(Guid TeamId)
    {
        TeamDTO Team = await _TeamRepository.GetById(TeamId);

        return Team ?? throw new Exception($"No se encontró ningún jugador con el ID: {TeamId}");
    }
}
