using RoominacBackend.Models;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoominacBackend.RequestModels
{


    public class PriceDetailsRequestModel
    {
        public int PropertyId { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }

}