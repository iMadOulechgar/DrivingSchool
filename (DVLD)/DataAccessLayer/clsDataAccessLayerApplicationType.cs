using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public static class clsDataAccessLayerApplicationType
    {
        public static DataTable GetAllApplicationTypes()
        {
            DataTable dt = new DataTable();

            SqlConnection con = new SqlConnection(clsConnection.ConnectionString);
            string Query = "SELECT * FROM ApplicationTypes";
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

        public static bool FindByAppTypeID(ref int ID ,ref string title , ref decimal fees)
        {
            bool result = false;
            SqlConnection con = new SqlConnection(clsConnection.ConnectionString);
            string Query = "SELECT * FROM ApplicationTypes WHERE ApplicationTypeID = @id";
            SqlCommand command = new SqlCommand(Query,con);

            command.Parameters.AddWithValue("@id",ID);

            try
            {
                con.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    result = true;

                    ID = (int)reader["ApplicationTypeID"];
                    title = (string)reader["ApplicationTypeTitle"];
                    fees = (decimal)reader["ApplicationFees"];
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

        public static bool UpdateAppType(int ID , string Title , decimal fees)
        {
            bool result = false;

            SqlConnection con = new SqlConnection(clsConnection.ConnectionString);
            string Query = @"UPDATE ApplicationTypes SET ApplicationTypeTitle = @title , ApplicationFees = @fees WHERE ApplicationTypeID = @id";

            SqlCommand cmd = new SqlCommand(Query,con);

            cmd.Parameters.AddWithValue("@title", Title);
            cmd.Parameters.AddWithValue("@fees", fees);
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

        public static string GetTypeNameByID(int id)
        {
            string Type = "";

            SqlConnection con = new SqlConnection(clsConnection.ConnectionString);
            string Query = "SELECT TestTypeTitle FROM TestTypes WHERE TestTypeID = @id ";

            SqlCommand cmd = new SqlCommand(Query, con);

            cmd.Parameters.AddWithValue("@id", id);

            try
            {
                con.Open();

                object Obj = cmd.ExecuteScalar();

                Type = Obj.ToString();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }

            return Type;
        }

        public static string GetApplicationTypesByAppID(int id)
        {
            string Type = "";

            SqlConnection con = new SqlConnection(clsConnection.ConnectionString);
            string Query = "SELECT ApplicationTypeTitle FROM ApplicationTypes WHERE ApplicationTypeID = @id ";

            SqlCommand cmd = new SqlCommand(Query, con);

            cmd.Parameters.AddWithValue("@id", id);

            try
            {
                con.Open();

                object Obj = cmd.ExecuteScalar();

                Type = Obj.ToString();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }

            return Type;
        }

        public static decimal GetFeesByTypeID(int TypeId)
        {
            decimal Type = 0;

            SqlConnection con = new SqlConnection(clsConnection.ConnectionString);
            string Query = "SELECT ApplicationFees FROM ApplicationTypes WHERE ApplicationTypeID = @id ";

            SqlCommand cmd = new SqlCommand(Query, con);

            cmd.Parameters.AddWithValue("@id", TypeId);

            try
            {
                con.Open();

                object Obj = cmd.ExecuteScalar();

                Type = Convert.ToDecimal(Obj);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }

            return Type;
        }

    }
}
