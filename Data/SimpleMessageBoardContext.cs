using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimpleMessageBoard.Data.Entities;

namespace SimpleMessageBoard.Data
{
    public class SimpleMessageBoardContext : DbContext
    {
        public SimpleMessageBoardContext(DbContextOptions<SimpleMessageBoardContext> options) : base(options)
        {
        }

        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
