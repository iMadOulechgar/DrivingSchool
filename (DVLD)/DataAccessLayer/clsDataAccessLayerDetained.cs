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
            string Query = @"SELECT * FROM DetainedLicences WHERE LicenceID = @Id and IsReleased != 1";
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

        public static bool UpdateDetainedToReleased(int DetainID ,bool IsReleased , DateTime ReleasedDate , int ReleasedByUserID , int ReleasedAppID)
        {
            bool result = false;

            SqlConnection con = new SqlConnection(clsConnection.ConnectionString);
            string Query = @"UPDATE DetainedLicences SET IsReleased = @Isreleased , ReleasedDate = @ReleaseDate , RealeasedByUserID = @UserID , 
                            ReleaseApplicationID = @ReleasAppID WHERE DetainID = @DetainID";

            SqlCommand cmd = new SqlCommand(Query, con);

            cmd.Parameters.AddWithValue("@Isreleased", IsReleased);
            cmd.Parameters.AddWithValue("@ReleaseDate", ReleasedDate);
            cmd.Parameters.AddWithValue("@UserID", ReleasedByUserID);
            cmd.Parameters.AddWithValue("@ReleasAppID", ReleasedAppID);
            cmd.Parameters.AddWithValue("@DetainID", DetainID);

            try
            {
                con.Open();

                int Num = cmd.ExecuteNonQuery();

                if (Num > 0)
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

        public static int AddingDetainedLicence(int LicenceID , DateTime detainDate , decimal FineFees , int CreatedByUserID , bool IsReleased)
        {
            int Result = -1;

            SqlConnection con = new SqlConnection(clsConnection.ConnectionString);
            string Query = @"INSERT INTO DetainedLicences (LicenceID,DetainDate,FineFees,CreatedByUserID,IsReleased) VALUES 
                            (@LicenceID,@DetainDate,@FineFees,@CreatedByUserID,@IsReleased); SELECT SCOPE_IDENTITY();";

            SqlCommand cmd = new SqlCommand(Query, con);

            cmd.Parameters.AddWithValue("@LicenceID",LicenceID);
            cmd.Parameters.AddWithValue("@DetainDate",detainDate);
            cmd.Parameters.AddWithValue("@FineFees",FineFees);
            cmd.Parameters.AddWithValue("@CreatedByUserID",CreatedByUserID);
            cmd.Parameters.AddWithValue("@IsReleased",IsReleased);

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

        public static bool FindDetainedByLicenceID(ref int DetainID , ref int LicenceID , ref DateTime detainDate, ref decimal FineFees, ref int CreatedByUserID, ref bool IsReleased, ref DateTime ReleasedDate, ref int ReleasedByUserID, ref int ReleasedAppID)
        {
            bool Result = false;

            SqlConnection con = new SqlConnection(clsConnection.ConnectionString);
            string Query = @"SELECT * FROM DetainedLicences WHERE LicenceID = @ID and IsReleased != 1";

            SqlCommand cmd = new SqlCommand(Query, con);

            cmd.Parameters.AddWithValue("@ID",LicenceID);

            try
            {
                con.Open();

                SqlDataReader Reader = cmd.ExecuteReader();

                if (Reader.Read())
                {
                    Result = true;

                    DetainID = (int)Reader["DetainID"];
                    detainDate = (DateTime)Reader["DetainDate"];
                    FineFees = (decimal)Reader["FineFees"];
                    CreatedByUserID = (int)Reader["CreatedByUserID"];
                    IsReleased = (bool)Reader["IsReleased"];
                    if (Reader["ReleasedDate"] != System.DBNull.Value)
                        ReleasedDate = (DateTime)Reader["ReleasedDate"];
                    else
                        ReleasedDate = default(DateTime);

                    if (Reader["RealeasedByUserID"] != System.DBNull.Value)
                        ReleasedByUserID = (int)Reader["RealeasedByUserID"];
                    else
                        ReleasedByUserID = -1;

                    if (Reader["ReleaseApplicationID"] != System.DBNull.Value)
                        ReleasedAppID = (int)Reader["ReleaseApplicationID"];
                    else
                        ReleasedAppID = -1;
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

        public static DataTable GetDataFromDetainAndReleaseLicenses()
        {
            DataTable Table = new DataTable();

            SqlConnection Connection = new SqlConnection(clsConnection.ConnectionString);
            string Query = @"select DetainedLicences.DetainID , Licences.LicenceID , DetainedLicences.DetainDate , DetainedLicences.IsReleased , 
                             DetainedLicences.FineFees , DetainedLicences.ReleasedDate , People.NationalNo , People.FirstName+' '+People.SecondName+' '+People.ThirdName+' '+People.LastName as FullName,DetainedLicences.ReleaseApplicationID from DetainedLicences  
                              inner join Licences ON Licences.LicenceID = DetainedLicences.LicenceID inner join Applications ON Applications.ApplicationID = Licences.ApplicationID inner join People ON People.PersonID = ApplicationPersonID;";

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

    }
}
