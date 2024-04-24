using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoominacBackend.Models
{
    public class ReportedSuperHostProfile
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Reported By")]
        public string ReportedBy { get; set; }

        [Display(Name = "Reason")]
        public string Reason { get; set; }

        [Display(Name = "Reported At")]
        public DateTime ReportedAt { get; set; }

        [ForeignKey("SuperHost")]
        public int SuperHostId { get; set; }

        public virtual SuperHost SuperHost { get; set; }

        [ForeignKey("RoominacUsers")]
        public int RoominacUserId { get; set; }

        public virtual RoominacUsers RoominacUsers { get; set; }
    }

    public enum ReviewRating
    {
        Excellent = 50,
        Good = 40,
        Average = 30,
        Poor = 20,
        Terrible = 10
    }

    public class SuperHost
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "SuperHost")]
        public bool IsSuperHost { get; set; }

        [Display(Name = "Host Rating")]
        public RatingValue HostRating { get; set; }

        [Display(Name = "Total Reviews")]
        public int TotalReviews { get; set; }

        [Display(Name = "CurrentlyHosting")]
        public bool CurrentlyHosting { get; set; }
        [Display(Name = "Profile Image")]
        public byte[] ProfileImage { get; set; }

        [Display(Name = "Languages")]
        public string Languages { get; set; }

        [Display(Name = "Location")]
        public string Location { get; set; }

        [Display(Name = "Job")]
        public string Job { get; set; }

        [Display(Name = "Interests")]
        public string Interests { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Education")]
        public string Education { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Phone")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Display(Name = "Identity")]
        public string Identity { get; set; }

        // Navigation property for PropertyDetail
        [ForeignKey("PropertyDetail")]
        public int? PropertyDetailId { get; set; }

        public virtual PropertyDetail PropertyDetail { get; set; }

    }

    public class ReviewerRating
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("SuperHost")]
        public int SuperHostId { get; set; }

        public virtual SuperHost SuperHost { get; set; }

        [ForeignKey("RoominacUsers")]
        public int ReviewerId { get; set; }

        public virtual RoominacUsers RoominacUsers { get; set; }

        public ReviewRating Rating { get; set; }
    }

    public class TopTierStays
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "SuperHost")]
        public bool IsSuperHost { get; set; }

        [Display(Name = "Host Languages")]
        public string[] HostLanguages { get; set; }

        [ForeignKey("PropertyDetail")]
        public int PropertyDetailId { get; set; }

        public virtual PropertyDetail PropertyDetail { get; set; }
    }

    public class Rating
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("PropertyDetail")]
        public int PropertyDetailId { get; set; }

        [ForeignKey("RoominacUsers")]
        public int UserId { get; set; }

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

        [Display(Name = "Description")]
        public string RatingDescription { get; set; }

        public virtual PropertyDetail PropertyDetail { get; set; }

        public virtual RoominacUsers RoominacUsers { get; set; }
    }

}
