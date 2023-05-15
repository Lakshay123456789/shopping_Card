using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using shappingCardInMVC.Models;
namespace shappingCardInMVC.generic_Repository
{
    public interface IUserResporitory
    {

        User GetUserByName(string username);
         IList<Product> GetUserByCategoryId(int categoryId);
      

    }
}
