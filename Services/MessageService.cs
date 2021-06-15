using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SimpleMessageBoard.Data.Entities;
using SimpleMessageBoard.Dtos;
using SimpleMessageBoard.Repository;
using SimpleMessageBoard.Services.Interfaces;

namespace SimpleMessageBoard.Services
{
    public class MessageService : IMessageService
    {
        private readonly IAppRepository _repository;
        private readonly IMapper _mapper;

        public MessageService(IAppRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<MessageDto> AddMessageAsync(MessageDto messageDto)
        {
            var message = _mapper.Map<MessageDto, Message>(messageDto);

            message.DateTime = DateTime.Now;

            await _repository.AddMessageAsync(message);

            return _mapper.Map<Message, MessageDto>(message);
        }

        public IEnumerable<MessageDto> GetMessagesByUserId(int userId)
        {
            var messages = _repository.GetMessages(userId)
                .OrderByDescending(x => x.DateTime);

            return _mapper.Map<IEnumerable<Message>, IEnumerable<MessageDto>>(messages);
        }
    }
}
