using LasmartTestContext.Dto.CommentDto;
using LasmartTestContext.Dto.CommentDto.ResponseDto;

namespace LasmartTestContext.Application.Interfaces.Repositories;

/// <summary>
/// Интерфейс, описывающий методы взаимодействия с комментариями
/// </summary>
public interface ICommentRepository
{
    /// <summary>
    /// Асинхронно добавить новый комментарий к точке
    /// </summary>
    /// <param name="dto">Входные данные</param>
    /// <returns><see cref="AddCommentResponseDto"/></returns>
    Task<AddCommentResponseDto> AddCommentAsync(AddCommentDto dto);
    /// <summary>
    /// Асинхронно редактировать комментарий
    /// </summary>
    /// <param name="dto">Входные данные</param>
    Task EditCommentAsync(EditCommentDto dto);
    /// <summary>
    /// Асинхронно удалить комментарий
    /// </summary>
    /// <param name="commentId">Идентификатор комментария</param>
    Task RemoveCommentAsync(int commentId);
}