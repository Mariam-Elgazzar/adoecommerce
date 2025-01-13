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
    public class ProductRepository
    {
        DBContext _dBContext;
        public ProductRepository() =>  _dBContext = new DBContext();

        public string AddProduct (Product product)
        {
            int EffectiveRows = _dBContext.ExecuteNonQuery($"insert into Products  (productname, price,pcategoryId) values('{product.Name}',{product.Price},{product.categoryId})");
            if (EffectiveRows > 0)
                return "Product Added Successfully";
            throw new Exception("Un Expected error");
        }

        public string Update (Product product)
        {
            int EffectiveRows = _dBContext.ExecuteNonQuery($"update products set productname = '{product.Name}',price = {product.Price},pcategoryId={product.categoryId} where productId = {product.Id}");
            if (EffectiveRows > 0)
                return "Product Updated Successfully";
            throw new Exception("Un Expected error");
        }
        public string Delete(int Id)
        {
            int EffectiveRows = _dBContext.ExecuteNonQuery($"Delete from Products Where  productId = {Id}");
            if (EffectiveRows > 0)
                return "Product Deleted Successfully";
            throw new Exception("Un Expected error");
        }
      
        public DataTable GetProducts()
        {
             //dt = new DataTable();
            DataTable dt = _dBContext.ExecuteQuery("select * from Products");
            if(dt.Rows.Count > 0) 
               return dt;
            throw new Exception("Un Expected Error");
        }

      

    }
}
