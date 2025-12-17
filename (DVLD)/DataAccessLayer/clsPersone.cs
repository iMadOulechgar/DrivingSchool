using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public static class clsPersone
    {
        public static int AddPersone(string NationalNum, string Firstname, string SecondName, string ThirdName,
            string LastName, DateTime DateOfBirth, int Gendor, string Address, string Phone,
            string Email, int CountryID, string ImgPath
            )
        {
            int Number = -1;

            SqlConnection Connection = new SqlConnection(clsConnection.ConnectionString);

            string Query = @"INSERT INTO People(NationalNo,FirstName,SecondName,ThirdName,LastName,
                    DateOfBirth,Gendor,Address,Phone,Email,NationalityCountryID,ImagePath) VALUES 
                    (@NationalNum,@Firstname,@SecondName,@ThirdName,@LastName,@DateOfBirth,@Gendor,@Address,@Phone,@Email,@CountryID,@ImgPath);
                       SELECT SCOPE_IDENTITY();";

            SqlCommand cmd = new SqlCommand(Query, Connection);

            cmd.Parameters.AddWithValue("@NationalNum", NationalNum);
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

                object result = cmd.ExecuteScalar();

                if (int.TryParse(result.ToString(), out int Num))
                {
                    Number = Num;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error in AddPersone: " + ex.Message);
            }
            finally
            {
                Connection.Close();
            }

            return Number;
        }

        public static bool DeletePersoneById(int Id)
        {
            int result = 0;

            SqlConnection connection = new SqlConnection(clsConnection.ConnectionString);

            string Query = @"DELETE FROM People WHERE PersoneID=@Id";

            SqlCommand cmd = new SqlCommand(Query, connection);

            cmd.Parameters.AddWithValue("@Id", Id);

            try
            {
                connection.Open();

                result = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return (result > 0);
        }

        public static bool FindPersoneById(ref int Id, ref string NationalNum, ref string Firstname, ref string SecondName, ref string ThirdName,
            ref string LastName, ref DateTime DateOfBirth, ref byte Gendor, ref string Address, ref string Phone,
           ref string Email, ref int CountryID, ref string ImgPath)
        {

            bool result = false;

            SqlConnection con = new SqlConnection(clsConnection.ConnectionString);
            string Query = @"SELECT * FROM People WHERE PersonID = @Id";
            SqlCommand cmd = new SqlCommand(Query, con);

            cmd.Parameters.AddWithValue("@Id", Id);

            try
            {
                con.Open();

                SqlDataReader Reader = cmd.ExecuteReader();

                if (Reader.Read())
                {
                    result = true;

                    NationalNum = (string)Reader["NationalNo"];
                    Firstname = (string)Reader["FirstName"];

                    if (Reader["SecondName"] != DBNull.Value)
                        SecondName = (string)Reader["SecondName"];
                    else
                        SecondName = "";

                    if (Reader["ThirdName"] != DBNull.Value)
                        ThirdName = (string)Reader["ThirdName"];
                    else
                        ThirdName = "";

                    LastName = (string)Reader["LastName"];
                    DateOfBirth = (DateTime)Reader["DateOfBirth"];
                    Gendor = (byte)Reader["Gendor"];
                    Address = (string)Reader["Address"];
                    Phone = (string)Reader["Phone"];

                    if (Reader["Email"] != DBNull.Value)
                        Email = (string)Reader["Email"];
                    else
                        Email = "";

                    CountryID = (int)Reader["NationalityCountryID"];

                    if (Reader["ImagePath"] != DBNull.Value)
                        ImgPath = (string)Reader["ImagePath"];
                    else
                        ImgPath = "";
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

        public static bool UpdatePersone(int id, string national, string firstname, string secondname, string thirdname, string lastname, DateTime dateofbirth,
            byte gendor, string address, string phone, string email, int countryid, string imgpath)
        {

            bool result = false;

            SqlConnection connection = new SqlConnection(clsConnection.ConnectionString);
            string Query = @"UPDATE People SET NationalNo = @national,FirstName = @firstname,
                                               SecondName = @secondname , ThirdName = @thirdname ,
                            LastName = @lastname , DateOfBirth = @dateofbirth , Gendor = @gendor , Address = @address , 
                            Phone = @phone , Email = @email ,NationalityCountryID = @countryid , ImagePath = @imgpath WHERE PersonID = @id";

            SqlCommand cmd = new SqlCommand(Query, connection);

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@national", national);
            cmd.Parameters.AddWithValue("@firstname", firstname);
            cmd.Parameters.AddWithValue("@secondname", secondname);
            cmd.Parameters.AddWithValue("@thirdname", thirdname);
            cmd.Parameters.AddWithValue("@lastname", lastname);
            cmd.Parameters.AddWithValue("@dateofbirth", dateofbirth);
            cmd.Parameters.AddWithValue("@gendor", gendor);
            cmd.Parameters.AddWithValue("@address", address);
            cmd.Parameters.AddWithValue("@phone", phone);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@countryID", countryid);
            cmd.Parameters.AddWithValue("@imgpath", imgpath);

            try
            {
                connection.Open();

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
                connection.Close();
            }

            return result;

        }

        public static bool Exists(int id)
        {
            bool result = false;

            SqlConnection con = new SqlConnection(clsConnection.ConnectionString);
            string Query = @"SELECT * FROM People WHERE PersonID = @Id";
            SqlCommand cmd = new SqlCommand(Query, con);

            cmd.Parameters.AddWithValue("@Id", id);

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

        public static bool Exists(string NationalNo)
        {
            bool result = false;

            SqlConnection con = new SqlConnection(clsConnection.ConnectionString);
            string Query = @"SELECT * FROM People WHERE NationalNo = @Notional";
            SqlCommand cmd = new SqlCommand(Query, con);

            cmd.Parameters.AddWithValue("@Notional", NationalNo);

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

        public static DataTable GetAllPersons()
        {
            DataTable Table = new DataTable();

            SqlConnection Connection = new SqlConnection(clsConnection.ConnectionString);
            string Query = @"SELECT People.PersonID, People.NationalNo,
              People.FirstName, People.SecondName, People.ThirdName, People.LastName,
			  People.DateOfBirth, People.Gendor,  
				  CASE
                  WHEN People.Gendor = 0 THEN 'Male'

                  ELSE 'Female'

                  END as GendorCaption ,
			  People.Address, People.Phone, People.Email, 
              People.NationalityCountryID, Countries.CountryName, People.ImagePath
              FROM            People INNER JOIN
                         Countries ON People.NationalityCountryID = Countries.CountryID
                ORDER BY People.FirstName";

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

        public static bool FindPersoneByNational(ref int Id, ref string NationalNum, ref string Firstname, ref string SecondName, ref string ThirdName,
            ref string LastName, ref DateTime DateOfBirth, ref byte Gendor, ref string Address, ref string Phone,
           ref string Email, ref int CountryID, ref string ImgPath)
        {

            bool result = false;

            SqlConnection con = new SqlConnection(clsConnection.ConnectionString);
            string Query = @"SELECT * FROM People WHERE NationalNo = @NationalNum";
            SqlCommand cmd = new SqlCommand(Query, con);

            cmd.Parameters.AddWithValue("@NationalNum", NationalNum);

            try
            {
                con.Open();

                SqlDataReader Reader = cmd.ExecuteReader();

                if (Reader.Read())
                {
                    result = true;

                    Id = (int)Reader["PersonID"];
                    NationalNum = (string)Reader["NationalNo"];
                    Firstname = (string)Reader["FirstName"];

                    if (Reader["SecondName"] != DBNull.Value)
                        SecondName = (string)Reader["SecondName"];
                    else
                        SecondName = "";

                    if (Reader["ThirdName"] != DBNull.Value)
                        ThirdName = (string)Reader["ThirdName"];
                    else
                        ThirdName = "";

                    LastName = (string)Reader["LastName"];
                    DateOfBirth = (DateTime)Reader["DateOfBirth"];
                    Gendor = (byte)Reader["Gendor"];
                    Address = (string)Reader["Address"];
                    Phone = (string)Reader["Phone"];

                    if (Reader["Email"] != DBNull.Value)
                        Email = (string)Reader["Email"];
                    else
                        Email = "";

                    CountryID = (int)Reader["NationalityCountryID"];

                    if (Reader["ImagePath"] != DBNull.Value)
                        ImgPath = (string)Reader["ImagePath"];
                    else
                        ImgPath = "";
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

    }
}
