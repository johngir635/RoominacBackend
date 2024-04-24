using RoominacBackend.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;

namespace RoominacBackend.Controllers
{
    public class UserController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        
        [HttpPost]
        public JsonResult InsertPhone(string phone)
        {
            var existingUser = db.RoominacUsers.FirstOrDefault(x => x.Phone == "+" + phone);
            if(existingUser == null)
            {
                var user = new RoominacUsers();
                user.Phone = "+" + phone;
                user.PhoneVerified = true;
                db.RoominacUsers.Add(user);
                db.SaveChanges();
                return Json("User Phone Added Successfully", JsonRequestBehavior.AllowGet);
            }
            return Json("A user with the same phone number is already registered.", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddPhoto(string photo, string phone)
        {
            var existingUser = db.RoominacUsers.FirstOrDefault(x => x.Phone == "+" + phone);
            if(existingUser != null)
            {
                existingUser.Photo = photo;
                db.RoominacUsers.AddOrUpdate();
                db.SaveChanges();
                return Json("User Photo Added Successfully", JsonRequestBehavior.AllowGet);
            }
            return Json("Some error occured saving the photo. Please try again later.", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddPersonalInfo(RoominacUsers user)
        {
            var existingUser = db.RoominacUsers.FirstOrDefault(x => x.Phone == "+" + user.Phone);
            if (existingUser != null)
            {
                existingUser.Fullname = user.Fullname;
                existingUser.Email = user.Email;
                existingUser.Address2 = user.Address;
                existingUser.Address3 = user.Address;
                existingUser.Emergencyphone = "+" + user.Emergencyphone;
                if (user.GovId != null)
                {
                    existingUser.GovId = user.GovId;
                    existingUser.GovIdVerified = true;
                }
                if(user.Emergencyphone != null)
                {
                    existingUser.EmergencyContactProvided = true;
                }

                db.RoominacUsers.AddOrUpdate();
                db.SaveChanges();
                return Json("User Photo Added Successfully", JsonRequestBehavior.AllowGet);
            }
            return Json("Some error occured saving the photo. Please try again later.", JsonRequestBehavior.AllowGet);
        }

      }
  


}