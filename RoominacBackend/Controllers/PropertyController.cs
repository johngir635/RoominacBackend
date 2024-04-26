using Newtonsoft.Json;
using RoominacBackend.Models;
using RoominacBackend.RequestModels;
using RoominacBackend.ResponseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Data.Entity;
namespace RoominacBackend.Controllers
{
    public class PropertyController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            var properties = db.PropertyDetail.ToList();
            if (properties != null)
            {
                return Json(db.PropertyDetail.ToList());

            }
            return Json("No Data Found");
        }
        [HttpPost]
        public ActionResult AddPaymentInformation(PaymentMethodDto payment)
        {

            PaymentMethod paymentMethod = new PaymentMethod()
            {
                Method = payment.Method,
                CardNumber = payment.CardNumber,
                paymentType = payment.PaymentType,
                ExpiryDate = payment.ExpiryDate,
                AcceptsCancellations = payment.AcceptsCancellations,
                AcceptsRefunds = payment.AcceptsRefunds,
                AcceptsModifications = payment.AcceptsModifications,
                RoominacUserId = payment.RoominacUserId,
            };
            var paymentmethd = db.PaymentMethod.Add(paymentMethod);
            db.SaveChanges();
            if (paymentmethd != null)
            {
                return Json("Payment Method Added Successfully");
            }

            return Json("Error While Adding the Payment Method");

        }

        [HttpPost]
        public ActionResult AddPaymentHistory(PaymentHistoryDto payment)
        {
            PaymentHistory paymentHistory = new PaymentHistory()
            {
                RoominacUserId = payment.RoominacUserId,
                PropertyId = payment.PropertyId,
                Amount = payment.Amount,
                PaymentDate = payment.PaymentDate,
                PaymentMethod = payment.PaymentMethod,
                TransactionId = payment.TransactionId,
                Status = payment.Status,

            };

            var paymenthistory = db.PaymentHistory.Add(paymentHistory);
            db.SaveChanges();
            if (paymenthistory != null)
            {
                return Json("Payment History Added Successfully");
            }

            return Json("Error While Adding the Payment History");

        }

        [HttpGet]
        public async Task<string> GetPropertyDetail(int id)
        {
            string query = @"
        SELECT  
            pd.LocationName,   
            pd.Rating,   
            pd.Price,  
            pd.Id,  
            pd.RoominacUserId,   
            pd.Latitude,   
            pd.Longitude,   
            pd.Distance,    
            pd.NoOfBeds,    
            pd.Bathrooms,    
            pd.WiFi,    
            pd.TV,    
            pd.Kitchen,    
            pd.WashingMachine,    
            pd.FreeParking,    
            pd.PaidParking,    
            pd.AirConditioning,   
            pd.DedicatedSpaces,    
            pd.StepFreeEntrance,   
            pd.Widerthan32inch,   
            pd.StepFreePath
             
        FROM    
            PropertyDetails pd 
        WHERE 
            pd.Id = '" + id + "'";
            var propertydetail = db.Database.SqlQuery<PropertyDetialsDTO>(query).FirstOrDefault();
            if (propertydetail != null)
            {
                var propertyimages = db.PropertyItemImage.ToList().Where(x => x.PropertyDetailId == id);

                var responseObject = new
                {
                    PropertyDetail = propertydetail,
                    PropertyImages = propertyimages
                };
                string json = JsonConvert.SerializeObject(responseObject);
                return json;
            }
            return "No Data Found";
        }

        [HttpPost]
        public async Task<string> GetPropertyList(PropertyItemFilterDTO itemFilterDTO)
        {
            string Locationname = itemFilterDTO.LocationName;
            float? lat = itemFilterDTO.Latitude;
            float? lan = itemFilterDTO.Longitude;
            int? PropertyType = itemFilterDTO.PropertyType;
            int? noofbeds = itemFilterDTO.NoOfBeds;
            int? noofbaths = itemFilterDTO.Bathrooms;
            bool? WiFi = itemFilterDTO.WiFi;
            bool? TV = itemFilterDTO.TV;
            bool? Kitchen = itemFilterDTO.Kitchen;
            bool? WashingMachine = itemFilterDTO.WashingMachine;
            bool? FreeParking = itemFilterDTO.FreeParking;
            bool? PaidParking = itemFilterDTO.PaidParking;
            bool? AirConditioning = itemFilterDTO.AirConditioning;
            bool? DedicatedSpaces = itemFilterDTO.DedicatedSpaces;
            bool? StepFreeEntrance = itemFilterDTO.StepFreeEntrance;
            bool? Widerthan32inch = itemFilterDTO?.Widerthan32inch;
            bool? StepFreePath = itemFilterDTO?.StepFreePath;
            DateTime? From = itemFilterDTO.From;
            DateTime? To = itemFilterDTO.To;
            float? Rating = itemFilterDTO.Rating;
            float? Price = itemFilterDTO.Price;
            int? Nights = itemFilterDTO.Nights;
            var query = @"
    SELECT pd.LocationName,
           pd.Rating,
           pd.Price,
           img.Image,
           rmu.Fullname,
           wsh.id
    FROM PropertyDetails pd
    INNER JOIN PropertyItemImages img ON pd.id = img.PropertyDetailId 
    INNER JOIN RoominacUsers rmu ON pd.RoominacUserId = rmu.id 
    INNER JOIN WishlistItems wsh ON pd.id = wsh.PropertyId ";
            if (itemFilterDTO.Id != null || Locationname != null ||
    (lat != null && lat != 0 && lan != null && lan != 0) ||
    (PropertyType != null && PropertyType != 0) ||
    (noofbaths != null && noofbaths != 0) ||
    (noofbeds != null && noofbeds != 0) ||
    WiFi != null ||
    TV != null ||
    Kitchen != null ||
    WashingMachine != null ||
    FreeParking != null ||
    PaidParking != null ||
    AirConditioning != null ||
    DedicatedSpaces != null ||
    StepFreeEntrance != null ||
    Widerthan32inch != null ||
    StepFreePath != null ||
    From != null ||
    To != null ||
    Rating != null ||
    Price != null ||
    Nights != null)
            {
                query += "WHERE ";
            }

            if (Locationname != null && Locationname != "")
            {
                query += " pd.LocationName LIKE '%" + Locationname + "%' OR";

            }

            if (lat != null && lat != 0 && lan != null && lan != 0)
            {
                query += " pd.Latitude = '" + lat + "' AND pd.Longitude = '" + lan + "' OR";

            }
            if (PropertyType != null && PropertyType != 0)
            {
                query += " pd.PropertyType = '" + PropertyType + "' OR";

            }
            if (noofbaths != null && noofbaths != 0)
            {
                query += " pd.Bathrooms = '" + noofbaths + "' OR";

            }

            if (noofbeds != null && noofbeds != 0)
            {
                query += " pd.NoOfBeds = '" + noofbeds + "' OR";

            }
            if (WiFi != null)
            {
                query += " pd.WiFi = '" + WiFi + "' OR";
            }

            if (TV != null)
            {
                query += " pd.TV = '" + TV + "' OR";
            }

            if (Kitchen != null)
            {
                query += " pd.Kitchen = '" + Kitchen + "' OR";
            }

            if (WashingMachine != null)
            {
                query += " pd.WashingMachine = '" + WashingMachine + "' OR";
            }
            if (FreeParking != null)
            {
                query += " pd.FreeParking = '" + FreeParking + "' OR";
            }

            if (PaidParking != null)
            {
                query += " pd.PaidParking = '" + PaidParking + "' OR";
            }

            if (AirConditioning != null)
            {
                query += " pd.AirConditioning = '" + AirConditioning + "' OR";
            }

            if (DedicatedSpaces != null)
            {
                query += " pd.DedicatedSpaces = '" + DedicatedSpaces + "' OR";
            }

            if (StepFreeEntrance != null)
            {
                query += " pd.StepFreeEntrance = '" + StepFreeEntrance + "' OR";
            }

            if (Widerthan32inch != null)
            {
                query += " pd.Widerthan32inch = '" + Widerthan32inch + "' OR";
            }
            if (StepFreePath != null)
            {
                query += " pd.StepFreePath = '" + StepFreePath + "' OR";
            }

            if (From != null && To != null)
            {
                string fromDate = From.Value.ToString("yyyy-MM-dd");
                string toDate = To.Value.ToString("yyyy-MM-dd");
                query += $" pd.From >= '{fromDate}' AND pd.To <= '{toDate}' OR";
            }
            else if (From != null)
            {
                string fromDate = From.Value.ToString("yyyy-MM-dd");
                query += $" pd.From >= '{fromDate}' OR";
            }
            else if (To != null)
            {
                string toDate = To.Value.ToString("yyyy-MM-dd");
                query += $" pd.To <= '{toDate}' OR";
            }

            if (Rating != null)
            {
                query += " pd.Rating = '" + Rating + "' OR";
            }

            if (Price != null)
            {
                query += " pd.Price = '" + Price + "' OR";
            }

            if (Nights != null)
            {
                query += " pd.Nights = '" + Nights + "'";
            }
            query = query.TrimEnd();
            if (query.EndsWith("OR", StringComparison.OrdinalIgnoreCase))
            {
                query = query.Substring(0, query.Length - 2).TrimEnd();
            }
            var propertyList = db.Database.SqlQuery<PropertyItems>(query).ToList();
            return JsonConvert.SerializeObject(propertyList);

        }

        [HttpPost]
        public ActionResult UploadPropertyImages(List<PropertyImage> itemImage)
        {
            List<PropertyItemImage> images = new List<PropertyItemImage>();
            int number = 0;
            foreach (var item in itemImage)
            {
                images.Add(RequestdtotoEntity(item));
            }

            foreach (var item in images)
            {
                var propertyItem = db.PropertyItemImage.Add(item);
                if (propertyItem != null)
                {
                    number++;
                    db.SaveChanges();
                }

            }
            if (number != 0)
            {
                return Json("uploaded Successfully");

            }

            return Json("Error While uploadeding");

        }

        public PropertyItemImage RequestdtotoEntity(PropertyImage propertyImage)
        {
            return new PropertyItemImage()
            {
                PropertyDetailId = propertyImage.PropertyDetailId,
                Image = propertyImage.Image,

            };
        }
        [HttpPost]
        public ActionResult CreateProperty(CreatePropertyDeatail property)
        {
            // Assuming property is an instance of PropertyRequestModel
            PropertyDetail propertyDetail = new PropertyDetail()
            {
                RoominacUserId = property.RoominacUserId,
                LocationName = property.LocationName,
                Latitude = property.Latitude,
                Longitude = property.Longitude,
                Distance = property.Distance,
                NoOfBeds = property.NoOfBeds,
                Bathrooms = property.Bathrooms,
                WiFi = property.WiFi,
                TV = property.TV,
                Kitchen = property.Kitchen,
                WashingMachine = property.WashingMachine,
                FreeParking = property.FreeParking,
                PaidParking = property.PaidParking,
                AirConditioning = property.AirConditioning,
                DedicatedSpaces = property.DedicatedSpaces,
                StepFreeEntrance = property.StepFreeEntrance,
                Widerthan32inch = property.Widerthan32inch,
                StepFreePath = property.StepFreePath,
                From = property.From,
                To = property.To,
                Price = property.Price,
                Nights = property.Nights,
                PropertyType = (PropertyType)Enum.Parse(typeof(PropertyType), property.PropertyType),

            };
            var createproperty = db.PropertyDetail.Add(propertyDetail);
            db.SaveChanges();
            if (createproperty != null)
            {
                return Json(createproperty.Id + " Is created");
            }
            return Json("Error While Creating the PropertyItem");
        }

        [HttpPost]
        public ActionResult Wishlist(WishListdto wishListdto)
        {
            WishlistItem wishlistItem = new WishlistItem()
            {

                PropertyId = wishListdto.PropertyId,
                UserId = wishListdto.UserId,

            };
            var wishlist = db.WishlistItem.Add(wishlistItem);
            db.SaveChanges();
            if (wishlist != null)
            {
                return Json("Wishlist Added Successfully");

            }
            return Json("Error While Storing Wishlist");
        }
        [HttpPost]
        public ActionResult GuestStays(staysdto staysdto)
        {
            Stays stays = new Stays()
            {
                When = staysdto.When,
                NoOfGuset = staysdto.NoOfGuset,
                RoominacUserId = staysdto.RoominacUserId,
                PropertyItemId = staysdto.PropertyItemId,
                ExactDaysPlusMinus = staysdto.ExactDaysPlusMinus,
            };

            var stay = db.Stays.Add(stays);
            db.SaveChanges();
            if (stay != null)
            {
                return Json("Booked");

            }
            return Json("Booking Error");
        }
        [HttpPost]
        public ActionResult Booking(BookingDto bookingdto)
        {
            Booking booking = new Booking()
            {
                Instantbooking = bookingdto.Instantbooking,
                SelfCheckIn = bookingdto.SelfCheckIn,
                FreeCancelation = bookingdto.FreeCancelation,
                PropertyItemId = bookingdto.PropertyItemId,

            };
            var booked = db.Booking.Add(booking);
            db.SaveChanges();
            if (booked != null)
            {
                return Json("Recored Added");

            }
            return Json("Error Occure");

        }

        [HttpPost]
        public ActionResult CreatesuperHost(HostUserDto hostUserDto)
        {
            SuperHost superHost = new SuperHost()
            {
                IsSuperHost = hostUserDto.IsSuperHost,
                HostRating = hostUserDto.HostRating,
                TotalReviews = hostUserDto.TotalReviews,
                CurrentlyHosting = hostUserDto.CurrentlyHosting,
                ProfileImage = hostUserDto.ProfileImage,
                Languages = hostUserDto.Languages,
                Location = hostUserDto.Location,
                Job = hostUserDto.Job,
                Interests = hostUserDto.Interests,
                DateOfBirth = hostUserDto.DateOfBirth,
                Education = hostUserDto.Education,
                Email = hostUserDto.Email,
                Phone = hostUserDto.Phone,
                Identity = hostUserDto.Identity,
                PropertyDetailId = hostUserDto.PropertyDetailId
            };

            var superhost = db.SuperHost.Add(superHost);
            db.SaveChanges();
            if (superhost != null)
            {
                return Json("Host Created Successfully");

            }
            return Json("Error Occure");
        }

        [HttpPost]
        public ActionResult TopTierStay(ToptiesStayDto toptiesStayDto)
        {
            TopTierStays topTierStays = new TopTierStays()
            {
                IsSuperHost = toptiesStayDto.IsSuperHost,
                HostLanguages = toptiesStayDto.HostLanguages,
                PropertyDetailId = toptiesStayDto.PropertyDetailId

            };
            var toptierstay = db.TopTierStays.Add(topTierStays);
            db.SaveChanges();
            if (toptierstay != null)
            {
                return Json("Host Added");

            }
            return Json("Error Occure");
        }

        [HttpPost]
        public ActionResult ReportedSuperHostProfile(ReportedSuperHostProfileDTO reporthost)
        {
            ReportedSuperHostProfile reportedSuperHostProfile = new ReportedSuperHostProfile()
            {
                ReportedBy = reporthost.ReportedBy,
                Reason = reporthost.Reason,
                ReportedAt = DateTime.Now,
                RoominacUserId = reporthost.RoominacUserId,
                SuperHostId = reporthost.SuperHostId,
            };
            var Reported = db.ReportedSuperHostProfile.Add(reportedSuperHostProfile);
            db.SaveChanges();
            if (Reported != null)
            {
                return Json("Reported");

            }
            return Json("Error Occure");
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        [HttpGet]
        public ActionResult GetReviewsAndRatings(int propertyId, int pageNumber = 1, int pageSize = 10)
        {
            var reviews = db.Reviews.Where(r => r.PropertyId == propertyId)
                                    .OrderByDescending(r => r.Date)
                                    .Skip((pageNumber - 1) * pageSize)
                                    .Take(pageSize)
                                    .ToList();
            var totalRating = reviews.Average(r => r.Rating);
            var totalReviews = reviews.Count;

            var response = new
            {
                TotalRating = totalRating,
                TotalReviews = totalReviews,
                Reviews = reviews
            };

            return Json(response, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
       
        public ActionResult GetCategoryRatings(int propertyId)
        {
            var categories = Enum.GetValues(typeof(ReviewCategory)).Cast<ReviewCategory>();
            var categoryRatings = categories.Select(category =>
            {
                var categoryReviews = db.Reviews.Include(r => r.RoominacUsers)
                                                .Where(r => r.PropertyId == propertyId && r.Category == category)
                                                .ToList();
                var averageRating = categoryReviews.Any() ? categoryReviews.Average(r => r.Rating) : 0;
                var detailedReviews = categoryReviews.Select(r => new
                {
                    UserFullName = r.RoominacUsers?.Fullname,
                    UserImage = r.RoominacUsers?.Photo,
                    UserLocation = $"{r.RoominacUsers?.Address}, {r.RoominacUsers?.Address2}, {r.RoominacUsers?.Address3}",
                    RatingDescriptions = r.RatingDescription,
                    RatingValue = r.Rating
                });

                return new
                {
                    Category = category,
                    AverageRating = averageRating,
                    Reviews = detailedReviews
                };
            }).ToList();

            return Json(categoryRatings, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]  
        public ActionResult PostReview(int userId, int propertyId, double rating, string reviewText, ReviewCategory category)
        {
            var review = new Review
            {
                UserId = userId,
                PropertyId = propertyId,
                Rating = rating,
                ReviewText = reviewText,
                Category = category,
                Date = DateTime.Now
            };
            db.Reviews.Add(review);
            db.SaveChanges();

            return Json(new { Success = true, Message = "Review posted successfully." });
            

        }


        [HttpGet]
    public ActionResult FilterReviews(int propertyId, ReviewCategory category)
    {
        var reviews = db.Reviews.Where(r => r.PropertyId == propertyId && r.Category == category).ToList();
        return Json(reviews);
    }

        //checkout page api
        [HttpPost]
        public ActionResult GetPriceDetails(PriceDetailsRequestModel request)
        {
           

            // Retrieve the property details from the database using the PropertyId
            var property = db.PropertyDetail.Find(request.PropertyId);
            if (property == null)
            {
                
                return Json(new { error = "Property not found" });
            }
            // Calculate the number of nights
            int nights = (request.To - request.From).Days;

            // Calculate the long stay discount
            float discount = (nights > 5) ? property.Price * 0.1f : 0;

            // Calculate the total price
            float total = (property.Price * nights) - discount;

            // Create the response model
            var response = new PriceDetailsResponseDTO
            {
                PricePerNight = property.Price,
                Nights = nights,
                LongStayDiscount = discount,
                TotalPrice = total
            };

            // Return the response model
            return Json(response);
        }


        //payment api
        [HttpGet]
        public ActionResult GetPaymentMethod(int userId)
        {
            // Retrieve the payment methods for the given user ID
            var paymentMethods = db.PaymentMethod.Where(p => p.RoominacUserId == userId).ToList();

            if (paymentMethods != null && paymentMethods.Count > 0)
            {
                // Convert the payment methods to DTOs and return them
                var paymentMethodDtos = paymentMethods.Select(p => new PaymentMethodDto
                {
                    Method = p.Method,
                    CardNumber = p.CardNumber,
                    PaymentType = p.paymentType,
                    ExpiryDate = p.ExpiryDate,
                    AcceptsRefunds = p.AcceptsRefunds,
                    AcceptsCancellations = p.AcceptsCancellations,
                    AcceptsModifications = p.AcceptsModifications,
                    RoominacUserId = p.RoominacUserId,
                }).ToList();

                return Json(paymentMethodDtos, JsonRequestBehavior.AllowGet);
            }

            return Json("No Payment Methods Found for the Given User ID", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UpdatePaymentMethod(PaymentMethodDto payment)
        {
            // Retrieve the existing payment method using the user ID
            var existingPaymentMethod = db.PaymentMethod.FirstOrDefault(p => p.RoominacUserId == payment.RoominacUserId);

            if (existingPaymentMethod != null)
            {
                // Update the existing payment method with the new details
                existingPaymentMethod.Method = payment.Method;
                existingPaymentMethod.CardNumber = payment.CardNumber;
                existingPaymentMethod.paymentType = payment.PaymentType;
                existingPaymentMethod.ExpiryDate = payment.ExpiryDate;
                existingPaymentMethod.AcceptsCancellations = payment.AcceptsCancellations;
                existingPaymentMethod.AcceptsRefunds = payment.AcceptsRefunds;
                existingPaymentMethod.AcceptsModifications = payment.AcceptsModifications;

                // Save the changes
                db.SaveChanges();

                return Json("Payment Method Updated Successfully");
            }

            return Json("Error While Updating the Payment Method");
        }
        private float CalculateTotalPrice(float nightlyRate, DateTime checkInDate, DateTime checkOutDate)
        {
            // Calculate the number of nights
            int totalNights = (int)(checkOutDate - checkInDate).TotalDays;

            // Calculate the total price
            float totalPrice = nightlyRate * totalNights;

            // You can apply any discounts or additional charges here if needed

            return totalPrice;
        }


        

        [HttpGet]
        public ActionResult GetCancellationPolicy(int propertyId)
        {
            // Retrieve the cancellation policy for the given property ID
            var property = db.PropertyDetail.FirstOrDefault(p => p.Id == propertyId);

            if (property != null)
            {
                string cancellationPolicy = property.CancellationPolicy;
                // Convert the cancellation policy to a DTO and return it
                var cancellationPolicyDto = new CancellationPolicyDto
                {
                    PropertyId = propertyId,
                    CancellationPolicyText = cancellationPolicy
                };

                return Json(cancellationPolicyDto, JsonRequestBehavior.AllowGet);
            }

            return Json("No Cancellation Policy Found for the Given Property ID", JsonRequestBehavior.AllowGet);
        }

        //house rules api

        [HttpGet]
        public ActionResult GetHouseRules(int propertyId)
        {
            var houseRules = db.HouseRules.Where(r => r.PropertyId == propertyId).ToList();

            if (houseRules != null && houseRules.Count > 0)
            {
               
                var houseRulesDto = houseRules.Select(r => new HouseRulesDto
                {
                    Id = r.Id,
                    Rule = r.Rule,
                    
                }).ToList();

                return Json(houseRulesDto, JsonRequestBehavior.AllowGet);
            }

            return Json("No House Rules Found for the Given Property ID", JsonRequestBehavior.AllowGet);
        }

        //hostprofile api
        [HttpGet]
        public ActionResult GetSuperHostProfile(int superHostId)
        {
            try
            {
                // Retrieve the SuperHost profile from the database based on the provided superHostId
                var superHost = db.SuperHost.FirstOrDefault(s => s.Id == superHostId);

                if (superHost != null)
                {
                    // Create a DTO  to send the SuperHost profile details
                    var superHostDto = new HostUserDto
                    {
                        Id = superHost.Id,
                        IsSuperHost = superHost.IsSuperHost,
                        HostRating = superHost.HostRating,
                        TotalReviews = superHost.TotalReviews,
                        CurrentlyHosting = superHost.CurrentlyHosting,
                        ProfileImage = superHost.ProfileImage,
                        Languages = superHost.Languages,
                        Location = superHost.Location,
                        Job = superHost.Job,
                        Interests = superHost.Interests,
                        DateOfBirth = superHost.DateOfBirth,
                        Education = superHost.Education,
                        Email = superHost.Email,
                        Phone = superHost.Phone,
                        Identity = superHost.Identity,
                        PropertyDetailId = superHost.PropertyDetailId
                    };

                   
                
                    return Json(superHostDto, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    
                    return Json("No Profile data  Found for the Given Property ID", JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                
                return Json($"An error occurred: {ex.Message}", JsonRequestBehavior.AllowGet);
            }
        }
    }

}
