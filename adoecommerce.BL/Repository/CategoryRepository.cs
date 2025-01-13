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
    public class CategoryRepository
    {
        DBContext _dBContext;
        public CategoryRepository() => _dBContext = new DBContext();

        public string AddCategory(Category category)
        {
            int EffectiveRows = _dBContext.ExecuteNonQuery($"insert into Categories  (categoryname) values('{category.Name}')");
            if (EffectiveRows > 0)
                return "Category Added Successfully";
            throw new Exception("Un Expected error");
        }

        public string Update(Category category)
        {
            int EffectiveRows = _dBContext.ExecuteNonQuery($"update Categories set categoryname = '{category.Name}'");
            if (EffectiveRows > 0)
                return "Category Updated Successfully";
            throw new Exception("Un Expected error");
        }
        public string Delete(int Id)
        {
            int EffectiveRows = _dBContext.ExecuteNonQuery($"Delete from Categories Where categoryId={Id}");
            if (EffectiveRows > 0)
                return "Category Deleted Successfully";
            throw new Exception("Un Expected error");
        }
        public DataTable Getcategorys()
        {
             //dataTable = new DataTable();
            DataTable dataTable = _dBContext.ExecuteQuery("select * from categories");
            if (dataTable.Rows.Count > 0)
                return dataTable;
            throw new Exception("Un Expected Error");
        }
    }
}
