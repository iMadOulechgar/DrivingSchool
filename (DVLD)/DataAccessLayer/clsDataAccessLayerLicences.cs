using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Deployment.Internal;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public static class clsDataAccessLayerLicences
    {

        public static int AddLicence(int AppID,int DriverID,int LicenceClassID,DateTime issueDate,DateTime ExpirationDate,string Notes,decimal PaidFees,bool IsActive,short IssueReason,int CreatedByUser)
        {
            int Number = -1;

            SqlConnection Connection = new SqlConnection(clsConnection.ConnectionString);

            string Query = @"INSERT INTO Licences(ApplicationID,DriverID,LicenceClass,IssueDate,ExpirationDate,
                    Notes,PaidFees,IsActive,IssueReason,CreatedByUserID) VALUES 
                    (@ApplicationID,@DriverID,@LicenceClass,@IssueDate,@ExpirationDate,@Notes,@PaidFees,@IsActive,@IssueReason,@CreatedByUserID);
                       SELECT SCOPE_IDENTITY();";

            SqlCommand cmd = new SqlCommand(Query, Connection);

            cmd.Parameters.AddWithValue("@ApplicationID", AppID);
            cmd.Parameters.AddWithValue("@DriverID", DriverID);
            cmd.Parameters.AddWithValue("@LicenceClass", LicenceClassID);
            cmd.Parameters.AddWithValue("@IssueDate", issueDate);
            cmd.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            cmd.Parameters.AddWithValue("@Notes", Notes);
            cmd.Parameters.AddWithValue("@PaidFees", PaidFees);
            cmd.Parameters.AddWithValue("@IsActive", IsActive);
            cmd.Parameters.AddWithValue("@IssueReason", IssueReason);
            cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUser);
        

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

        public static bool FindLicenceByAppID(ref int LicenceID ,ref int AppID, ref int DriverID, ref int LicenceClassID, ref DateTime issueDate, ref DateTime ExpirationDate, ref string Notes, ref decimal PaidFees, ref bool IsActive, ref byte IssueReason, ref int CreatedByUser)
        {
            bool result = false;

            SqlConnection con = new SqlConnection(clsConnection.ConnectionString);
            string Query = @"SELECT * FROM Licences WHERE ApplicationID = @Id";
            SqlCommand cmd = new SqlCommand(Query, con);

            cmd.Parameters.AddWithValue("@Id", AppID);

            try
            {
                con.Open();

                SqlDataReader Reader = cmd.ExecuteReader();

                if (Reader.Read())
                {
                    result = true;

                    LicenceID = (int)Reader["LicenceID"];
                    AppID = (int)Reader["ApplicationID"];
                    DriverID = (int)Reader["DriverID"];
                    LicenceClassID = (int)Reader["LicenceClass"];
                    issueDate = (DateTime)Reader["IssueDate"];
                    ExpirationDate = (DateTime)Reader["ExpirationDate"];

                    if (Reader["Notes"] != DBNull.Value)
                        Notes = (string)Reader["Notes"];
                    else
                        Notes = "";

                    if (Reader["PaidFees"] != DBNull.Value)
                        PaidFees = (decimal)Reader["PaidFees"];
                    else
                        PaidFees = 0;

                    
                    IsActive = (bool)Reader["IsActive"];
                    IssueReason = (byte)Reader["IssueReason"];
                    CreatedByUser = (int)Reader["CreatedByUserID"];
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

        public static bool FindLicenceByLicenceID(ref int LicenceID, ref int AppID, ref int DriverID, ref int LicenceClassID, ref DateTime issueDate, ref DateTime ExpirationDate, ref string Notes, ref decimal PaidFees, ref bool IsActive, ref byte IssueReason, ref int CreatedByUser)
        {
            bool result = false;

            SqlConnection con = new SqlConnection(clsConnection.ConnectionString);
            string Query = @"SELECT * FROM Licences WHERE LicenceID = @Id ";
            SqlCommand cmd = new SqlCommand(Query, con);

            cmd.Parameters.AddWithValue("@Id", LicenceID);

            try
            {
                con.Open();

                SqlDataReader Reader = cmd.ExecuteReader();

                if (Reader.Read())
                {
                    result = true;

                    LicenceID = (int)Reader["LicenceID"];
                    AppID = (int)Reader["ApplicationID"];
                    DriverID = (int)Reader["DriverID"];
                    LicenceClassID = (int)Reader["LicenceClass"];
                    issueDate = (DateTime)Reader["IssueDate"];
                    ExpirationDate = (DateTime)Reader["ExpirationDate"];

                    if (Reader["Notes"] != DBNull.Value)
                        Notes = (string)Reader["Notes"];
                    else
                        Notes = "";

                    if (Reader["PaidFees"] != DBNull.Value)
                        PaidFees = (decimal)Reader["PaidFees"];
                    else
                        PaidFees = 0;


                    IsActive = (bool)Reader["IsActive"];
                    IssueReason = (byte)Reader["IssueReason"];
                    CreatedByUser = (int)Reader["CreatedByUserID"];
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

        public static DataTable GetAllFromLicenceTableByApplicationID(int AppID)
        {
            DataTable Dt = new DataTable();

            SqlConnection con = new SqlConnection(clsConnection.ConnectionString);
            string Query = "SELECT * FROM Licences WHERE ApplicationID = @ID";

            SqlCommand cmd = new SqlCommand(Query, con);

            cmd.Parameters.AddWithValue("@ID",AppID);

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

        public static bool IsLicenceExists(int LicenceID)
        {
            bool result = false;

            SqlConnection con = new SqlConnection(clsConnection.ConnectionString);
            string Query = @"SELECT * FROM Licences WHERE (LicenceID = @Id and LicenceClass = 3) and IsActive = 1";
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

        public static bool IsLicenceExistsByAppID(int AppID)
        {
            bool result = false;

            SqlConnection con = new SqlConnection(clsConnection.ConnectionString);
            string Query = @"SELECT * FROM Licences WHERE ApplicationID = @Id";
            SqlCommand cmd = new SqlCommand(Query, con);

            cmd.Parameters.AddWithValue("@Id", AppID);

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

        public static bool CheckIsLicenceExpiratedOrNot(int LicenceID)
        {
            bool result = false;

            SqlConnection con = new SqlConnection(clsConnection.ConnectionString);
            string Query = @"SELECT * FROM Licences WHERE (LicenceID = @Id and ExpirationDate < GETDATE()) and IsActive = 1";
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

        public static bool UpdateLicenceinActiveIt(int LicenceID)
        {
            bool result = false;

            SqlConnection con = new SqlConnection(clsConnection.ConnectionString);
            string Query = @"UPDATE Licences SET IsActive = 0 WHERE LicenceID = @ID";
            SqlCommand cmd = new SqlCommand(Query, con);

            cmd.Parameters.AddWithValue("@ID", LicenceID);

            try
            {
                con.Open();
                int num  = cmd.ExecuteNonQuery();

                if (num > 0)
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

        public static DataTable GetDataLicencesByDriverID(int DriverID)
        {
            DataTable Dt = new DataTable();

            SqlConnection con = new SqlConnection(clsConnection.ConnectionString);
            string Query = "SELECT * FROM Licences WHERE DriverID = @ID";

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

        public static bool CheckIsLicenceActive(int LicenceID)
        {
            bool result = false;

            SqlConnection con = new SqlConnection(clsConnection.ConnectionString);
            string Query = @"SELECT * FROM Licences WHERE LicenceID = @Id and IsActive = 1";
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


    }
}
