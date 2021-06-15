using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleMessageBoard.Dtos
{
    public class MessageDto
    {
        public int UserId { get; set; }

        public string SentMessage { get; set; }

        public DateTime DateTime { get; set; }
    }
}
