using System.Collections.Generic;
using TechnogiASP.Models;
using System.Configuration;
using System.Data.SqlClient;

namespace TechnogiASP.Data
{
    internal class UserDAO
    {
        //All DB operations
        string connStr = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        public  List<UserModel> FetchAll()
        {
            List<UserModel> returnList = new List<UserModel>();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = "SELECT * from dbo.Users";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //Add items to list
                        UserModel user = new UserModel();
                        user.ID = reader.GetInt32(0);
                        user.Name = reader.GetString(1);
                        user.Email = reader.GetString(2);
                        user.Age = reader.GetInt32(3);

                        returnList.Add(user);
                    }
                }
                conn.Close();
            }

            return returnList;
        }

        public List<UserModel> SearchForName(string searchPhrase)
        {
            List<UserModel> returnList = new List<UserModel>();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = "SELECT * FROM dbo.Users WHERE userName LIKE @SearchPhrase";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@SearchPhrase", System.Data.SqlDbType.VarChar, 255).Value = "%" + searchPhrase + "%";
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //Add items to list
                        UserModel user = new UserModel();
                        user.ID = reader.GetInt32(0);
                        user.Name = reader.GetString(1);
                        user.Email = reader.GetString(2);
                        user.Age = reader.GetInt32(3);

                        returnList.Add(user);
                    }
                }
                conn.Close();
            }
            
            return returnList;
        }

        public UserModel FetchOne(int userId)
        {
            List<UserModel> returnList = new List<UserModel>();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = "SELECT * from dbo.Users WHERE id = @id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = userId;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                UserModel user = new UserModel();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //Add items to list
                        user.ID = reader.GetInt32(0);
                        user.Name = reader.GetString(1);
                        user.Email = reader.GetString(2);
                        user.Age = reader.GetInt32(3);

                        returnList.Add(user);
                    }
                }
                conn.Close();
                return user;
            }
        }

        public int CreateUpdate(UserModel userModel)
        {
            List<UserModel> returnList = new List<UserModel>();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = "";

                if (userModel.ID <= 0)
                {
                    sql = "INSERT INTO dbo.Users (userName, email, age) values (@Name, @Email, @Age) ";
                } else
                {
                    sql = "UPDATE dbo.Users SET userName = @Name, email = @Email, age = @Age WHERE id = @ID";
                }

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@ID", System.Data.SqlDbType.Int).Value = userModel.ID;
                cmd.Parameters.Add("@Name", System.Data.SqlDbType.VarChar, 255).Value = userModel.Name;
                cmd.Parameters.Add("@Email", System.Data.SqlDbType.VarChar, 255).Value = userModel.Email;
                cmd.Parameters.Add("@Age", System.Data.SqlDbType.Int).Value = userModel.Age;
                conn.Open();

                int newId = cmd.ExecuteNonQuery();

                conn.Close();

                return newId;
            }
        }

        public int Delete(int userId)
        {
            List<UserModel> returnList = new List<UserModel>();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = "DELETE FROM dbo.Users WHERE id = @id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = userId;
                conn.Open();
                int newId = cmd.ExecuteNonQuery();
                conn.Close();

                return newId;
            }
        }
    }
}