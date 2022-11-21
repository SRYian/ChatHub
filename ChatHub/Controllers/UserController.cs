using ChatHub.Config;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatHub.Controllers
{

    
    public class UserController : Controller
    {

        public readonly DBStore _dbStore;
        public UserController(DBStore store)
        {
            _dbStore = store;
           
        }
        // GET: UserController
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult RegisterForm(IFormCollection collection)
        {
            try
            {
                string username=collection["username"];
                string password=collection["password"];
                _dbStore.CreateUser(username, password);
                return RedirectToAction(nameof(Login));
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult LoginForm(IFormCollection collection)
        {
            string username = collection["username"];
            string password = collection["password"];
            HttpContext.Session.SetString("user", "orangtest");

            var user = _dbStore.getValidation(username);
            if (user.Password == password)
            {
                HttpContext.Session.SetString("user", username);
            }
            //return RedirectToAction(nameof(Login));
            return Redirect("~/");
        }
        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
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

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
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
