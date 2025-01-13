using adoecommerce.BL.Models;
using adoecommerce.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adoecommerce.BL.Repository
{
    DBContext _dBContext;
    public UserRepository() => _dBContext = new DBContext();
    public class FavortiesRepository
    {
        DBContext _dBContext;
        public FavortiesRepository() => _dBContext = new DBContext();

        public DataTable GetFavorite(User user)
        {
            //dataTable = new DataTable();
            DataTable dataTable = _dBContext.ExecuteQuery($"SELECT Products.ProductName  AS Name FROM    Favorites JOIN  Products ON Favorites.ProductId = Products.ProductId WHERE Favorites.UserId = {user.Id}");
            if (dataTable.Rows.Count > 0)
                return dataTable;
            throw new Exception("Un Expected Error");
        }


        public string AddToFavorite(User user, Product product)
        {
            int EffectiveRows = _dBContext.ExecuteNonQuery($"INSERT INTO favorites(userid, productid) values('{user.Id}',{product.Id})");
            if (EffectiveRows > 0)
                return "Product Added to favorites Successfully";
            throw new Exception("Un Expected error");
        }
    }
}
