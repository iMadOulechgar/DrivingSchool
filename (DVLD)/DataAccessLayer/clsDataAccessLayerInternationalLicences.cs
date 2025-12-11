using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public static class clsDataAccessLayerInternationalLicences
    {

        public static int AddInternationalLicence(int appID, int driverID, int licenceID, DateTime issuedate, DateTime expirationdate, bool isactive, int createdbyuserid)
        {
            int Number = -1;

            SqlConnection Connection = new SqlConnection(clsConnection.ConnectionString);

            string Query = @"INSERT INTO InternationalLicences(ApplicationID,DriverID,IssuedUsingLocalLicenceID,IssueDate,ExpirationDate,
                          IsActive,CreatedByUserID) VALUES 
                    (@ApplicationID,@DriverID,@LicenceID,@IssueDate,@ExpirationDate,@IsActive,@CreatedByUserID);
                       SELECT SCOPE_IDENTITY();";

            SqlCommand cmd = new SqlCommand(Query, Connection);

            cmd.Parameters.AddWithValue("@ApplicationID", appID);
            cmd.Parameters.AddWithValue("@DriverID", driverID);
            cmd.Parameters.AddWithValue("@LicenceID", licenceID);
            cmd.Parameters.AddWithValue("@IssueDate", issuedate);
            cmd.Parameters.AddWithValue("@ExpirationDate", expirationdate);
            cmd.Parameters.AddWithValue("@IsActive", isactive);
            cmd.Parameters.AddWithValue("@CreatedByUserID", createdbyuserid);

            try
            {
                Connection.Open();

                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    if (int.TryParse(result.ToString(), out int Num))
                    {
                        Number = Num;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
            finally
            {
                Connection.Close();
            }

            return Number;
        }

        public static bool FindInterNationalLicence(ref int IntLicenceID, ref int appID, ref int driverID, ref int licenceID, ref DateTime issuedate, ref DateTime expirationdate, ref bool isactive, ref int createdbyuserid)
        {
            bool result = false;

            SqlConnection con = new SqlConnection(clsConnection.ConnectionString);
            string Query = "SELECT * FROM InternationalLicences WHERE InternationalLicenceID = @ID";

            SqlCommand cmd = new SqlCommand(Query, con);

            cmd.Parameters.AddWithValue("@ID", IntLicenceID);

            try
            {
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    result = true;

                    IntLicenceID = (int)reader["InternationalLicenceID"];
                    appID = (int)reader["ApplicationID"];
                    driverID = (int)reader["DriverID"];
                    licenceID = (int)reader["IssuedUsingLocalLicenceID"];
                    issuedate = (DateTime)reader["IssueDate"];
                    expirationdate = (DateTime)reader["ExpirationDate"];
                    isactive = (bool)reader["IsActive"];
                    createdbyuserid = (int)reader["CreatedByUserID"];
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


            return result;

        }

        public static bool FindInterNationalLicenceByLicenceID(ref int IntLicenceID, ref int appID, ref int driverID, ref int licenceID, ref DateTime issuedate, ref DateTime expirationdate, ref bool isactive, ref int createdbyuserid)
        {
            bool result = false;

            SqlConnection con = new SqlConnection(clsConnection.ConnectionString);
            string Query = "SELECT * FROM InternationalLicences WHERE IssuedUsingLocalLicenceID = @ID";

            SqlCommand cmd = new SqlCommand(Query, con);

            cmd.Parameters.AddWithValue("@ID", licenceID);

            try
            {
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    result = true;

                    IntLicenceID = (int)reader["InternationalLicenceID"];
                    appID = (int)reader["ApplicationID"];
                    driverID = (int)reader["DriverID"];
                    licenceID = (int)reader["IssuedUsingLocalLicenceID"];
                    issuedate = (DateTime)reader["IssueDate"];
                    expirationdate = (DateTime)reader["ExpirationDate"];
                    isactive = (bool)reader["IsActive"];
                    createdbyuserid = (int)reader["CreatedByUserID"];
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


            return result;

        }

        public static DataTable GetAllRowsFromInternationalLicences()
        {
            DataTable Table = new DataTable();

            SqlConnection Connection = new SqlConnection(clsConnection.ConnectionString);
            string Query = "SELECT * FROM InternationalLicences";

            SqlCommand cmd = new SqlCommand(Query, Connection);

            try
            {
                Connection.Open();

                SqlDataReader Reader = cmd.ExecuteReader();

                if (Reader.HasRows)
                {
                    Table.Load(Reader);
                }

                Reader.Close();
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

        public static bool IsThePersonHaveAlreadyInternationalLicence(int LicenceID)
        {
            bool result = false;

            SqlConnection con = new SqlConnection(clsConnection.ConnectionString);
            string Query = @"SELECT * FROM InternationalLicences WHERE IssuedUsingLocalLicenceID = @Id";
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

        public static DataTable GetAllFromInternationalLicenceTableByApplicationID(int DriverID)
        {
            DataTable Dt = new DataTable();

            SqlConnection con = new SqlConnection(clsConnection.ConnectionString);
            string Query = "SELECT * FROM InternationalLicences WHERE DriverID = @ID";

            SqlCommand cmd = new SqlCommand(Query, con);

            cmd.Parameters.AddWithValue("@ID", DriverID);

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

        public static DataTable GetAllFromInternationalLicenceTable()
        {
            DataTable Dt = new DataTable();

            SqlConnection con = new SqlConnection(clsConnection.ConnectionString);
            string Query = "SELECT * FROM InternationalLicences";

            SqlCommand cmd = new SqlCommand(Query, con);

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
