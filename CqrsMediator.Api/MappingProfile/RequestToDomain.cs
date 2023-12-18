using AutoMapper;
using CqrsMediator.Entities.DbSet;
using CqrsMediator.Entities.Dtos.Requests;

namespace CqrsMediator.Api.MappingProfile;

public class RequestToDomain : Profile
{
    public RequestToDomain()
    {
        CreateMap<CreateDriverAchievementRequest, Achievements>()
            .ForMember(dest => dest.RaceWins,
                opt => opt.MapFrom(src => src.Wins))
            .ForMember(dest => dest.Status,
                opt => opt.MapFrom(src => 1))
            .ForMember(dest => dest.AddedDate,
                opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.UpdatedDate,
                opt => opt.MapFrom(src => DateTime.UtcNow));

        CreateMap<CreateDriverAchievementRequest, Achievements>()
           .ForMember(dest => dest.RaceWins,
               opt => opt.MapFrom(src => src.Wins))
           .ForMember(dest => dest.UpdatedDate,
               opt => opt.MapFrom(src => DateTime.UtcNow));

        CreateMap<CreateDriverRequest, Driver>()
            .ForMember(dest => dest.Status,
                opt => opt.MapFrom(src => 1))
            .ForMember(dest => dest.AddedDate,
                opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.UpdatedDate,
                opt => opt.MapFrom(src => DateTime.UtcNow));

        CreateMap<UpdateDriverRequest, Driver>()
            .ForMember(
                dest => dest.UpdatedDate,
                opt => opt.MapFrom(src => DateTime.UtcNow));
    }
}
