using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    static public class clsDataAccessLayerTestAppointmentAndTest
    {
       
        static public bool IsRowsExists(int Localid , int TestType)
        {
            bool result = false;

            SqlConnection con = new SqlConnection(clsConnection.ConnectionString);
            string Query = @"SELECT * FROM TestAppointments WHERE LocalDrivingLicenceApplicationID = @id AND TestTypeID = @TestID";

            SqlCommand cmd = new SqlCommand(Query,con);

            cmd.Parameters.AddWithValue("@id", Localid);
            cmd.Parameters.AddWithValue("@TestID", TestType);

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

        static public bool CheckIfIsThereAlreadyAnAppointment(int TestType)
        {
            bool Result = false;

            SqlConnection con = new SqlConnection(clsConnection.ConnectionString);
            string Query = @"select 'yes' as result from TestAppointments inner join LocalDrivingLicenceApplications ON TestAppointments.LocalDrivingLicenceApplicationID = LocalDrivingLicenceApplications.LocalDrivingLicenceApplicationID Where TestAppointments.IsLocked != 1 and TestTypeID = @TestID;";

            SqlCommand cmd = new SqlCommand(Query,con);

            cmd.Parameters.AddWithValue("@TestID", TestType);

            try
            {
                con.Open();

                object Obj = cmd.ExecuteScalar();

                if (Obj != null)
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

        static public DataTable GetAllAppointmentFromDB(int LocalID,int TestType)
        {
            DataTable dt = new DataTable();

            SqlConnection con = new SqlConnection(clsConnection.ConnectionString);
            string Query = @"select TestAppointmentID , AppointmentDate , PaidFees , IsLocked from TestAppointments inner join  LocalDrivingLicenceApplications ON LocalDrivingLicenceApplications.LocalDrivingLicenceApplicationID = TestAppointments.LocalDrivingLicenceApplicationID where (LocalDrivingLicenceApplications.LocalDrivingLicenceApplicationID = @LocalID and TestTypeID = @TestType);";

            SqlCommand cmd = new SqlCommand(Query,con);

            cmd.Parameters.AddWithValue("@LocalID",LocalID);
            cmd.Parameters.AddWithValue("@TestType", TestType);

            try
            {
                con.Open();

                SqlDataReader Reader = cmd.ExecuteReader();

                if (Reader.HasRows)
                {
                    dt.Load(Reader);
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

            return dt;
        }

        static public int AddTest(int TestApp , byte TestResult , string Notes , int CreatedByUser)
        {
            int Result = -1;

            SqlConnection con = new SqlConnection(clsConnection.ConnectionString);
            string Query = "INSERT INTO Tests (TestAppointmentID,TestResult,Notes,CreatedByUserID)VALUES(@TestApp,@TestResult,@Notes,@CreatedByUser); SELECT SCOPE_IDENTITY();";

            SqlCommand cmd = new SqlCommand(Query,con);

            cmd.Parameters.AddWithValue("@TestApp",TestApp);
            cmd.Parameters.AddWithValue("@TestResult",TestResult);
            cmd.Parameters.AddWithValue("@Notes",Notes);
            cmd.Parameters.AddWithValue("@CreatedByUser",CreatedByUser);

            try
            {
                con.Open();

                object Obj = cmd.ExecuteScalar();

                if (int.TryParse(Obj.ToString(),out int Number))
                {
                    if (Number != -1)
                    {
                        Result = Number;
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

        static public bool UpdateDateOfAnAppointment(int APPID,DateTime SetDate)
        {
            bool result = false;

            SqlConnection con = new SqlConnection(clsConnection.ConnectionString);
            string Query = @"UPDATE TestAppointments SET AppointmentDate = @Date WHERE TestAppointmentID = @APP;";


            SqlCommand cmd = new SqlCommand(Query, con);

            cmd.Parameters.AddWithValue("@APP", APPID);
            cmd.Parameters.AddWithValue("@Date", SetDate);

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

        public static int AddTestAppointment(int TestID,int LocalDrivingLicenceAppId, DateTime AppointmentDate, decimal PaidFees, int Userid, bool Islocked)
        {
            int Result = -1;

            SqlConnection con = new SqlConnection(clsConnection.ConnectionString);
            string Query = @"INSERT INTO TestAppointments (TestTypeID,LocalDrivingLicenceApplicationID,AppointmentDate,PaidFees,CreatedByUserID,IsLocked)
                            VALUES (@TestTypeID,@LocalDrivingLicenceAppId,@AppointmentDate,@PaidFees,@Userid,@Islocked) SELECT SCOPE_IDENTITY();";

            SqlCommand cmd = new SqlCommand(Query, con);

            cmd.Parameters.AddWithValue("@TestTypeID", TestID);
            cmd.Parameters.AddWithValue("@LocalDrivingLicenceAppId", LocalDrivingLicenceAppId);
            cmd.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            cmd.Parameters.AddWithValue("@PaidFees", PaidFees);
            cmd.Parameters.AddWithValue("@Userid", Userid);
            cmd.Parameters.AddWithValue("@Islocked", Islocked);

            try
            {
                con.Open();

                object Obj = cmd.ExecuteScalar();

                if (int.TryParse(Obj.ToString(), out int Number))
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

        public static bool CheckIfPass(int LocalId,int TestType)
        {
            bool result = false;

            SqlConnection con = new SqlConnection(clsConnection.ConnectionString);
            string Query = @"select 'Yes' as result from LocalDrivingLicenceApplications inner join TestAppointments ON TestAppointments.LocalDrivingLicenceApplicationID = LocalDrivingLicenceApplications.LocalDrivingLicenceApplicationID inner join Tests ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID 
                               where  (LocalDrivingLicenceApplications.LocalDrivingLicenceApplicationID = @LocalId AND TestResult != 0) AND (TestTypeID = @TestType);";


            SqlCommand cmd = new SqlCommand(Query, con);

            cmd.Parameters.AddWithValue("@LocalId", LocalId);
            cmd.Parameters.AddWithValue("@TestType", TestType);

            try
            {
                con.Open();

                object Obj = cmd.ExecuteScalar();

                if (Obj != null)
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

        public static bool UpdateAppTypeByAppId(int AppID,int AppTypeID)
        {
            bool result = false;

            SqlConnection con = new SqlConnection(clsConnection.ConnectionString);
            string Query = @"UPDATE Applications SET ApplicationTypeID = @AppTypeID WHERE ApplicationID = @Id;";


            SqlCommand cmd = new SqlCommand(Query, con);

            cmd.Parameters.AddWithValue("@Id", AppID);
            cmd.Parameters.AddWithValue("@AppTypeID", AppTypeID);

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

        public static bool LockTheAppointmentWhenTheTestIsFinish(int TestAppID)
        {
            bool Result = false;

            SqlConnection con = new SqlConnection(clsConnection.ConnectionString);
            string Query = "Update TestAppointments SET IsLocked = 1 WHERE TestAppointmentID = @ID;";

            SqlCommand cmd = new SqlCommand(Query, con);

            cmd.Parameters.AddWithValue("@ID", TestAppID);

            try
            {
                con.Open();

                int num = cmd.ExecuteNonQuery();
                
                if (num > 0)
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

        public static bool FindAppinttmentByAppID(ref int appID,ref int TestTypeID,ref int LDLAID,ref DateTime AppointmentDate, ref decimal PaidFees, ref int CreatedByUser, ref bool islocked)
        {
            bool result = false;

            SqlConnection con = new SqlConnection(clsConnection.ConnectionString);
            string Query = "SELECT * FROM TestAppointments WHERE TestAppointmentID = @ID";
            SqlCommand cmd = new SqlCommand(Query, con);

            cmd.Parameters.AddWithValue("@ID", appID);

            try
            {
                con.Open();

                SqlDataReader Reader = cmd.ExecuteReader();

                if (Reader.Read())
                {
                    result = true;

                    TestTypeID = (int)Reader["TestTypeID"];
                    LDLAID = (int)Reader["LocalDrivingLicenceApplicationID"];
                    AppointmentDate = (DateTime)Reader["AppointmentDate"];
                    PaidFees = (decimal)Reader["PaidFees"];
                    CreatedByUser = (int)Reader["CreatedByUserID"];
                    islocked = (bool)Reader["Islocked"];
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

        public static int GetTrialByLDLIDandTestType(int LocalId , int testtype)
        {
            int Result = -1;

            SqlConnection con = new SqlConnection(clsConnection.ConnectionString);
            string Query = @"select COUNT(*) from Tests inner join TestAppointments on Tests.TestAppointmentID = TestAppointments.TestAppointmentID inner join LocalDrivingLicenceApplications ON
                       LocalDrivingLicenceApplications.LocalDrivingLicenceApplicationID = TestAppointments.LocalDrivingLicenceApplicationID WHERE TestAppointments.TestTypeID = @testType and TestAppointments.LocalDrivingLicenceApplicationID = @LocalID;";

            SqlCommand cmd = new SqlCommand(Query, con);

            cmd.Parameters.AddWithValue("@testType", testtype);
            cmd.Parameters.AddWithValue("@LocalID", LocalId);

            try
            {
                con.Open();

                object Obj = cmd.ExecuteScalar();

                if (int.TryParse(Obj.ToString(), out int Number))
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

        public static decimal PaidFees(int TestType)
        {
            decimal Result = 0;

            SqlConnection con = new SqlConnection(clsConnection.ConnectionString);
            string Query = @"select TestTypeFees from TestTypes where TestTypeID = @TestID;";

            SqlCommand cmd = new SqlCommand(Query, con);

            cmd.Parameters.AddWithValue("@TestID", TestType);

            try
            {
                con.Open();

                object Obj = cmd.ExecuteScalar();

                if (Obj != null)
                {
                    Result=(decimal)Obj;
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

        public static int GetTestTypeByLocalID(int LDLID)
        {
            int Result = -1;

            SqlConnection con = new SqlConnection(clsConnection.ConnectionString);
            string Query = @"SELECT TestAppointments.TestTypeID from TestAppointments inner join Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID inner join LocalDrivingLicenceApplications ON LocalDrivingLicenceApplications.LocalDrivingLicenceApplicationID = TestAppointments.LocalDrivingLicenceApplicationID where (TestTypeID = 3 and Tests.TestResult = 1) and LocalDrivingLicenceApplications.LocalDrivingLicenceApplicationID = @LocalID;";

            SqlCommand cmd = new SqlCommand(Query, con);

            cmd.Parameters.AddWithValue("@LocalID", LDLID);

            try
            {
                con.Open();

                object Obj = cmd.ExecuteScalar();

                if (Obj != null)
                {
                    if (int.TryParse(Obj.ToString(), out int Number))
                    {
                        Result = Number;
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

        




    }
}
