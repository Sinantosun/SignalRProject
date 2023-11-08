using AutoMapper;
using SignalR.DtoLayer.SocialMediaDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class SocialMediaMapping : Profile
    {
        public SocialMediaMapping()
        {
            CreateMap<SocailMedia, ResultSocialMediaDto>().ReverseMap();
            CreateMap<SocailMedia, GetSocialMediaDto>().ReverseMap();
            CreateMap<SocailMedia, UpdateSocialMediaDto>().ReverseMap();
            CreateMap<SocailMedia, CreateSocialMediaDto>().ReverseMap();
        }

    }
}
