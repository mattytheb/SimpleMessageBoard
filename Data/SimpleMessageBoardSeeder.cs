using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using SimpleMessageBoard.Data.Entities;

namespace SimpleMessageBoard.Data
{
    public class SimpleMessageBoardSeeder
    {
        private readonly SimpleMessageBoardContext _context;
        private readonly IWebHostEnvironment _env;

        public SimpleMessageBoardSeeder(SimpleMessageBoardContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public void Seed()
        {
            _context.Database.EnsureCreated();

            if (!_context.Messages.Any())
            {
                var filePath = Path.Combine(_env.ContentRootPath, "Data/exampleMessage.json");
                var seedJson = File.ReadAllText(filePath);
                var messages = JsonConvert.DeserializeObject<IEnumerable<Message>>(seedJson);

                _context.Messages.AddRange(messages);

                _context.SaveChanges();

            }
        }
    }
}

