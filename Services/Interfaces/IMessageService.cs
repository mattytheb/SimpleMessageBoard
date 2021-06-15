using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimpleMessageBoard.Data.Entities;
using SimpleMessageBoard.Dtos;

namespace SimpleMessageBoard.Services.Interfaces
{
    public interface IMessageService
    {
        Task<MessageDto> AddMessageAsync(MessageDto messageDto);
        IEnumerable<MessageDto> GetMessagesByUserId(int userId);
    }
}
