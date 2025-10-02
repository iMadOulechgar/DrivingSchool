using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    static class clsPersone
    {

        static void AddPersone(int NationalNum , string Firstname , string SecondName , string ThirdName,
            string LastName , DateTime DateOfBirth , bool Gendor , string Address , string Phone,
            string Email , int CountryID , string ImgPath
            )
        {

            SqlConnection Connection = new SqlConnection(clsConnection.Connection);

            string Query = @"INSERT INTO People(NationalNo,FirstName,SecondName,ThirdName,LastName
                    DateOfBirth,Gendor,Address,Phone,Email,NationalityCountryID,ImagePath) VALUES 
                    (@NationalNum,@Firstname,@SecondName,@ThirdName,@LastName,@DateOfBirth,@Gendor,@Address,@Phone,@Email,@CountryID,@ImgPath)";
           
            SqlCommand cmd = new SqlCommand(Query,Connection);

            cmd.Parameters.AddWithValue("@NationalNum",NationalNum);
            cmd.Parameters.AddWithValue("@Firstname", Firstname);
            cmd.Parameters.AddWithValue("@SecondName", SecondName);
            cmd.Parameters.AddWithValue("@ThirdName", ThirdName);
            cmd.Parameters.AddWithValue("@LastName", LastName);
            cmd.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            cmd.Parameters.AddWithValue("@Gendor", Gendor);
            cmd.Parameters.AddWithValue("@Address", Address);
            cmd.Parameters.AddWithValue("@Phone", Phone);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@CountryID", CountryID);
            cmd.Parameters.AddWithValue("@ImgPath", ImgPath);

            try
            {
                Connection.Open();

                int Result = cmd.ExecuteNonQuery();

                if (Result > 0)
                    Console.WriteLine("The Persone In DB Susccesfly :)");
                else
                    Console.WriteLine("Something Wrong /:");
                
            }
            catch (Exception ex)
            {
                //Later
            }
            finally
            {
                Connection.Close();
            }

        }
    }
}
