using AutoMapper;
using DTOLayer.DTOs.AnnouncementDTOs;
using DTOLayer.DTOs.AppUserDtos;
using DTOLayer.DTOs.ContactDTOs;
using EntityLayer.Concrete;

namespace Traversal_Reservation.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<AnnouncementAddDTO, Announcement>();
            CreateMap<Announcement, AnnouncementAddDTO> ();

            CreateMap<AppUserRegisterDTO, AppUser> ();
            CreateMap<AppUser, AppUserRegisterDTO> ();

            CreateMap<AppUserLoginDTO, AppUser> ();
            CreateMap<AppUser, AppUserLoginDTO> ();

            CreateMap<AnnouncementListDTO, Announcement>();
            CreateMap<Announcement, AnnouncementListDTO>();
            
            CreateMap<AnnouncementUpdateDTO, Announcement>();
            CreateMap<Announcement, AnnouncementUpdateDTO>();

            CreateMap<SendMessageDTO, ContactUs>().ReverseMap();
        }
    }
}
