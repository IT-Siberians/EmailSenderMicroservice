using AutoMapper;
using EmailSenderMicroservice.Application.Models.Message;
using EmailSenderMicroservice.Application.Models.Setting;
using EmailSenderMicroservice.Domain.Entities;

namespace EmailSenderMicroservice.Application.Mapper
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<Setting, SettingModel>()
                .ForMember(d => d.Login, o => o.MapFrom(s => s.Login.Value))
                .ForMember(d => d.ServerAddress, o => o.MapFrom(s => s.Connection.Address))
                .ForMember(d => d.ServerPort, o => o.MapFrom(s => s.Connection.Port));

            CreateMap<Message, MessageModel>()
                .ForMember(d => d.Email, o => o.MapFrom(s => s.Email.Value))
                .ReverseMap(); 
        }
    }
}
