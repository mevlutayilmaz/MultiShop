using AutoMapper;
using MultiShop.Message.DAL.Entities;
using MultiShop.Message.DTOs;

namespace MultiShop.Message.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<UserMessage, ResultMessageDTO>().ReverseMap();
            CreateMap<UserMessage, ResultInboxMessageDTO>().ReverseMap();
            CreateMap<UserMessage, ResultSendboxMessageDTO>().ReverseMap();
            CreateMap<UserMessage, GetByIdMessageDTO>().ReverseMap();
            CreateMap<UserMessage, CreateMessageDTO>().ReverseMap();
            CreateMap<UserMessage, UpdateMessageDTO>().ReverseMap();
        }
    }
}
