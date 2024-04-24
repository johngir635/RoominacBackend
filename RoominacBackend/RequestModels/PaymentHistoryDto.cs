using RoominacBackend.Models;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoominacBackend.RequestModels
{
    public class PaymentHistoryDto
    {

        public int Id { get; set; }

        public int RoominacUserId { get; set; }         

        public int PropertyId { get; set; } 


        public decimal Amount { get; set; } 

        public DateTime PaymentDate { get; set; } 

        public string PaymentMethod { get; set; } 

        public string TransactionId { get; set; } 

        public string Status { get; set; }
    }
}
