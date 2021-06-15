using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimpleMessageBoard.Data.Entities;
using SimpleMessageBoard.Dtos;

namespace SimpleMessageBoard.Repository
{
    public interface IAppRepository
    {
        Task AddMessageAsync(Message message);
        IQueryable<Message> GetMessages(int userId);
    }
}
