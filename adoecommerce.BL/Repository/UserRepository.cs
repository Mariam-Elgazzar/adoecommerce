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
    public class UserRepository
    {
        DBContext _dBContext;
        public UserRepository() => _dBContext = new DBContext();

        public User GetUser(string userName, string password)
        {
            User user ;

            string query = $"SELECT userid ,username,password,email,age,address ,isAdmin FROM users WHERE username = '{userName}' AND password = '{password}'";

            DataTable dt = _dBContext.ExecuteQuery(query);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                user = new User
                {
                    Id = Convert.ToInt32(row["userid"]),
                    Age = Convert.ToInt32(row["Age"]),
                    Name = row["username"].ToString(),
                    Email = row["Email"].ToString(),
                    Password = row["Password"].ToString(),
                    address = row["Address"].ToString(),
                    isAdmin = (Boolean)row["IsAdmin"], 
                };
                return user;
            }
            throw new Exception("un expected error");
        }

        public void  AddUser(User user)
        {
            if (user == null) throw new Exception("Enter Valid Data");
            int EffectiveRows = _dBContext.ExecuteNonQuery($"insert into users (username,password,email,age,address) values ('{user.UserName}','{user.Password}','{user.Email}',{user.Age},'{user.address}')");
            if (EffectiveRows > 0)
                return;
            throw new Exception("Un Expected error");
        }

    }
}
