using LasmartTestContext.Domain;
using LasmartTestContext.Dto.PointDto;
using LasmartTestContext.Dto.PointDto.ResponseDto;

namespace LasmartTestContext.Application.Interfaces.Repositories;

/// <summary>
/// Интерфейс, описывающий методы взаимодействия с сущностями <see cref="Point"/>
/// </summary>
public interface IPointRepository
{
    /// <summary>
    /// Получить список точек с комментариями
    /// </summary>
    /// <returns></returns>
    Task<GetAllPointsResponseDto> GetAll();
    /// <summary>
    /// Ассинхронное добавление новой точки
    /// </summary>
    /// <param name="dto">Входные данные</param>
    /// <returns><see cref="AddPointResponseDto"/></returns>
    Task<AddPointResponseDto> AddAsync(AddPointDto dto);
    /// <summary>
    /// Ассинхронное изменение свойств точки
    /// </summary>
    /// <param name="dto">Входные данные</param>
    /// <returns></returns>
    Task EditAsync(EditPointDto dto);
    /// <summary>
    /// Ассинхронное удаление точки
    /// </summary>
    /// <param name="pointId">Идентификатор удаляемой точки</param>
    Task RemoveAsync(int pointId);
}