using AutoMapper;
using LasmartTestContext.Application.Common.Exceptions;
using LasmartTestContext.Application.Interfaces;
using LasmartTestContext.Application.Interfaces.Repositories;
using LasmartTestContext.Domain;
using LasmartTestContext.Dto.CommentDto;
using LasmartTestContext.Dto.CommentDto.ResponseDto;
using Microsoft.EntityFrameworkCore;

namespace LasmartTestContext.Application.Common.Repositories;

/// <summary>
/// Репозиторий с методами взаимодействия над <see cref="Comment"/>
/// </summary>
public class CommentRepository : ICommentRepository
{
    private readonly IDBContext _dbContext;
    private readonly IMapper _mapper;

    public CommentRepository(IDBContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<AddCommentResponseDto> AddCommentAsync(AddCommentDto dto)
    {
        var point = await _dbContext.Points.FirstOrDefaultAsync(u => u.Id == dto.PointId, CancellationToken.None);

        if (point is null)
            throw new NotFoundException("Точка не найдена"); 
        
        var comment = _mapper.Map<Comment>(dto);
        comment.Point = point;

        var addedComment = await _dbContext.Comments.AddAsync(comment, CancellationToken.None);

        await _dbContext.SaveChangesAsync(CancellationToken.None);

        return new AddCommentResponseDto { Id = addedComment.Entity.Id };
    }

    public async Task EditCommentAsync(EditCommentDto dto)
    {
        var comment = await _dbContext.Comments.FirstOrDefaultAsync(u => u.Id == dto.Id, CancellationToken.None);

        if (comment is null)
            throw new NotFoundException("Комментарий не был найден");

        comment = _mapper.Map(dto, comment);

        await _dbContext.SaveChangesAsync(CancellationToken.None);
    }

    public async Task RemoveCommentAsync(int commentId)
    {
        var comment = await _dbContext.Comments.FirstOrDefaultAsync(u => u.Id == commentId, CancellationToken.None);

        if (comment is null)
            throw new NotFoundException("Комментарий не был найден");

        _dbContext.Comments.Remove(comment);
        await _dbContext.SaveChangesAsync(CancellationToken.None);
    }
}