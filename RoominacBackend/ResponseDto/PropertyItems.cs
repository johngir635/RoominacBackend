using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoominacBackend.ResponseDto
{
    public class PropertyItems
    {
        public int Id { get; set; }
        public float Price { get; set; }
        public float Rating { get; set; }
        public string LocationName { get; set; }
        public byte[] Image { get; set; }
        public int Bathrooms { get; set; }
        public string Fullname { get; set; }
    }
}
