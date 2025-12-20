using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public static class clsDataAccessLayerTypeTests
    {
        
        public static DataTable GetALlDataFromDB()
        {
            DataTable dt = new DataTable();

            SqlConnection con = new SqlConnection(clsConnection.ConnectionString);
            string Query = @"SELECT * FROM TestTypes";
            SqlCommand cmd = new SqlCommand(Query,con);

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

        public static bool Find(int ID ,ref string title ,ref string Description, ref decimal fees)
        {
            bool result = false;

            SqlConnection con = new SqlConnection(clsConnection.ConnectionString);
            string Query = "SELECT * FROM TestTypes WHERE TestTypeID = @id";
            SqlCommand command = new SqlCommand(Query, con);

            command.Parameters.AddWithValue("@id", ID);

            try
            {
                con.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    result = true;

                    ID = (int)reader["TestTypeID"];
                    title = (string)reader["TestTypeTitle"];
                    Description = (string)reader["TestTypeDescription"];
                    fees = (decimal)reader["TestTypeFees"];
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

        public static bool Update(int ID , string Title , string Desc , decimal fees)
        {
            bool result = false;

            SqlConnection con = new SqlConnection(clsConnection.ConnectionString);
            string Query = @"UPDATE TestTypes SET TestTypeTitle = @title , TestTypeDescription = @Desc , TestTypeFees = @Fees WHERE TestTypeID = @id";

            SqlCommand cmd = new SqlCommand(Query, con);

            cmd.Parameters.AddWithValue("@title", Title);
            cmd.Parameters.AddWithValue("@Desc", Desc);
            cmd.Parameters.AddWithValue("@Fees", fees);
            cmd.Parameters.AddWithValue("@id", ID);

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
            finally { con.Close(); }

            return result;
        }

        public static int AddNewTestType(string Title, string Description, decimal Fees)
        {
            int TestTypeID = -1;

            SqlConnection connection = new SqlConnection(clsConnection.ConnectionString);

            string query = @"Insert Into TestTypes (TestTypeTitle,TestTypeTitle,TestTypeFees)
                            Values (@TestTypeTitle,@TestTypeDescription,@ApplicationFees)
                            where TestTypeID = @TestTypeID;
                            SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestTypeTitle", Title);
            command.Parameters.AddWithValue("@TestTypeDescription", Description);
            command.Parameters.AddWithValue("@ApplicationFees", Fees);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    TestTypeID = insertedID;
                }
            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);

            }

            finally
            {
                connection.Close();
            }


            return TestTypeID;

        }

    }
}
