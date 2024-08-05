using AutoMapper;
using EmailSenderMicroservice.Application.Model;
using EmailSenderMicroservice.Contracts.Message;
using EmailSenderMicroservice.Contracts.Setting;

namespace EmailSenderMicroservice.Mapper
{
    public class RepProfile : Profile
    {
        public RepProfile()
        {
            CreateMap<SettingResponse, SettingModel>().ReverseMap();
            CreateMap<SettingRequest, SettingAddModel>().ReverseMap();
            CreateMap<MessageResponse, MessageModel>().ReverseMap();
        }
    }
}
