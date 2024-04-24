using RoominacBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoominacBackend.RequestModels
{
    public class PaymentMethodDto
    {
        public string Method { get; set; }

        public string CardNumber { get; set; }

        public PaymentType PaymentType { get; set; }

        public DateTime ExpiryDate { get; set; }

        public bool AcceptsRefunds { get; set; }

        public bool AcceptsCancellations { get; set; }

        public bool AcceptsModifications { get; set; }

        public int RoominacUserId { get; set; }
       
    }
}
