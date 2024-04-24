using RoominacBackend.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoominacBackend.RequestModels
{
    public class WishListdto
    {
        
        public int Id { get; set; }
              
        public int UserId { get; set; }  // Foreign key for the user who added the property to wishlist       

        public int PropertyId { get; set; }  // Foreign key for the PropertyItem
    }
}
