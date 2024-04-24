using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoominacBackend.ResponseDto
{
    public class PropertyDetialsDTO
    {
        public int Id { get; set; }
        public int RoominacUserId { get; set; }
        public string LocationName { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public float Distance { get; set; }
        public int NoOfBeds { get; set; }
        public int Bathrooms { get; set; }
        public bool WiFi { get; set; }
        public bool TV { get; set; }
        public bool Kitchen { get; set; }
        public bool WashingMachine { get; set; }
        public bool FreeParking { get; set; }
        public bool PaidParking { get; set; }
        public bool AirConditioning { get; set; }
        public bool DedicatedSpaces { get; set; }
        public bool StepFreeEntrance { get; set; }
        public bool Widerthan32inch { get; set; }
        public bool StepFreePath { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public float Rating { get; set; }
        public float Price { get; set; }
        public int Nights { get; set; }
        public int PropertyType { get; set; }        
        
    }


}
