using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public static class clsDataAccessLayerDrivers
    {
        public static bool IsItAdriverAlreadyByPersoneID(int PersonID)
        {
            bool result = false;

            SqlConnection con = new SqlConnection(clsConnection.ConnectionString);
            string Query = @"SELECT * FROM Drivers WHERE PersonID = @Id";
            SqlCommand cmd = new SqlCommand(Query, con);

            cmd.Parameters.AddWithValue("@Id", PersonID);

            try
            {
                con.Open();
                SqlDataReader Reader = cmd.ExecuteReader();

                if (Reader.HasRows)
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

        public static int AddDriver(int PersonID,int CreatedByUser,DateTime CreatedDate)
        {
            int Number = -1;

            SqlConnection Connection = new SqlConnection(clsConnection.ConnectionString);
            string Query = @"INSERT INTO Drivers(PersonID,CreatedByUserID,CreatedDate)VALUES(@PersonID,@CreatedByUserID,@CreatedDate);
                                 SELECT SCOPE_IDENTITY();";

            SqlCommand cmd = new SqlCommand(Query, Connection);

            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUser);
            cmd.Parameters.AddWithValue("@CreatedDate", CreatedDate);

            try
            {
                Connection.Open();

                object result = cmd.ExecuteScalar();

                if (int.TryParse(result.ToString(), out int Num))
                {
                    Number = Num;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error in AddPersone: " + ex.Message);
            }
            finally
            {
                Connection.Close();
            }

            return Number;
        }

        public static int GetDriverIDByPersonID(int PerID)
        {
            int Number = -1;

            SqlConnection Connection = new SqlConnection(clsConnection.ConnectionString);
            string Query = @"SELECT DriverID FROM Drivers WHERE PersonID = @ID";

            SqlCommand cmd = new SqlCommand(Query, Connection);

            cmd.Parameters.AddWithValue("@ID", PerID);

            try
            {
                Connection.Open();

                object result = cmd.ExecuteScalar();

                if (result != null) {
                    if (int.TryParse(result.ToString(), out int Num))
                    {
                        Number = Num;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in AddPersone: " + ex.Message);
            }
            finally
            {
                Connection.Close();
            }

            return Number;
        }

        public static DataTable getAllDrivers()
        {
            DataTable Dt = new DataTable();

            SqlConnection con = new SqlConnection(clsConnection.ConnectionString);
            string Query = "SELECT * FROM Drivers_View";

            SqlCommand cmd = new SqlCommand(Query,con);

            try
            {
                con.Open();

                SqlDataReader Read = cmd.ExecuteReader();

                    Dt.Load(Read);
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




    }
}
