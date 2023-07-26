using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
// need add to References
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;

namespace DataAccess
{
    public class UsersDAL
    {
        string connectStr = ConfigurationManager.ConnectionStrings["DBConnectString"].ToString();

        public DataTable GetUsers()
        {
            List<Users> UserList = new List<Users>();
            DataTable dt;
            //using (SqlConnection conn = new SqlConnection(connectStr))
            //{
            //    string sqlQuery = "SELECT * FROM Users";
            //    SqlCommand cmd = new SqlCommand(sqlQuery, conn);

            //    conn.Open();

            //    using(SqlDataReader reader = cmd.ExecuteReader())
            //    {
            //        while (reader.Read())
            //        {
            //            Users user = new Users();
            //            user.UserId = Convert.ToInt32(dr["UserId"]);
            //            user.UserName = reader["UserName"].ToString();
            //            user.Email = reader["Email"].ToString();
            //            user.Password = reader["Password"].ToString();
            //            UserList.Add(user);
            //        }
            //    }

            //}

            using (SqlConnection conn = new SqlConnection(connectStr))
            {
                string sqlQuery = "SELECT * FROM Users";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlQuery, conn);
                DataSet ds = new DataSet();
                dataAdapter.Fill(ds, "Users");

                dt = ds.Tables["Users"];
            }

            //return UserList;
            return dt;
        }

        public void AddUser(Users user)
        {
            using (SqlConnection conn = new SqlConnection(connectStr))
            {
                string sqlQuery =
                    "INSERT INTO Users (UserName, Email, Password) VALUES(@UserName, @Email, @Password)";
                SqlCommand cmd = new SqlCommand(sqlQuery, conn);
                
                cmd.Parameters.AddWithValue("@UserName", user.UserName);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                //cmd.Parameters.AddWithValue("@ConfirmPassword", user.ConfirmPassword);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
