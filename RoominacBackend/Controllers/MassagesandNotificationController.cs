using RoominacBackend.Models;
using RoominacBackend.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RoominacBackend.Controllers
{
    public class MessagesandNotificationController : Controller
    { 
        private ApplicationDbContext db = new ApplicationDbContext();
        [HttpPost]
       public ActionResult createMessage(Messagedto messagedto)
       {
            Message message = new Message()
            {
                Content=messagedto.Content,
                SenderId=messagedto.SenderId,
                RecipientId=messagedto.RecipientId,
                SentAt=DateTime.Now,                
            };
            var storedmessage=db.Message.Add(message);
            db.SaveChanges();
            if (storedmessage != null)
            {
                return Json("message sent ");
            }
            return Json("sending message error");
        }
        [HttpPost]
        public ActionResult createNotification(Notificationdto notificationdto)
        {
            Notification notification = new Notification()
            {
                Content = notificationdto.Content,
                SenderId = notificationdto.SenderId,
                RecipientId = notificationdto.RecipientId,
                CreatedAt=DateTime.Now,
            };
            var createnotification = db.Notification.Add(notification);
            db.SaveChanges();
            if (createnotification != null)
            {
                return Json("Notificaiton Created");
            }
            return Json("Error Creating Notification");
        }

       
    }
}