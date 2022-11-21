using ChatHub.Config;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChatHub.Models
{
    public class Message
    {
        private DBStore store;
        public int Id { get; set; }
       
        [Required]
        public string Username { get; set; }
        [Required]
        public string Text { get; set; }
        public DateTime Date { get; set; }

        public string UserID { get; set; }
        public virtual AppUser Sender { get; set; }
    }
}
