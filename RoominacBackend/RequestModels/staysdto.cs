using RoominacBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoominacBackend.RequestModels
{
    public class staysdto
    {
        public int Id { get; set; }
        public DateTime When { get; set; }
        public int NoOfGuset { get; set; }
        public int RoominacUserId { get; set; }       
        public ExactDaysPlus ExactDaysPlusMinus { get; set; }
        public int PropertyItemId { get; set; }
      
    }
}
