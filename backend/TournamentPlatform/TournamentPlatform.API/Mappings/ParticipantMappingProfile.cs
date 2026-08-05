using AutoMapper;
using TournamentPlatform.API.Model.Domain;
using TournamentPlatform.API.Model.Persistence.Entities;

namespace TournamentPlatform.API.Mappings
{
    public class ParticipantMappingProfile : Profile
    {
        public ParticipantMappingProfile() 
        { 
            CreateMap<ParticipantEntity, Participant>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Rating, opt => opt.MapFrom(src => src.Rating))
                .ForMember(dest => dest.Wins, opt => opt.MapFrom(src => src.Wins))
                .ForMember(dest => dest.Ties, opt => opt.MapFrom(src => src.Ties));

            CreateMap<Participant, ParticipantEntity>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Rating, opt => opt.MapFrom(src => src.Rating))
                .ForMember(dest => dest.Wins, opt => opt.MapFrom(src => src.Wins))
                .ForMember(dest => dest.Ties, opt => opt.MapFrom(src => src.Ties));
        }
    }
}
