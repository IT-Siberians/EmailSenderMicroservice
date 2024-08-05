using AutoMapper;
using EmailSenderMicroservice.Application.Model;
using EmailSenderMicroservice.Domain.Models;

namespace EmailSenderMicroservice.Application.Mapper
{
    public class AppProfile : Profile
    {
        public AppProfile()
        {
            CreateMap<SettingModel, Setting>().ReverseMap();
            CreateMap<MessageModel, Message>().ReverseMap();
        }
    }
}
