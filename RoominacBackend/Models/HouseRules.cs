// HouseRules.cs

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoominacBackend.Models
{
    public class HouseRules
    {
        [Key]
        public int Id { get; set; }

        // Foreign key for PropertyDetail
        [ForeignKey("PropertyDetail")]
        public int PropertyId { get; set; }

        
        public string Rule { get; set; }

        // Navigation property for PropertyDetail
        public virtual PropertyDetail PropertyDetail { get; set; }
    }
}
