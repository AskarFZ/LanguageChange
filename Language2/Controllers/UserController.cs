using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Language2.Models;

namespace Language2.Controllers
{
    public class UserController : Controller
    {
        // GET: UserController
        public ActionResult Index()
        {
            List<UserModel> users = DB.Users;
            return View("List",users);
        }


        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserModel user)
        {
            if (ModelState.IsValid)
            {
                DB.Users.Add(user);
                return RedirectToAction(nameof(Index));
            }
            else
                return View(user);
            
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int index)
        {
            UserModel user = DB.Users[index];
            return View(user);
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int index, UserModel user)
        {
            if (ModelState.IsValid)
            {
                DB.Users[index] = user;
                return RedirectToAction(nameof(Index));
            }
            else
                return View(user);
            
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int index)
        {
            ViewBag.index = index;
            UserModel user = DB.Users[index];
            return View(user);
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int index,string DeleteConfirm)
        {
            if (ModelState.IsValid)
            {
                DB.Users.RemoveAt(index);
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction("Error", "Home");
           
        }
    }
}
