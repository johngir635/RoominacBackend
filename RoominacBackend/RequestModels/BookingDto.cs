using RoominacBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoominacBackend.RequestModels
{
    public class BookingDto
    {
        public int Id { get; set; }
        public bool Instantbooking { get; set; }
        public bool SelfCheckIn { get; set; }
        public bool FreeCancelation { get; set; }
        public int PropertyItemId { get; set; }        
    }
}
