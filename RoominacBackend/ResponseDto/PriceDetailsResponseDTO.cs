using RoominacBackend.Models;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoominacBackend.RequestModels
{


    public class PriceDetailsResponseDTO
    {

        public float PricePerNight { get; set; }
        public int Nights { get; set; }
        public float LongStayDiscount { get; set; }
        public float TotalPrice { get; set; }


    }


}