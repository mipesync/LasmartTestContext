using AutoMapper;
using LasmartTestContext.Domain;
using LasmartTestContext.Dto.PointDto.ResponseDto;

namespace LasmartTestContext.Application.Common.Mappings.MappingProfiles;

/// <summary>
/// Профиль конфигурации маппинга сущностей комментариев
/// </summary>
public class CommentMappingProfile : Profile
{
    public CommentMappingProfile()
    {
        CreateMap<Comment, CommentLookupDto>(MemberList.Source);
    }
}