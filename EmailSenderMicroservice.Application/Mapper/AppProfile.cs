using AutoMapper;
using EmailSenderMicroservice.Application.Model;
using EmailSenderMicroservice.Domain.Models;
using System.Text.RegularExpressions;

namespace EmailSenderMicroservice.Application.Mapper
{
    public class AppProfile : Profile
    {
        public AppProfile()
        {
            //CreateMap<SettingModel, Setting>()
            //    .ForPath(d => d.Login.Value, o => o.MapFrom(s => s.Login))
            //    .ForPath(d => d.Connection.Address, o => o.MapFrom(s => s.ServerAddress))
            //    .ForPath(d => d.Connection.Port, o => o.MapFrom(s => s.ServerPort));
            //.ReverseMap();
            //CreateMap<MessageModel, Message>()
            //    .ReverseMap();

            CreateMap<Setting, SettingModel>()
                .ForMember(d => d.Login, o => o.MapFrom(s => s.Login.Value))
                .ForMember(d => d.ServerAddress, o => o.MapFrom(s => s.Connection.Address))
                .ForMember(d => d.ServerPort, o => o.MapFrom(s => s.Connection.Port));
                //.ReverseMap();

            CreateMap<Message, MessageModel>()
                .ForMember(d => d.Email, o => o.MapFrom(s => s.Email.Value))
                .ReverseMap(); 
        }
    }
}
