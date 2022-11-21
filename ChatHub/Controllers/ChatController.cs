using ChatHub.Config;
using ChatHub.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatHub.Controllers
{
    public class ChatController : Controller
    {
        public readonly DBStore _dbStore;
        public readonly UserManager<AppUser> _userManager;
        public ChatController(DBStore store, UserManager<AppUser> usermanager)
        {
            _dbStore = store;
            _userManager = usermanager;
        }
        // GET: ChatController
        public async Task<ActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var messages =  _dbStore.GetAllMessage();
            return View(messages);
        }

        // GET: ChatController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ChatController/Create
       

        // POST: ChatController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            
            Message message = new Message();
            ViewBag.userid ="pogger";
            ViewBag.text = collection["message"];
            /*message.Text= collection["text"];
            message.UserID = collection["userid"];*/

            message.Text = collection["message"];
            message.Username = collection["user"];
            message.Username = HttpContext.Session.GetString("user");

            List<Message> list= new List<Message>();
            list.Add(message);
            _dbStore.SendMessage(message);

            return RedirectToAction(nameof(Index));
        }

        // GET: ChatController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ChatController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ChatController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ChatController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
