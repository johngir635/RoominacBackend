using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoominacBackend.RequestModels
{
    public class PropertyImage
    {
        public int PropertyDetailId { get; set; }
        
        public byte[] Image { get; set; }
       
    }
}
