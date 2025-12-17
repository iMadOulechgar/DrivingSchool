using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public static class clsCountrieData
    {

        public static bool GetCountryNameById(int id , ref string CountryName)
        {
            bool Result = false;
            SqlConnection connection = new SqlConnection(clsConnection.ConnectionString);
            string Query = "SELECT * FROM Countries WHERE CountryID = @id";

            SqlCommand cmd = new SqlCommand(Query, connection);

            cmd.Parameters.AddWithValue("@id", id);

            try
            {
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    Result = true;
                    CountryName = (string)reader["CountryName"];
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { connection.Close(); }

                return Result;

        }

        public static bool GetCountryIdByName(string Name , ref int CountryID)
        {
            bool Result = false;
            SqlConnection connection = new SqlConnection(clsConnection.ConnectionString);
            string Query = "SELECT * FROM Countries WHERE CountryName = @Name";

            SqlCommand cmd = new SqlCommand(Query, connection);

            cmd.Parameters.AddWithValue("@Name", Name);

            try
            {
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    Result = true;
                    CountryID = (int)reader["CountryID"];
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return Result;
        }

        public static DataTable GetAllCountrysName()
        {
            DataTable TableCountry = new DataTable();
            SqlConnection Connection = new SqlConnection(clsConnection.ConnectionString);
            string Query = @"SELECT * FROM Countries order by CountryName";
            SqlCommand cmd = new SqlCommand(Query, Connection);

            try
            {
                Connection.Open();

                SqlDataReader Reader = cmd.ExecuteReader();

                if (Reader.HasRows)
                {
                    TableCountry.Load(Reader);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Connection.Close();
            }

            return TableCountry;
        }


    }
}
