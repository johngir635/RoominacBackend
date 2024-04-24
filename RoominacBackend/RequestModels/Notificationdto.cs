using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoominacBackend.RequestModels
{
    public class Notificationdto
    {

        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public int SenderId { get; set; }
        public int RecipientId { get; set; }
        public bool UserDeleted { get; set; }
        public DateTime? UserDeletedAt { get; set; }
    }
}
