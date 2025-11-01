using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public static class clsDataAccessLayerTestTypes
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

        public static bool Find(ref int ID ,ref string title ,ref string Description, ref decimal fees)
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

    }
}
