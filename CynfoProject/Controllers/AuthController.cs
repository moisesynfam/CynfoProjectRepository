using CynfoProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using CynfoProject.CustomLibraries;

namespace CynfoProject.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Login()
        {
           
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            using (var db = new GeneralDBContext())
            {
                var UsernameCheck = db.UserAccounts.FirstOrDefault(u => u.Username == model.Username);
                var getPassword = db.UserAccounts.Where(u => u.Username == model.Username).Select(u => u.Password);
                var materializePassword = getPassword.ToList();
                var password = materializePassword[0];
                var decryptedPassword = CustomDecrypt.Decrypt(password);



                if (model.Username!= null && model.Password ==  decryptedPassword)
                {
                    var getEmail = db.UserAccounts.Where(u => u.Username == model.Username).Select(u => u.Email);
                    var email = getEmail.ToList()[0]; 
                    var getEntity = db.UserAccounts.Where(u => u.Username == model.Username).Select(u => u.Entity);
                    var Entity = getEntity.ToList()[0];


                    var identity = new ClaimsIdentity(new[]{
                    new Claim(ClaimTypes.Email,email),
                    new Claim(ClaimTypes.Name, Entity)
                     }, "ApplicationCookie");
                    var ctx = Request.GetOwinContext();
                    var authManager = ctx.Authentication;
                    authManager.SignIn(identity);
                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError("", "Invalid email or password");

            return View(model);
        }

  

        public ActionResult Logout()
        {
            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;
            authManager.SignOut("ApplicationCookie");
            return RedirectToAction("Login", "Auth");
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegistrationModel model)
        {
            if (ModelState.IsValid)
            {
                using (var db = new GeneralDBContext())
                {
                    var encryptedPassword = CustomEncrypt.Encrypt(model.Password);
                    var user = db.UserAccounts.Create();
                    user.Email = model.Email;
                    user.Password = encryptedPassword;
                    user.Entity = model.Entity;
                    user.Username = model.Username;
                    db.UserAccounts.Add(user);
                    db.SaveChanges();

                }

            }
            else
            {
                ModelState.AddModelError("","One or more fields are not correct. Please Verify");
            }

            return View();
        }

    }
}