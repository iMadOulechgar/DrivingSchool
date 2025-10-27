using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
            string Query = @"select Users.UserID,Users.PersoneID,FirstName+' '+SecondName+' '+ThirdName+' '+LastName as Fullname , Username , isActive from Users inner join 
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
                new Exception (ex.Message);
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
                new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }

            return Result;
        } 





    }
}
