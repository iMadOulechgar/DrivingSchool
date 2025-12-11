using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    static public class clsDataAccessLayerApplication
    {
        static public DataTable GetAllLicenceClassesNames()
        {
            DataTable dt = new DataTable();

            SqlConnection con = new SqlConnection(clsConnection.ConnectionString);
            string Query = "SELECT ClassName FROM LicenceClasses";
            SqlCommand cmd= new SqlCommand(Query, con);

            try
            {
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
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

            return dt;
        }

        static public string GetLicenceClassesNameByID(int id)
        {
            string Result = "";

            SqlConnection con = new SqlConnection(clsConnection.ConnectionString);
            string Query = "SELECT ClassName FROM LicenceClasses WHERE LicenceClassID = @ID";
            SqlCommand cmd = new SqlCommand(Query, con);

            cmd.Parameters.AddWithValue("@ID",id);

            try
            {
                con.Open();

                object OBJ = cmd.ExecuteScalar();

                if (OBJ != null)
                {
                    Result = OBJ.ToString();
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

        static public int AddApplication(int PersoneID , DateTime AppDate ,byte AppStatus, int AppTypeID, DateTime LastStatusDate , decimal PaidFees , int UsersId)
        {
            int result = -1;

            SqlConnection con = new SqlConnection(clsConnection.ConnectionString);
            string Query = @"INSERT INTO Applications(ApplicationPersonID,ApplicationDate,
                    ApplicationTypeID,ApplicationStatus,LastStatusDate,PaidFees,CreatedByUserID)
                        VALUES (@PersoneID,@AppDate,@AppTypeID,@AppStatus,@LastStatusDate,@PaidFees,@UsersId); SELECT SCOPE_IDENTITY();"; 

            SqlCommand cmd = new SqlCommand(Query, con);

            cmd.Parameters.AddWithValue("@PersoneID",PersoneID);
            cmd.Parameters.AddWithValue("@AppDate", AppDate);
            cmd.Parameters.AddWithValue("@AppTypeID", AppTypeID);
            cmd.Parameters.AddWithValue("@AppStatus", AppStatus);
            cmd.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
            cmd.Parameters.AddWithValue("@PaidFees", PaidFees);
            cmd.Parameters.AddWithValue("@UsersId", UsersId);

            try
            {
                con.Open();

                object Num = cmd.ExecuteScalar();

                if (int.TryParse(Num.ToString(), out int Number))
                    result = Number;

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

        static public int AddLocalDrivingLicenceApp(int ApplicationID , int LicenceClassID)
        {
            int result = -1;

            SqlConnection con = new SqlConnection(clsConnection.ConnectionString);
            string Query = @"INSERT INTO LocalDrivingLicenceApplications (ApplicationID,LicenceClassID) VALUES (@ApplicationID,@LicenceClassID);
                                 SELECT SCOPE_IDENTITY();";

            SqlCommand cmd = new SqlCommand(Query,con);

            cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            cmd.Parameters.AddWithValue("@LicenceClassID", LicenceClassID);

            try
            {
                con.Open();

                object Num = cmd.ExecuteScalar();

                if (int.TryParse(Num.ToString(),out int Number))
                    result = Number;

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

        static public DataTable GetLocalDrivingLicenceAppFromView()
        {
            DataTable Dt = new DataTable();

            SqlConnection con = new SqlConnection(clsConnection.ConnectionString);
            string Query = "SELECT * FROM LocalDrivingLicenseApplications_View";

            SqlCommand cmd = new SqlCommand(Query,con);

            try
            {
                con.Open();

                SqlDataReader Reader = cmd.ExecuteReader();

                Dt.Load(Reader);
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

        static public bool CheckPersoneHasSameOrder(int PersoneID,int ClassID)
        {
            bool Chackresult = false ;

            SqlConnection con = new SqlConnection(clsConnection.ConnectionString);
            string Query = @"select 'yes' as result from LocalDrivingLicenceApplications inner join Applications ON LocalDrivingLicenceApplications.ApplicationID = Applications.ApplicationID where 
                                 (Applications.ApplicationPersonID = @Per and LocalDrivingLicenceApplications.LicenceClassID = @ClassID) and (ApplicationStatus != 3);";

            SqlCommand cmd = new SqlCommand(Query,con);

            cmd.Parameters.AddWithValue("@ClassID", ClassID);
            cmd.Parameters.AddWithValue("@Per", PersoneID);

            try
            {
                con.Open();

                object Obj = cmd.ExecuteScalar();

                if (Obj != null)
                {
                    Chackresult = true;
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

            return Chackresult;
        }

        static public bool CancelTheOrder(int LocalID)
        {
            int check = -1;

            SqlConnection con = new SqlConnection(clsConnection.ConnectionString);
            string Query = @"UPDATE Applications
                            SET ApplicationStatus = 2 FROM Applications inner join LocalDrivingLicenceApplications ON  
                            Applications.ApplicationID = LocalDrivingLicenceApplications.LocalDrivingLicenceApplicationID 
                            WHERE LocalDrivingLicenceApplications.LocalDrivingLicenceApplicationID = @LocalID;";


            SqlCommand cmd = new SqlCommand(Query,con);

            cmd.Parameters.AddWithValue("@LocalID", LocalID);

            try
            {
                con.Open();

                int Num = cmd.ExecuteNonQuery();

                if (Num > 0)
                {
                    check = Num;
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

            return (check != -1);
        }

        static public int GetPersoneIdByLocalDrivingLicenceApp(int LDLA)
        {
            int result = -1;

            SqlConnection con = new SqlConnection(clsConnection.ConnectionString);
            string Query = @"select People.PersoneID from LocalDrivingLicenceApplication inner join Applications ON 
                           LocalDrivingLicenceApplication.ApplicationID = Applications.ApplicationID 
                            inner join People ON People.PersoneID = Applications.ApplicationPersoneID where LocalDrivingLicenceApplication.LocalDrivingLicenceID = @LDLA;";

            SqlCommand cmd = new SqlCommand(Query,con);

            cmd.Parameters.AddWithValue("@LDLA",LDLA);

            try
            {
                con.Open();

                object Obj = cmd.ExecuteScalar();

                if(int.TryParse(Obj.ToString(), out int ID))
                {
                    result = ID;
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

        static public bool GetLDLAByID(int LocalID ,ref int AppID ,ref int LicenceID)
        {
            bool Result = false;

            SqlConnection con = new SqlConnection(clsConnection.ConnectionString);
            string Query = "SELECT * FROM LocalDrivingLicenceApplications WHERE LocalDrivingLicenceApplicationID = @ID";

            SqlCommand cmd = new SqlCommand(Query,con);

            cmd.Parameters.AddWithValue("@ID",LocalID);

            try
            {
                con.Open();

                SqlDataReader Reader = cmd.ExecuteReader();

                if (Reader.Read())
                {
                    Result = true;

                    AppID = (int)Reader["ApplicationID"];
                    LicenceID = (int)Reader["LicenceClassID"];
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

        static public bool FindApplicationByID(int AppID , ref int PersoneID , ref DateTime Date , ref int AppTypeID , ref byte Status , ref DateTime LastDateStatus , ref decimal Fees , ref int CreatedByUserID)
        {

            bool Result = false;

            SqlConnection con = new SqlConnection(clsConnection.ConnectionString);
            string Query = "SELECT * FROM Applications WHERE ApplicationID = @ID";

            SqlCommand cmd = new SqlCommand(Query, con);

            cmd.Parameters.AddWithValue("@ID", AppID);

            try
            {
                con.Open();

                SqlDataReader Reader = cmd.ExecuteReader();

                if (Reader.Read())
                {
                    Result = true;

                    PersoneID = (int)Reader["ApplicationPersonID"];
                    Date = (DateTime)Reader["ApplicationDate"];
                    AppTypeID = (int)Reader["ApplicationTypeID"];
                    Status = (byte)Reader["ApplicationStatus"];
                    LastDateStatus = (DateTime)Reader["LastStatusDate"];
                    Fees = (decimal)Reader["PaidFees"];
                    CreatedByUserID = (int)Reader["CreatedByUserID"];
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

        static public string GetLicenceNameByLicenceID(int LicenceID)
        {
            string Result = "";

            SqlConnection con = new SqlConnection(clsConnection.ConnectionString);
            string Query = "select ClassName from LicenceClasses where LicenceClassesID = @LicenceID";

            SqlCommand cmd = new SqlCommand(Query, con);

            cmd.Parameters.AddWithValue("@LicenceID", LicenceID);

            try
            {
                con.Open();

                object OBJ = cmd.ExecuteScalar();

                Result = OBJ.ToString();
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

        static public string GetAppType(int Id)
        {
            string Result = "";

            SqlConnection con = new SqlConnection(clsConnection.ConnectionString);
            string Query = "select ApplicationTypeTitle from ApplicationTypes where ApplicationTypeID = @ID";

            SqlCommand cmd = new SqlCommand(Query, con);

            cmd.Parameters.AddWithValue("@ID", Id);

            try
            {
                con.Open();

                object OBJ = cmd.ExecuteScalar();

                Result = OBJ.ToString();
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

        public static bool UpdateApplicationComplet(int AppID)
        {
            bool result = false;

            SqlConnection con = new SqlConnection(clsConnection.ConnectionString);
            string Query = @"UPDATE Applications SET ApplicationStatus = 3 WHERE ApplicationID = @Id;";


            SqlCommand cmd = new SqlCommand(Query, con);

            cmd.Parameters.AddWithValue("@Id", AppID);

            try
            {
                con.Open();

                int num = cmd.ExecuteNonQuery();

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

        public static bool DeleteFromLocal(int LocalID)
        {
            bool result = false;

            SqlConnection con = new SqlConnection(clsConnection.ConnectionString);
            string Query = @"delete from LocalDrivingLicenceApplications where LocalDrivingLicenceApplicationID = @localID;";


            SqlCommand cmd = new SqlCommand(Query, con);

            cmd.Parameters.AddWithValue("@localID", LocalID);

            try
            {
                con.Open();

                int num = cmd.ExecuteNonQuery();

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



    }



}
