using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrReport.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DrReport.Controllers
{
    public class SignInController : Controller
    {
        private readonly MedicalDBContext _context;
        public SignInController(MedicalDBContext context)
        {
            _context = context;
        }
        // GET: SignInController
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public RedirectToActionResult Signin(User user)
        {
            var checkUser = _context.Users.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);
            if (checkUser != null)
            {
                // important global variable that could be used in every countroller
                TempData["accountid"] = checkUser.UserId;
                //***************************************
                if (checkUser.UserTypeId==1) 
                {
                    TempData["accountname"] = checkUser.Fname + " " + checkUser.Lname;
                    return RedirectToAction("Index", "PatientHome");

                }
                else if (checkUser.UserTypeId== 2)
                {
                    TempData["accountname"] = "DR. "+checkUser.Fname + " " + checkUser.Lname;
                    return RedirectToAction("Index", "DoctorHome");
                }
            }
           
               return RedirectToAction("Index", new { message = "No User" });
        }



        // GET: SignInController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SignInController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: SignInController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SignInController/Edit/5
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

        // GET: SignInController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SignInController/Delete/5
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
