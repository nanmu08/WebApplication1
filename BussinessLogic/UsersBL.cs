using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.Models;


namespace BussinessLogic
{
    public class UsersBL
    {
        //public List<Users> GetUsers()
        //{
        //    List<Users> usersBL = new UsersDAL().GetUsers();
        //    List<Users> usersmodify = ModifyPassword(usersBL);
        //    return usersmodify;
        //}

        public List<Users> GetUsers()
        {
            List<Users> usersBL = new List<Users>();
            DataTable usersTable = new UsersDAL().GetUsers();

            foreach (DataRow dr in usersTable.Rows)
            {
                Users user = new Users();
                user.UserId = Convert.ToInt32(dr["UserId"]);
                user.UserName = dr["UserName"].ToString();
                user.Password = dr["Password"].ToString();
                user.Email = dr["Email"].ToString();
                usersBL.Add(user);
            }
            List<Users> usersmodify = ModifyPassword(usersBL);
            return usersmodify;

        }


        public List<Users> ModifyPassword(List<Users> users)
        {
            foreach (var user in users)
            {
                user.Password = user.Password.Substring(0, user.Password.Length - 1) + "*";
            }
            return users;
        }
    }
}
