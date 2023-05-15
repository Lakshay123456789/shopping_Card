using AutoMapper;
using AutoMapper.Configuration;
using shappingCardInMVC.generic_Repository;
using shappingCardInMVC.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Razor.Generator;

namespace shappingCardInMVC.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        // GET: Admin
        private IGenericRepository<Product> _genericRepository = null;

        private IGenericRepository<Category> _genericRepositoryProduct = null;
        public AdminController()
        {
            _genericRepository = new GenericRepository<Product>();
            _genericRepositoryProduct = new GenericRepository<Category>();

        }
        [HttpGet]
        public ActionResult Index()
        {
            var model = _genericRepository.GetAll();
            return View(model);
        }
        [HttpGet]
        public ActionResult AddProduct()
        {


            var categories = _genericRepositoryProduct.GetAll();
            TempData["CategoryList"] = new SelectList(categories, "Id", "CategoryName");

            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(DtoProduct model)
        {
            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
                string extension = Path.GetExtension(model.ImageFile.FileName);
                //      HttpPostedFileBase postFileBase = model.ImageFile;
                // int length = postFileBase.ContentLength;
                if (extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg" || extension.ToLower() == ".png")
                {

                    fileName = fileName + extension;
                     model.ProductImage = "/Images/" + fileName;
                  
                    fileName = Path.Combine(Server.MapPath("/Images/"), fileName);
                    model.ImageFile.SaveAs(fileName);
                }
                else
                {
                    ModelState.AddModelError("", "image only jpg ,jpeg and png");
                    var categorie = _genericRepositoryProduct.GetAll();
                    TempData["CategoryList"] = new SelectList(categorie, "Id", "CategoryName");
                    return View(model);
                }

                var product = new Product
                    {
                        ProductName = model.ProductName,
                        ProductDescription = model.ProductDescription,
                        ProductPrice = model.ProductPrice,
                        ProductImage = model.ProductImage,
                        ProductQuantity = model.ProductQuantity,
                        CategoryId = model.CategoryId,
                    };


                    _genericRepository.Insert(product);
                    _genericRepository.Save();

                    return RedirectToAction("Index", "Admin");
               



            }
            var categories = _genericRepositoryProduct.GetAll();
            TempData["CategoryList"] = new SelectList(categories, "Id", "CategoryName");
            return View();
        }
        [HttpGet]
        public ActionResult EditProduct(Guid ProductId)
        {

            Product model = _genericRepository.GetById(ProductId);
            var dtoproductmodel = new DtoProduct
            {
                ProductId = model.ProductId,
                ProductName = model.ProductName,
                ProductDescription = model.ProductDescription,
                ProductImage = model.ProductImage,
                ProductPrice = model.ProductPrice,
                ProductQuantity = model.ProductQuantity,
                CategoryId = model.CategoryId,

            };
            Session["img"] = dtoproductmodel.ProductImage;

            var categories = _genericRepositoryProduct.GetAll();
            TempData["CategoryList"] = new SelectList(categories, "Id", "CategoryName");
            return View(dtoproductmodel);
        }
        [HttpPost]
        public ActionResult EditProduct(DtoProduct model, string Image)
        {

            if (ModelState.IsValid)
            {

              
                if (model.ImageFile != null && model.ImageFile.ContentLength > 0)
                {
                    string fileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
                    string extension = Path.GetExtension(model.ImageFile.FileName);
                    //      HttpPostedFileBase postFileBase = model.ImageFile;
                    // int length = postFileBase.ContentLength;
                    if (extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg" || extension.ToLower() == ".png")
                    {

                        fileName = fileName + extension;
                        //   model.ProductImage = "/Images/" + fileName;
                          Image = "/Images/" + fileName;
                        fileName = Path.Combine(Server.MapPath("/Images/"), fileName);
                        model.ImageFile.SaveAs(fileName);
                    }
                    else
                    {
                        ModelState.AddModelError("", "image only jpg ,jpeg and png");
                        var categorie = _genericRepositoryProduct.GetAll();
                        TempData["CategoryList"] = new SelectList(categorie, "Id", "CategoryName");
                        return View(model);
                    }
                }
                var product = new Product
                {
                    ProductId = model.ProductId,
                    ProductName = model.ProductName,
                    ProductDescription = model.ProductDescription,
                    ProductPrice = model.ProductPrice,
                    ProductImage = Image,
                    ProductQuantity = model.ProductQuantity,
                    CategoryId = model.CategoryId,
                };

                _genericRepository.Update(product);

                _genericRepository.Save();

                return RedirectToAction("Index", "Admin");
            }
            model.ProductImage = Session["img"].ToString();
            var categories = _genericRepositoryProduct.GetAll();
            TempData["CategoryList"] = new SelectList(categories, "Id", "CategoryName");
            return View(model);
        }
       

        [HttpGet]
        public ActionResult DeleteProduct(Guid ProductId)
        {
            Product model = _genericRepository.GetById(ProductId);
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(Guid ProductID)
        {
            _genericRepository.Delete(ProductID);
            _genericRepository.Save();
            return RedirectToAction("Index", "Admin");
        }
    }
}