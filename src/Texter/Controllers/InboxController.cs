﻿using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Texter.Models;
using Texter.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Texter.Controllers
{
    [Authorize]
    public class InboxController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public InboxController(UserManager<ApplicationUser> userManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetMessages()
        {
            var allMessages = Message.GetMessages();
            List<Message> incomingMessages = new List<Message>();
            List<Message> sentMessages = new List<Message>();
            foreach (var message in allMessages)
            {
                if (message.To == "+15038500537")
                {
                    incomingMessages.Add(message);
                }
                else
                {
                    sentMessages.Add(message);
                }
            }

            InboxViewModel inbox = new InboxViewModel();
            inbox.incomingMessages = incomingMessages;
            inbox.sentMessages = sentMessages;
            return View(inbox);
        }

        public IActionResult SendMessage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendMessage(Message newMessage)
        {
            List<string> recipients = new List<string>();
            recipients.Add(newMessage.To);
            recipients.Add(Request.Form["recipient-2"]);
            foreach (var recipient in recipients)
            {
                newMessage.To = recipient;
                newMessage.Send();
            }
            return RedirectToAction("Index");
        }
    }
}
