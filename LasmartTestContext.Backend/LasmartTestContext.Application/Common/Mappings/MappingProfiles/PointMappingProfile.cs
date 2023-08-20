using AutoMapper;
using LasmartTestContext.Domain;
using LasmartTestContext.Dto.PointDto;
using LasmartTestContext.Dto.PointDto.ResponseDto;

namespace LasmartTestContext.Application.Common.Mappings.MappingProfiles;

/// <summary>
/// Профиль конфигурации маппинга сущностей точек
/// </summary>
public class PointMappingProfile : Profile
{
    public PointMappingProfile()
    {
        CreateMap<Point, PointLookupDto>(MemberList.Source);

        CreateMap<AddPointDto, Point>(MemberList.Source);

        CreateMap<EditPointDto, Point>(MemberList.Source);
    }
}