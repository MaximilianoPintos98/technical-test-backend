using PintosTechnicalApp.DTOs;
using PintosTechnicalApp.DTOs.Filters;
using PintosTechnicalApp.Interfaces.Repositories;
using PintosTechnicalApp.Interfaces.Services;

namespace PintosTechnicalApp.Implements.Services;

public class PlayerService : IPlayerService
{
    private readonly IPlayerRepository _playerRepository;

    public PlayerService(IPlayerRepository playerRepository)
    {
        _playerRepository = playerRepository;
    }

    public Task<Guid> Insert(PlayerPostDTO entity)
    {
        return _playerRepository.Insert(entity);
    }

    public async Task<PlayerDTO> Update(PlayerDTO entity)
    {
        PlayerDTO existingPlayer = await _playerRepository.GetById((Guid)entity.Id) ?? throw new ArgumentException($"Player: {entity.Id} Not Found");

        existingPlayer.FirstName = entity.FirstName;
        existingPlayer.LastName = entity.LastName;
        existingPlayer.Nationality = entity.Nationality;
        existingPlayer.Position = entity.Position;
        existingPlayer.TeamId = entity.TeamId;
        existingPlayer.Team = entity.Team;

        await _playerRepository.Update(existingPlayer);

        return existingPlayer;
    }

    public Task<bool> Delete(Guid id)
    {
        return _playerRepository.Delete(id);
    }

    public async Task<IEnumerable<PlayerDTO>> GetByFilters(FilterPlayerDTO filterPlayerDTO)
    {
        IEnumerable<PlayerDTO> players = await _playerRepository.GetAll();

        if (filterPlayerDTO != null)
        {
            players = players
            .Where(player =>
                (string.IsNullOrEmpty(filterPlayerDTO.FirstName) || player.FirstName.Contains(filterPlayerDTO.FirstName)) &&
                (string.IsNullOrEmpty(filterPlayerDTO.LastName) || player.LastName.Contains(filterPlayerDTO.LastName)) &&
                (bool)player.Enabled
            );
        }

        return players.ToList();
    }

    public async Task<PlayerDTO> GetById(Guid playerId)
    {
        PlayerDTO player = await _playerRepository.GetById(playerId);

        return player ?? throw new Exception($"No se encontró ningún jugador con el ID: {playerId}");
    }
}
