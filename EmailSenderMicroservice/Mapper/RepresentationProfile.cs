using AutoMapper;
using EmailSenderMicroservice.Application.Models.Message;
using EmailSenderMicroservice.Application.Models.Setting;
using EmailSenderMicroservice.Contracts.Message;
using EmailSenderMicroservice.Contracts.Setting;

namespace EmailSenderMicroservice.Mapper
{
    public class RepresentationProfile : Profile
    {
        public RepresentationProfile()
        {
            CreateMap<SettingResponse, SettingModel>().ReverseMap();
            CreateMap<SettingRequest, AddSettingModel>().ReverseMap();
            CreateMap<MessageResponse, MessageModel>().ReverseMap();
        }
    }
}
