using AutoMapper;
using SimpleMessageBoard.Data.Entities;
using SimpleMessageBoard.Dtos;

namespace SimpleMessageBoard
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<MessageDto, Message>()
                .ReverseMap();
        }
    }
}
