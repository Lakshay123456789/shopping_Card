using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using shappingCardInMVC.Models; 
namespace shappingCardInMVC.generic_Repository
{
    public class UserResporitory:IUserResporitory
    {
        private readonly ProductdbContext _context;

        public UserResporitory()
        {
            _context = new ProductdbContext();
        }
        public User GetUserByName(string username)
        {
            
           User userCheck =_context.Users.Where(u=>u.UserName== username).FirstOrDefault();

            return userCheck;
        }
        public IList<Product> GetUserByCategoryId(int categoryId)
        {
           var models= (from pro in _context.Productes
                      where pro.CategoryId==categoryId
                      select pro).ToList();
                return models;
        }


    }
}