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
    //Property details 
    //PropertyDetail
    public class PropertyDetail
    {
        [Key]
        public int Id { get; set; }
        // Foreign key for RoominacUsers
        [ForeignKey("RoominacUsers")]
        public int RoominacUserId { get; set; }
        // Location information  
        [Display(Name = "Location Name")]
        public string LocationName { get; set; }
        // Location information  
        [Display(Name = "Latitude")]
        public float Latitude { get; set; }
        // Location information  
        [Display(Name = "Longitude")]
        public float Longitude { get; set; }
        [Display(Name = "Distance")]
        public float Distance { get; set; }
        [Display(Name = "Number Of Beds")]
        public int NoOfBeds { get; set; }
        [Display(Name = "Number Of Bathrooms")]
        public int Bathrooms { get; set; }
        [Display(Name = "WiFi")]
        public bool WiFi { get; set; }
        [Display(Name = "TV")]
        public bool TV { get; set; }
        [Display(Name = "Kitchen")]
        public bool Kitchen { get; set; }
        [Display(Name = "Washing Machine")]
        public bool WashingMachine { get; set; }
        [Display(Name = "Free Parking")]
        public bool FreeParking { get; set; }
        [Display(Name = "Paid Parking")]
        public bool PaidParking { get; set; }
        [Display(Name = "Air Conditioning")]
        public bool AirConditioning { get; set; }
        [Display(Name = "Dedicated Spaces")]
        public bool DedicatedSpaces { get; set; }
        [Display(Name = "Step Free Entrance")]
        public bool StepFreeEntrance { get; set; }
        [Display(Name = "Wider Than 32 inch")]
        public bool Widerthan32inch { get; set; }
        [Display(Name = "Step Free Path")]
        public bool StepFreePath { get; set; }
        [Display(Name = "From")]
        [DataType(DataType.Date)]
        public DateTime From { get; set; }
        [Display(Name = "To")]
        [DataType(DataType.Date)]
        public DateTime To { get; set; }
       public float Rating {  get; set; }

        [Display(Name = "Price")]
        public float Price { get; set; }
        [Display(Name = "Nights")]
        public int Nights { get; set; }
        [Display(Name = "Property Type")]
        public PropertyType PropertyType { get; set; } // Add property type enum
        public string CancellationPolicy { get; set; }                     // Navigation property for RoominacUsers
        public RoominacUsers RoominacUsers { get; set; }
        // Navigation property for Rating collection     
    }
    /////
    public enum PropertyType
    {
        House = 10,
        Apartment = 20,
        GuestHouse,
        Hotel,
        Hostel
    }
    //////
    public enum RatingValue
    {
        One = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5
    }
    //Images
    public class PropertyItemImage
    {
        [Key]
        public int Id { get; set; }
        // Foreign key for PropertyDetail
        [ForeignKey("PropertyDetail")]
        public int PropertyDetailId { get; set; }
        // Image data
        public byte[] Image { get; set; }
        // Navigation property for PropertyItem
        public PropertyDetail PropertyDetail { get; set; }
    }
    public class RatingItem
    {
        [Key]
        public int Id { get; set; }
        // Foreign key for PropertyDetail
        [ForeignKey("PropertyDetail")]
        public int PropertyDetailId { get; set; }
        // Foreign key for RoominacUsers
        [ForeignKey("RoominacUsers")]
        public int UserId { get; set; }
        // Rating value provided by the user  
        public RatingValue Value { get; set; }
        // Navigation property for PropertyDetail
        public PropertyDetail PropertyDetail { get; set; }
        // Navigation property for RoominacUsers
        public RoominacUsers RoominacUsers { get; set; }
    }
    //// Stays
    public class Stays
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "When")]
        [DataType(DataType.Date)]
        public DateTime When { get; set; }
        [Display(Name = "Number Of Guest")]
        public int NoOfGuset { get; set; }        
        public int RoominacUserId { get; set; }
        // Navigation property for RoominacUsers       
        public ExactDaysPlus ExactDaysPlusMinus { get; set; }
        // Foreign key for PropertyItem
        [ForeignKey("PropertyItem")]
        public int PropertyItemId { get; set; }
        // Navigation property for PropertyItem
        public PropertyDetail PropertyItem { get; set; }
    }
    public enum ExactDaysPlus
    {
        One = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5
    }
    ////
    public enum PaymentType
    {
        Travelling=10,
        Hosting=20

    }
    public class PaymentMethod
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Payment Method")]
        public string Method { get; set; }
        [Display(Name = "Card Number")]
        public string CardNumber { get; set; }
        [Display(Name = "Payment Type")]
        public PaymentType paymentType { get; set; }
        [Display(Name = "Expiry Date")]
        public DateTime ExpiryDate { get; set; }
        [Display(Name = "Accepts Refunds")]
        public bool AcceptsRefunds { get; set; }
        [Display(Name = "Accepts Cancellations")]
        public bool AcceptsCancellations { get; set; }
        [Display(Name = "Accepts Modifications")]
        public bool AcceptsModifications { get; set; }
        // Foreign key for RoominacUsers
        [ForeignKey("RoominacUsers")]
        public int RoominacUserId { get; set; }
        // Navigation property for RoominacUsers
        public RoominacUsers RoominacUsers { get; set; }
    }

}
