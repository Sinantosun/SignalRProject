using AutoMapper;
using SignalR.DtoLayer.MessagesDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class MessagesMapping:Profile
    {
        public MessagesMapping()
        {
            CreateMap<Messages, ResultMesaggesDto>().ReverseMap();
            CreateMap<Messages, CreateMessagesDto>().ReverseMap();
            CreateMap<Messages, UpdateMessageDto>().ReverseMap();
        }
    }
}
