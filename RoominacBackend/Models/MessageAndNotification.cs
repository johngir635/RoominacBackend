using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoominacBackend.Models
{
    ///Review & Notification
    public class Message
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime SentAt { get; set; }     
 
        public int SenderId { get; set; }       
      
        public int RecipientId { get; set; }    

        // Indicates whether the message has been deleted by sender
        public bool SenderDeleted { get; set; }

        // Deletion time by sender
        public DateTime? SenderDeletedAt { get; set; }

        // Indicates whether the message has been deleted by recipient
        public bool RecipientDeleted { get; set; }

        // Deletion time by recipient
        public DateTime? RecipientDeletedAt { get; set; }
    }

    public class Notification
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }
        public int SenderId { get; set; }      
        public int RecipientId { get; set; }    

        // Indicates whether the notification has been deleted by user
        public bool UserDeleted { get; set; }

        // Deletion time by user
        public DateTime? UserDeletedAt { get; set; }
    }

}
