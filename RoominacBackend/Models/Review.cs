using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace RoominacBackend.Models
{
    public enum ReviewCategory
    {
        Excellent = 50,
        Good = 40,
        Average = 30,
        Poor = 20,
        Terrible = 10
    }

    public class Review
    {
        [Key]
        public int Id { get; set; }
      
        public int UserId { get; set; }
        public int? PropertyId { get; set; }
        public string ReviewText { get; set; }
        public DateTime Date { get; set; }
        public ReviewCategory Category { get; set; } // New property
        public double Rating { get; set; }
        [Display(Name = "Description")]
        public string RatingDescription { get; set; }

        [Display(Name = "Cleanliness")]
        public RatingValue Cleanliness { get; set; }

        [Display(Name = "Accuracy")]
        public RatingValue Accuracy { get; set; }

        [Display(Name = "Location")]
        public RatingValue Location { get; set; }

        [Display(Name = "Check-In")]
        public RatingValue CheckIn { get; set; }

        [Display(Name = "Value")]
        public RatingValue Value { get; set; }

        public virtual RoominacUsers RoominacUsers { get; set; }
    }
    
}