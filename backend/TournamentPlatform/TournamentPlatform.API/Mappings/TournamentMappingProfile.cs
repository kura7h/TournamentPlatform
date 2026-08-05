using AutoMapper;
using TournamentPlatform.API.Model.Domain;
using TournamentPlatform.API.Model.Persistence.Entities;

namespace TournamentPlatform.API.Mappings
{
    public class TournamentMappingProfile : Profile
    {
        public TournamentMappingProfile() 
        {
            CreateMap<TournamentEntity, Tournament>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Participants, opt => opt.MapFrom(src => src.Participants))
                .ForMember(dest => dest.Matches, opt => opt.MapFrom(src => src.Matches));
            CreateMap<Tournament, TournamentEntity>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Participants, opt => opt.MapFrom(src => src.Participants))
                .ForMember(dest => dest.Matches, opt => opt.MapFrom(src => src.Matches));
        }
    }
}
