using AutoMapper;
using CqrsMediator.Entities.DbSet;
using CqrsMediator.Entities.Dtos.Requests;
using CqrsMediator.Entities.Dtos.Responses;

namespace CqrsMediator.Api.MappingProfile;

public class DomainToResponse : Profile
{
    public DomainToResponse()
    {
        CreateMap<Achievements, DriverAchievementResponse>()
          .ForMember(dest => dest.Wins,
              opt => opt.MapFrom(src => src.RaceWins));

        CreateMap<Driver, GetDriverResponse>()
            .ForMember(dest => dest.FullName,
                opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));
    }
}
