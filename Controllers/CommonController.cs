using shappingCardInMVC.generic_Repository;
using shappingCardInMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace shappingCardInMVC.Controllers
{
    public class CommonController : Controller
    {
        // GET: Common
        private IGenericRepository<Category> _genericRepositoryProduct = null;
        private IUserResporitory _userResporitory = null;

        public CommonController() { 
        
            _genericRepositoryProduct=new GenericRepository<Category>();
            _userResporitory=new UserResporitory();
        }
        [HttpGet]
        public ActionResult Index()
        {
            var AllCategory=_genericRepositoryProduct.GetAll();
            return View(AllCategory);
        }
        [HttpGet]
        public ActionResult Details(int? Id)
        {
            int id = (int)Id;
           
          
               var  model = _userResporitory.GetUserByCategoryId(id);
          
                return View(model);
            
          
        }

    }
}