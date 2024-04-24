using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;

namespace RoominacBackend.Models
{
    public class RoominacUsers
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }
        public string Phone { get; set; }
        public string GovId { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Emergencyphone { get; set; }
        public bool IdVerified { get; set; }
        public bool PhoneVerified { get; set; }
        public bool GovIdVerified { get; set; }
        public bool EmergencyContactProvided { get; set; }
    }



    ///Users

    public class WishlistItem
    {
        [Key]
        public int Id { get; set; }
      
        public int UserId { get; set; }  // Foreign key for the user who added the property to wishlist

        [ForeignKey("Property")]
        public int PropertyId { get; set; }  // Foreign key for the PropertyItem

        public PropertyDetail Property { get; set; }  // Navigation property for the PropertyItem
    }
    ////


    public class PersonalInformation
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Legal Name")]
        public string LegalName { get; set; }

        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Display(Name = "Government ID")]
        public string GovernmentID { get; set; }

        public string Address { get; set; }

        [Display(Name = "Emergency Contact")]
        public string EmergencyContact { get; set; }

        // Foreign key for RoominacUsers
        [ForeignKey("RoominacUsers")]
        public int RoominacUserId { get; set; }

        // Navigation property for RoominacUsers
        public RoominacUsers RoominacUsers { get; set; }
    }

    ////
    public class PaymentHistory
    {
        [Key]
        public int Id { get; set; }

       
        public int RoominacUserId { get; set; }  // Foreign key for the user who made the payment

        [ForeignKey("Property")]
        public int PropertyId { get; set; }  // Foreign key for the PropertyItem

        public PropertyDetail Property { get; set; }  // Navigation property for the PropertyItem

        [Display(Name = "Amount")]
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }  // Payment amount

        [Display(Name = "Payment Date")]
        [DataType(DataType.DateTime)]
        public DateTime PaymentDate { get; set; }  // Date and time of the payment

        [Display(Name = "Payment Method")]
        public string PaymentMethod { get; set; }  // Payment method used (e.g., credit card, PayPal)

        [Display(Name = "Transaction ID")]
        public string TransactionId { get; set; }  // Transaction ID associated with the payment

        [Display(Name = "Status")]
        public string Status { get; set; }  // Payment status (e.g., success, pending, failed)
       
    }
    ////
    public class Booking
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Instant Booking")]
        public bool Instantbooking { get; set; }
        [Display(Name = "Self Check-in")]
        public bool SelfCheckIn { get; set; }
        [Display(Name = "Free Cancelation")]
        public bool FreeCancelation { get; set; }

        // Foreign key for PropertyItem
        [ForeignKey("PropertyItem")]
        public int PropertyItemId { get; set; }


        // Navigation property for PropertyItem
        public PropertyDetail PropertyItem { get; set; }
    }

    ///




























}