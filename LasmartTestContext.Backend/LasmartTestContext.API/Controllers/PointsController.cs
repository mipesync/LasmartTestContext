using LasmartTestContext.API.Models;
using LasmartTestContext.Application.Interfaces.Repositories;
using LasmartTestContext.Dto.PointDto;
using LasmartTestContext.Dto.PointDto.ResponseDto;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LasmartTestContext.API.Controllers;

/// <summary>
/// Контроллер точек
/// </summary>
[ApiController]
[Route("points")]
[Produces("application/json")]
public class PointsController : Controller
{
    private readonly IPointRepository _pointRepository;

    public PointsController(IPointRepository pointRepository)
    {
        _pointRepository = pointRepository;
    }

    /// <summary>
    /// Получить все точки
    /// </summary>
    /// <returns><see cref="GetAllPointsResponseDto"/></returns>
    /// <response code="200">Запрос выполнен успешно</response>
    /// <response code="500">Внутренняя ошибка сервера</response>
    [HttpGet]
    [SwaggerResponse(statusCode: StatusCodes.Status200OK, type: typeof(GetAllPointsResponseDto))]
    [SwaggerResponse(statusCode: StatusCodes.Status500InternalServerError, type: typeof(ErrorModel))]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await _pointRepository.GetAllAsync();

        return Ok(result);
    }

    /// <summary>
    /// Добавить новую точку
    /// </summary>
    /// <param name="dto">Входные данные</param>
    /// <returns><see cref="AddPointResponseDto"/></returns>
    /// <response code="200">Запрос выполнен успешно</response>
    /// <response code="500">Внутренняя ошибка сервера</response>
    [HttpPost]
    [SwaggerResponse(statusCode: StatusCodes.Status200OK, type: typeof(AddPointResponseDto))]
    [SwaggerResponse(statusCode: StatusCodes.Status500InternalServerError, type: typeof(ErrorModel))]
    public async Task<IActionResult> AddAsync([FromBody] AddPointDto dto)
    {
        var result = await _pointRepository.AddAsync(dto);

        return Ok(result);
    }

    /// <summary>
    /// Изменить свойства точки
    /// </summary>
    /// <param name="dto">Входные данные</param>
    /// <response code="200">Запрос выполнен успешно</response>
    /// <response code="404">Точка не была найдена</response>
    /// <response code="500">Внутренняя ошибка сервера</response>
    [HttpPut]
    [SwaggerResponse(statusCode: StatusCodes.Status200OK, type: null)]
    [SwaggerResponse(statusCode: StatusCodes.Status404NotFound, type: typeof(ErrorModel))]
    [SwaggerResponse(statusCode: StatusCodes.Status500InternalServerError, type: typeof(ErrorModel))]
    public async Task<IActionResult> EditAsync([FromBody] EditPointDto dto)
    {
        await _pointRepository.EditAsync(dto);

        return Ok();
    }

    /// <summary>
    /// Удалить точку
    /// </summary>
    /// <param name="pointId">Идентификатор точки</param>
    /// <response code="200">Запрос выполнен успешно</response>
    /// <response code="404">Точка не была найдена</response>
    /// <response code="500">Внутренняя ошибка сервера</response>
    [HttpDelete("{pointId:int}")]
    [SwaggerResponse(statusCode: StatusCodes.Status200OK, type: null)]
    [SwaggerResponse(statusCode: StatusCodes.Status404NotFound, type: typeof(ErrorModel))]
    [SwaggerResponse(statusCode: StatusCodes.Status500InternalServerError, type: typeof(ErrorModel))]
    public async Task<IActionResult> RemoveAsync(int pointId)
    {
        await _pointRepository.RemoveAsync(pointId);

        return Ok();
    }
}