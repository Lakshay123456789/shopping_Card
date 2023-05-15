using shappingCardInMVC.generic_Repository;
using shappingCardInMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;

namespace shappingCardInMVC.Controllers
{
    public class UseresController : Controller
    {
        // GET: Useres
        private IGenericRepository<Product> _genericRepository = null;

        private IGenericRepository<Category> _genericRepositoryProduct = null;
        public UseresController()
        {
            _genericRepository=new GenericRepository<Product>();
            _genericRepositoryProduct = new GenericRepository<Category>();
        }
        [HttpGet]
        public ActionResult Index(Guid ? UserId)
        {
            ViewBag.userId=UserId;
            Session["userid"] = UserId;
            var model = _genericRepository.GetAll();
            return View(model) ;
        }
        public ActionResult Cart()
        {
            ViewBag.userid = Session["userid"];
            return View();
        }
      
    }
}