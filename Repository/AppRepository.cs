using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimpleMessageBoard.Data;
using SimpleMessageBoard.Data.Entities;

namespace SimpleMessageBoard.Repository
{
    public class AppRepository : IAppRepository
    {
        private readonly SimpleMessageBoardContext _context;

        public AppRepository(SimpleMessageBoardContext context)
        {
            _context = context;
        }

        public async Task AddMessageAsync(Message message)
        {
            await _context.Messages.AddAsync(message);

            await _context.SaveChangesAsync();
        }

        public IQueryable<Message> GetMessages(int userId)
        {
            var messages = _context.Messages.Where(x => x.UserId == userId);

            return messages;
        }
    }
}
