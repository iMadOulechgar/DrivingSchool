using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public static class clsDataAccessLayerDetained
    {
        public static bool IsLicenseDetained(int LicenceID)
        {
            bool result = false;

            SqlConnection con = new SqlConnection(clsConnection.ConnectionString);
            string Query = @"SELECT * FROM DetainedLicences WHERE LicenceID = @Id and IsReleased = 0";
            SqlCommand cmd = new SqlCommand(Query, con);

            cmd.Parameters.AddWithValue("@Id", LicenceID);

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

        public static bool UpdateDetainedLicense(int DetainID,
               int LicenseID, DateTime DetainDate,
               float FineFees, int CreatedByUserID)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsConnection.ConnectionString);

            string query = @"UPDATE DetainedLicenses
                              SET LicenceID = @LicenseID, 
                              DetainDate = @DetainDate, 
                              FineFees = @FineFees,
                              CreatedByUserID = @CreatedByUserID,   
                              WHERE DetainID=@DetainID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DetainedLicenseID", DetainID);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            command.Parameters.AddWithValue("@DetainDate", DetainDate);
            command.Parameters.AddWithValue("@FineFees", FineFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);


            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                return false;
            }

            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }

        public static int AddingDetainedLicence(int LicenceID , DateTime detainDate , float FineFees , int CreatedByUserID)
        {
            int Result = -1;

            SqlConnection con = new SqlConnection(clsConnection.ConnectionString);
            string Query = @"INSERT INTO DetainedLicences (LicenceID,DetainDate,FineFees,CreatedByUserID,IsReleased) VALUES 
                            (@LicenceID,@DetainDate,@FineFees,@CreatedByUserID,0); SELECT SCOPE_IDENTITY();";

            SqlCommand cmd = new SqlCommand(Query, con);

            cmd.Parameters.AddWithValue("@LicenceID",LicenceID);
            cmd.Parameters.AddWithValue("@DetainDate",detainDate);
            cmd.Parameters.AddWithValue("@FineFees",FineFees);
            cmd.Parameters.AddWithValue("@CreatedByUserID",CreatedByUserID);

            try
            {
                con.Open();

                object Obj = cmd.ExecuteScalar();


                if (Obj != null)
                if (int.TryParse(Obj.ToString(),out int Number))
                {
                    Result = Number;
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

        public static bool GetDetainedLicenseInfoByLicenseID(ref int DetainID , int LicenceID , ref DateTime detainDate, ref float FineFees, ref int CreatedByUserID, ref bool IsReleased, ref DateTime ReleasedDate, ref int ReleasedByUserID, ref int ReleasedAppID)
        {
            bool Result = false;

            SqlConnection con = new SqlConnection(clsConnection.ConnectionString);
            string Query = @"SELECT * FROM DetainedLicences WHERE LicenceID = @ID and IsReleased != 1";

            SqlCommand cmd = new SqlCommand(Query, con);

            cmd.Parameters.AddWithValue("@ID",LicenceID);

            try
            {
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    Result = true;

                    DetainID = (int)reader["DetainID"];
                    detainDate = (DateTime)reader["DetainDate"];
                    FineFees = Convert.ToSingle(reader["FineFees"]);
                    CreatedByUserID = (int)reader["CreatedByUserID"];

                    IsReleased = (bool)reader["IsReleased"];

                    if (reader["ReleasedDate"] == DBNull.Value)

                        ReleasedDate = DateTime.MaxValue;
                    else
                        ReleasedDate = (DateTime)reader["ReleasedDate"];


                    if (reader["RealeasedByUserID"] == DBNull.Value)

                        ReleasedByUserID = -1;
                    else
                        ReleasedByUserID = (int)reader["ReleasedByUserID"];

                    if (reader["ReleaseApplicationID"] == DBNull.Value)

                        ReleasedAppID = -1;
                    else
                        ReleasedAppID = (int)reader["ReleaseApplicationID"];
                }

                reader.Close();
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

        public static bool GetDetainedLicenseInfoByID(int DetainID,
               ref int LicenseID, ref DateTime DetainDate,
               ref float FineFees, ref int CreatedByUserID,
               ref bool IsReleased, ref DateTime ReleaseDate,
               ref int ReleasedByUserID, ref int ReleaseApplicationID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsConnection.ConnectionString);

            string query = "SELECT * FROM DetainedLicences WHERE DetainID = @DetainID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DetainID", DetainID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    // The record was found
                    isFound = true;

                    LicenseID = (int)reader["LicenceID"];
                    DetainDate = (DateTime)reader["DetainDate"];
                    FineFees = Convert.ToSingle(reader["FineFees"]);
                    CreatedByUserID = (int)reader["CreatedByUserID"];

                    IsReleased = (bool)reader["IsReleased"];

                    if (reader["ReleaseDate"] == DBNull.Value)

                        ReleaseDate = DateTime.MaxValue;
                    else
                        ReleaseDate = (DateTime)reader["ReleaseDate"];


                    if (reader["ReleasedByUserID"] == DBNull.Value)

                        ReleasedByUserID = -1;
                    else
                        ReleasedByUserID = (int)reader["ReleasedByUserID"];

                    if (reader["ReleaseApplicationID"] == DBNull.Value)

                        ReleaseApplicationID = -1;
                    else
                        ReleaseApplicationID = (int)reader["ReleaseApplicationID"];

                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static DataTable GetDataFromDetainAndReleaseLicenses()
        {
            DataTable Table = new DataTable();

            SqlConnection Connection = new SqlConnection(clsConnection.ConnectionString);
            string Query = @"select * from detainedLicenses_View;";

            SqlCommand cmd = new SqlCommand(Query, Connection);

            try
            {
                Connection.Open();

                SqlDataReader Reader = cmd.ExecuteReader();

                    Table.Load(Reader);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Connection.Close();
            }

            return Table;
        }

        public static bool ReleaseDetainedLicense(int DetainID,
         int ReleasedByUserID, int ReleaseApplicationID)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsConnection.ConnectionString);

            string query = @"UPDATE DetainedLicences
                              SET IsReleased = 1, 
                              ReleasedDate = @ReleaseDate, 
                              ReleaseApplicationID = @ReleaseApplicationID   
                              WHERE DetainID=@DetainID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DetainID", DetainID);
            command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);
            command.Parameters.AddWithValue("@ReleaseDate", DateTime.Now);
            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                return false;
            }

            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }

    }
}
