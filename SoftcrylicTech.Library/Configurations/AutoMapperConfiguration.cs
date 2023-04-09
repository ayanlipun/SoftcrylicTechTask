using SoftcrylicTech.Library.DBEntities;
using SoftcrylicTech.Model;

namespace SoftcrylicTech.Library.Configurations
{
    public class AutoMapperConfiguration : AutoMapper.Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<tblSpeakerEntity, SpeakerModel>()
                .ForPath(dest => dest.Name, map => map.MapFrom(src => src.Name))
                .ForPath(dest => dest.Bio, map => map.MapFrom(src => src.Bio))
                .ForPath(dest => dest.SocialLinks, map => map.MapFrom(src => src.SocialLinks));


            CreateMap<tblEventEntity, EventModel>()
              .ForPath(dest => dest.Title, map => map.MapFrom(src => src.Title))
              .ForPath(dest => dest.Description, map => map.MapFrom(src => src.Description))
              .ForPath(dest => dest.Date, map => map.MapFrom(src => src.Date))
               .ForPath(dest => dest.ModeOfEvent, map => map.MapFrom(src => src.ModeOfEvent))
              .ForPath(dest => dest.Venue, map => map.MapFrom(src => src.Venue))
              .ForPath(dest => dest.Website, map => map.MapFrom(src => src.Website))
              .ForPath(dest => dest.LinkForDetails, map => map.MapFrom(src => src.LinkForDetails))
              .ForPath(dest => dest.SpeakerId, map => map.MapFrom(src => src.SpeakerId));
        }
    }
}
