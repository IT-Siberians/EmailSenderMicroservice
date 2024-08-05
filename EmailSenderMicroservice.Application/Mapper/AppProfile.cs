using AutoMapper;
using EmailSenderMicroservice.Application.Model;
using EmailSenderMicroservice.Domain.Models;

namespace EmailSenderMicroservice.Application.Mapper
{
    public class AppProfile : Profile
    {
        public AppProfile()
        {
            CreateMap<SettingModel, Setting>()
                .ForPath(d => d.Login.Value, o => o.MapFrom(s => s.Login))
                .ForPath(d => d.Connection.Address, o => o.MapFrom(s => s.ServerAddress))
                .ForPath(d => d.Connection.Port, o => o.MapFrom(s => s.ServerPort));
            //.ReverseMap();
            CreateMap<MessageModel, Message>()
                .ReverseMap();
        }
    }
}
