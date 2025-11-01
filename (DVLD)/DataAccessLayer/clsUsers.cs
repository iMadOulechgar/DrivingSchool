using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public static class clsUsers
    {

        public static int AddUser(int personeid,string Username,string password ,short isActive)
        {
            int result = -1;
            SqlConnection con = new SqlConnection(clsConnection.ConnectionString);
            string Query = @"INSERT INTO Users (personeid,Username,password,isActive)VALUES
                           (@personeid,@username,@password,@isActive); SELECT SCOPE_IDENTITY();";

            SqlCommand cmd = new SqlCommand(Query, con);

            cmd.Parameters.AddWithValue("@personeid",personeid);
            cmd.Parameters.AddWithValue("@username", Username);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Parameters.AddWithValue("@isActive", isActive);

            try
            {
                con.Open();

                object Obj = cmd.ExecuteScalar();

                if (int.TryParse(Obj.ToString(),out int Id))
                    result = Id;

            }
            catch (Exception ex)
            {
               new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
            
            return result;
        }

        public static DataTable GetAllUsers()
        {
            DataTable Dt = new DataTable();

            SqlConnection con = new SqlConnection(clsConnection.ConnectionString);
            string Query = @"SELECT Users.UserID,Users.PersoneID,FirstName+' '+SecondName+' '+ThirdName+' '+LastName AS Fullname , Username , isActive from Users INNER JOIN 
                                         People ON People.PersoneID = Users.PersoneID;";
            SqlCommand cmd = new SqlCommand(Query, con);

            try
            {
                con.Open();

                SqlDataReader Reader = cmd.ExecuteReader();

                if (Reader.Read())
                {
                    Dt.Load(Reader);
                }

                Reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }

          return Dt;
        
        }

        public static bool Exists(int Per)
        {
            bool Result = false;

            SqlConnection con = new SqlConnection(clsConnection.ConnectionString);
            string Query = "SELECT * FROM Users WHERE PersoneID = @PersoneID";
            SqlCommand cmd = new SqlCommand(Query,con);

            cmd.Parameters.AddWithValue("@PersoneID",Per);
            
            try
            {
                con.Open();

                SqlDataReader Reader = cmd.ExecuteReader();

                if (Reader.Read())
                {
                    Result = true;
                }
                Reader.Close();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                    
            }
            finally
            {
                con.Close();
            }

            return Result;
        }

        public static bool IsUserExistsAndIsActive(string Username , string Password)
        {
            DataTable Table = new DataTable();
            bool Result = false;

            SqlConnection con = new SqlConnection(clsConnection.ConnectionString);
            string Query = "SELECT UserName,Password from Users WHERE isActive = 1;";

            SqlCommand cmd = new SqlCommand(Query,con);

            try
            {
                con.Open();

                SqlDataReader Read = cmd.ExecuteReader();

                Table.Load(Read);

                Read.Close();

                foreach (DataRow Row in Table.Rows)
                {
                    if ((string)Row["UserName"] == Username && (string)Row["Password"] == Password)
                    {
                        Result = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally 
            { 
                con.Close();
            }

            return Result;
        }

        public static bool FindUserByUserID(ref int usersid,ref int personeid , ref string username , ref string password , ref bool isActive)
        {
            bool result = false;

            SqlConnection con = new SqlConnection(clsConnection.ConnectionString);
            string Query = "SELECT * FROM Users WHERE UserID = @userid";
            SqlCommand cmd = new SqlCommand(Query,con);

            cmd.Parameters.AddWithValue("@userid", usersid);

            try
            {
                con.Open();

                SqlDataReader Reader = cmd.ExecuteReader();

                if (Reader.Read())
                {
                    result = true;

                    personeid = (int)Reader["PersoneID"];
                    username = (string)Reader["UserName"];
                    password = (string)Reader["Password"];
                    isActive = (bool)Reader["isActive"];
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }

            return result;
        }

        public static bool FindUserByUserName(ref int usersid, ref int personeid, ref string username, ref string password, ref bool isActive)
        {
            bool result = false;

            SqlConnection con = new SqlConnection(clsConnection.ConnectionString);
            string Query = "SELECT * FROM Users WHERE UserName = @username";
            SqlCommand cmd = new SqlCommand(Query, con);

            cmd.Parameters.AddWithValue("@username", username);

            try
            {
                con.Open();

                SqlDataReader Reader = cmd.ExecuteReader();

                if (Reader.Read())
                {
                    result = true;

                    usersid = (int)Reader["UserID"];
                    personeid = (int)Reader["PersoneID"];
                    username = (string)Reader["UserName"];
                    password = (string)Reader["Password"];
                    isActive = (bool)Reader["isActive"];
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }

            return result;
        }

        public static bool UpdateUser(int userid  , string username , string password , short isactive)
        {
            bool Result = false;

            SqlConnection con = new SqlConnection( clsConnection.ConnectionString);
            string Query = @"UPDATE Users SET UserName = @username , Password = @password , isActive = @isactive WHERE UserID = @userid";
            SqlCommand cmd = new SqlCommand(Query,con);

            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Parameters.AddWithValue("@isactive", isactive);
            cmd.Parameters.AddWithValue("@userid", userid);

            try
            {
                con.Open();

                int num = cmd.ExecuteNonQuery();

                if (num != 0)
                {
                    Result = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally 
            {
              con.Close();
            }

            return Result;
        }

        public static bool DeleteUserbyid(int userid)
        {
            bool result = false;

            SqlConnection con = new SqlConnection(clsConnection.ConnectionString);
            string Query = "DELETE FROM Users WHERE UserID = @userid";
            SqlCommand cmd = new SqlCommand(Query,con);

            cmd.Parameters.AddWithValue("@userid", userid);

            try
            {
                con.Open();

                int num = cmd.ExecuteNonQuery();
                if (num != 0)
                {
                    result = true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }

            return result;
        }

        public static bool CheckUserPasswordIsExists(string Password , int userid)
        {
            bool result = false;

            SqlConnection con = new SqlConnection(clsConnection.ConnectionString);
            string Query = "SELECT * FROM Users WHERE Password = @password and UserID = @userid";
            SqlCommand cmd = new SqlCommand(Query,con);

            cmd.Parameters.AddWithValue("@password",Password);
            cmd.Parameters.AddWithValue("@userid", userid);

            try
            {
                con.Open();

                SqlDataReader Reader = cmd.ExecuteReader();

                if (Reader.Read())
                {
                    result = true;
                }

                Reader.Close();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message); 
            }
            finally
            {
                con.Close();
            }

            return result;
        }

    }
}
