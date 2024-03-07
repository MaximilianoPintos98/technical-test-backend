using PintosTechnicalApp.DTOs;
using PintosTechnicalApp.DTOs.Filters;

namespace PintosTechnicalApp.Interfaces.Services;

public interface IPlayerService
{
    Task<Guid> Insert(PlayerPostDTO entity);
    Task<PlayerDTO> Update(PlayerDTO entity);
    Task<bool> Delete(Guid id);
    Task<PlayerDTO> GetById(Guid id);
    Task<IEnumerable<PlayerDTO>> GetByFilters(FilterPlayerDTO filterPlayerDTO);
}
