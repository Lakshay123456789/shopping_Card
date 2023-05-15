using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using shappingCardInMVC.Models;
using shappingCardInMVC.generic_Repository;
using System.Web.Security;

namespace shappingCardInMVC.Controllers
{
    public class AuthenticationController : Controller
    {
        private  IUserResporitory _userResporitory;
        private IGenericRepository<User> _userSign = null;
        public AuthenticationController()
        {
            _userResporitory=new UserResporitory();
            _userSign=new GenericRepository<User>();
        }
        // GET: Authentication
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Login(LoginUser model)
        {
            if (ModelState.IsValid)
            {
                User checkUser = _userResporitory.GetUserByName(model.UserName);
                if (checkUser != null)
                {
                    if (model.Password == checkUser.Password)
                    {
                        if (checkUser.RoleMasterId == 1)
                        {
                            FormsAuthentication.SetAuthCookie(model.UserName, false);
                            return RedirectToAction("Index", "Admin");

                        }
                        else { 
                            FormsAuthentication.SetAuthCookie(model.UserName, false);
                            return RedirectToAction("Index", "Useres",new { UserId= checkUser.UserId });
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid password");
                        return View(model);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "This UserName not Exist");
                    return View(model);
                }
            }


            ModelState.AddModelError("", "Please Fill UserName and Password");
                return View(model);
            
        }


        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        [HttpGet]

        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]

        public ActionResult SignUp(User model)
        {
            if (ModelState.IsValid)
            {
                model.RoleMasterId = 2;
                _userSign.Insert(model);
                _userSign.Save();
                return RedirectToAction("Index","Useres");
            }
            ModelState.AddModelError("", "please fill data properly");
            return View();
        }
    }
}