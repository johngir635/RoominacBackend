using RoominacBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoominacBackend.RequestModels
{
    public class HostUserDto
    {
        public int Id { get; set; }
        public bool IsSuperHost { get; set; }
        public RatingValue HostRating { get; set; }
        public int TotalReviews { get; set; }
        public bool CurrentlyHosting { get; set; }
        public byte[] ProfileImage { get; set; }
        public string Languages { get; set; }
        public string Location { get; set; }
        public string Job { get; set; }
        public string Interests { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Education { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Identity { get; set; }
        public int? PropertyDetailId { get; set; }
       
    }
}
