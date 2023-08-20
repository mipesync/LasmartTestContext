using LasmartTestContext.API.Models;
using LasmartTestContext.Application.Interfaces.Repositories;
using LasmartTestContext.Dto.CommentDto;
using LasmartTestContext.Dto.CommentDto.ResponseDto;
using LasmartTestContext.Dto.PointDto;
using LasmartTestContext.Dto.PointDto.ResponseDto;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LasmartTestContext.API.Controllers;

/// <summary>
/// Контроллер комментариев
/// </summary>
[ApiController]
[Route("comments")]
[Produces("application/json")]
public class CommentsController : Controller
{
    private readonly ICommentRepository _commentRepository;

    public CommentsController(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }

    /// <summary>
    /// Добавить новый комментарий
    /// </summary>
    /// <param name="dto">Входные данные</param>
    /// <returns><see cref="AddCommentResponseDto"/></returns>
    /// <response code="200">Запрос выполнен успешно</response>
    /// <response code="500">Внутренняя ошибка сервера</response>
    [HttpPost]
    [SwaggerResponse(statusCode: StatusCodes.Status200OK, type: typeof(AddCommentResponseDto))]
    [SwaggerResponse(statusCode: StatusCodes.Status500InternalServerError, type: typeof(ErrorModel))]
    public async Task<IActionResult> AddAsync([FromBody] AddCommentDto dto)
    {
        var result = await _commentRepository.AddCommentAsync(dto);

        return Ok(result);
    }

    /// <summary>
    /// Изменить свойства комментария
    /// </summary>
    /// <param name="dto">Входные данные</param>
    /// <response code="200">Запрос выполнен успешно</response>
    /// <response code="404">Комментарий не был найден</response>
    /// <response code="500">Внутренняя ошибка сервера</response>
    [HttpPut]
    [SwaggerResponse(statusCode: StatusCodes.Status200OK, type: null)]
    [SwaggerResponse(statusCode: StatusCodes.Status404NotFound, type: typeof(ErrorModel))]
    [SwaggerResponse(statusCode: StatusCodes.Status500InternalServerError, type: typeof(ErrorModel))]
    public async Task<IActionResult> EditAsync([FromBody] EditCommentDto dto)
    {
        await _commentRepository.EditCommentAsync(dto);

        return Ok();
    }

    /// <summary>
    /// Удалить комментарий
    /// </summary>
    /// <param name="commentId">Идентификатор комментария</param>
    /// <response code="200">Запрос выполнен успешно</response>
    /// <response code="404">Комментарий не был найден</response>
    /// <response code="500">Внутренняя ошибка сервера</response>
    [HttpDelete("{commentId:int}")]
    [SwaggerResponse(statusCode: StatusCodes.Status200OK, type: null)]
    [SwaggerResponse(statusCode: StatusCodes.Status404NotFound, type: typeof(ErrorModel))]
    [SwaggerResponse(statusCode: StatusCodes.Status500InternalServerError, type: typeof(ErrorModel))]
    public async Task<IActionResult> RemoveAsync(int commentId)
    {
        await _commentRepository.RemoveCommentAsync(commentId);

        return Ok();
    }
}