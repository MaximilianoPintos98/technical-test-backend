using PintosTechnicalApp.DTOs;

namespace PintosTechnicalApp.Interfaces.Services;

public interface ITeamService
{
    Task<Guid> Insert(TeamDTO entity);
    Task<TeamDTO> Update(TeamDTO entity);
    Task<bool> Delete(Guid id);
    Task<TeamDTO> GetById(Guid id);
    Task<IEnumerable<TeamDTO>> GetAll();
}