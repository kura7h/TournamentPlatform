using AutoMapper;
using TournamentPlatform.API.Model.Domain;
using TournamentPlatform.API.Model.Persistence.Entities;

namespace TournamentPlatform.API.Mappings
{
    public class MatchMappingProfile : Profile
    {
        public MatchMappingProfile() 
        {
            CreateMap<MatchEntity, Match>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Participant1, opt => opt.MapFrom(src => src.Participant1))
                .ForMember(dest => dest.Participant2, opt => opt.MapFrom(src => src.Participant2))
                .ForMember(dest => dest.Winner, opt => opt.MapFrom(src => src.Winner));
            //.ForMember(dest => dest.Tournament, opt => opt.MapFrom(src => src.TournamentId));

            CreateMap<Match, MatchEntity>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Participant1, opt => opt.MapFrom(src => src.Participant1))
                .ForMember(dest => dest.Participant2, opt => opt.MapFrom(src => src.Participant2))
                .ForMember(dest => dest.Winner, opt => opt.MapFrom(src => src.Winner));
                //.ForMember(dest => dest.TournamentId, opt => opt.MapFrom(src => src.TournamentId));
        }
    }
}
