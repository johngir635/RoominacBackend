using RoominacBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoominacBackend.RequestModels
{
    public class ReportedSuperHostProfileDTO
    {
        public int Id { get; set; }
        public string ReportedBy { get; set; }
        public string Reason { get; set; }
        public DateTime ReportedAt { get; set; }
        public int SuperHostId { get; set; }    
        public int RoominacUserId { get; set; }
    }
}
