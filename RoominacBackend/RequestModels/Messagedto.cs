using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoominacBackend.RequestModels
{
    public class Messagedto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime SentAt { get; set; }
        public int SenderId { get; set; }
        public int RecipientId { get; set; }
        public bool SenderDeleted { get; set; }
        public DateTime? SenderDeletedAt { get; set; }
        public bool RecipientDeleted { get; set; }
        public DateTime? RecipientDeletedAt { get; set; }
    }
}

