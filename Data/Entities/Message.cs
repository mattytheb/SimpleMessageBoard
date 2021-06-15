using System;
using System.ComponentModel.DataAnnotations;

namespace SimpleMessageBoard.Data.Entities
{
    public class Message
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        [MaxLength(500)]
        public string SentMessage { get; set; }

        public DateTime DateTime { get; set; }
    }
}
