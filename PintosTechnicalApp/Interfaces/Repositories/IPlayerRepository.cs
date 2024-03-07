
using PintosTechnicalApp.DTOs;

namespace PintosTechnicalApp.Interfaces.Repositories;

public interface IPlayerRepository
{
    Task<Guid> Insert(PlayerPostDTO entity);
    Task<PlayerDTO> Update(PlayerDTO entity);
    Task<bool> Delete(Guid id);
    Task<IEnumerable<PlayerDTO>> GetAll();
    Task<PlayerDTO> GetById(Guid id);
}
