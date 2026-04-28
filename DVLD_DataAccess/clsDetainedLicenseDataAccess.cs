using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccess
{
    public class clsDetainedLicenseDataAccess
    {
        public static bool GetDetainedLicenseByID(
            int DetainID,
            ref int LicenseID,
            ref DateTime DetainDate,
            ref float FineFees,
            ref int CreatedByUserID,
            ref bool IsReleased,
            ref DateTime ReleaseDate,
            ref int ReleaseByUserID,
            ref int ReleaseApplicationID)
        {

            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM DetainedLicenses
                             WHERE DetainID = @DetainID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DetainID", DetainID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    LicenseID = (int)reader["LicenseID"];
                    DetainDate = (DateTime)reader["DetainDate"];
                    FineFees = Convert.ToSingle(reader["FineFees"]);
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    IsReleased = (bool)reader["IsReleased"];

                    ReleaseDate = reader["ReleaseDate"] == DBNull.Value
                        ? DateTime.MaxValue
                        : (DateTime)reader["ReleaseDate"];

                    ReleaseByUserID = reader["ReleasedByUserID"] == DBNull.Value
                        ? -1
                        : (int)reader["ReleasedByUserID"];

                    ReleaseApplicationID = reader["ReleaseApplicationID"] == DBNull.Value
                        ? -1
                        : (int)reader["ReleaseApplicationID"];
                }
                else
                    isFound = false;

                reader.Close();
            }
            catch (Exception)
            {
                isFound = false;
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return isFound;
        }

        public static bool GetDetainedLicenseInfoByLicenseID(
            int LicenseID,
            ref int DetainID,
            ref DateTime DetainDate,
            ref float FineFees,
            ref int CreatedByUserID,
            ref bool IsReleased,
            ref DateTime ReleaseDate,
            ref int ReleaseByUserID,
            ref int ReleaseApplicationID)
        {

            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT Top 1 * FROM DetainedLicenses
                             WHERE LicenseID = @LicenseID
                             Order By DetainID Desc;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    DetainID = (int)reader["DetainID"];
                    DetainDate = (DateTime)reader["DetainDate"];
                    FineFees = Convert.ToSingle(reader["FineFees"]);
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    IsReleased = (bool)reader["IsReleased"];

                    ReleaseDate = reader["ReleaseDate"] == DBNull.Value
                        ? DateTime.MaxValue
                        : (DateTime)reader["ReleaseDate"];

                    ReleaseByUserID = reader["ReleasedByUserID"] == DBNull.Value
                        ? -1
                        : (int)reader["ReleasedByUserID"];

                    ReleaseApplicationID = reader["ReleaseApplicationID"] == DBNull.Value
                        ? -1
                        : (int)reader["ReleaseApplicationID"];
                }
                else
                    isFound = false;

                reader.Close();
            }
            catch (Exception)
            {
                isFound = false;
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return isFound;
        }

        public static int AddNewDetainedLicense(
            int LicenseID,
            DateTime DetainDate,
            float FineFees,
            int CreatedByUserID)
        {

            int DetainID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO DetainedLicenses
                            (LicenseID,DetainDate,FineFees,CreatedByUserID,IsReleased)
                             VALUES
                            (@LicenseID,@DetainDate,@FineFees,@CreatedByUserID,0);

                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            command.Parameters.AddWithValue("@DetainDate", DetainDate);
            command.Parameters.AddWithValue("@FineFees", FineFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    DetainID = insertedID;
                }
            }
            catch (Exception)
            {
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return DetainID;
        }

        public static bool UpdateDetainedLicense(
           int DetainID,
           int LicenseID,
           DateTime DetainDate,
           float FineFees,
           int CreatedByUserID)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE DetainedLicenses
                             SET LicenseID = @LicenseID,
                                 DetainDate = @DetainDate,
                                 FineFees = @FineFees,
                                 CreatedByUserID = @CreatedByUserID
                             WHERE DetainID = @DetainID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DetainID", DetainID);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            command.Parameters.AddWithValue("@DetainDate", DetainDate);
            command.Parameters.AddWithValue("@FineFees", FineFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                // Console.WriteLine("Error: " + ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
            return rowsAffected > 0;
        }

        public static bool ReleaseDetainedLicense(
            int DetainID,
            int ReleaseByUserID,
            int ReleaseApplicationID)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE DetainedLicenses SET
                            IsReleased = 1,
                            ReleaseDate = @ReleaseDate,
                            ReleaseByUserID = @ReleaseByUserID,
                            ReleaseApplicationID = @ReleaseApplicationID
                            WHERE DetainID = @DetainID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DetainID", DetainID);
            command.Parameters.AddWithValue("@ReleaseDate", DateTime.Now);
            command.Parameters.AddWithValue("@ReleaseByUserID", ReleaseByUserID);
            command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                // Console.WriteLine("Error: " + ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
            return (rowsAffected > 0);
        }

        public static DataTable GetAllDetainedLicenses()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM vwDetainedLicenses Order By IsReleased, DetainID;";
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                    dt.Load(reader);

                reader.Close();
            }
            catch (Exception)
            {
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return dt;
        }

        public static bool IsLicenseDetained(int LicenseID)
        {
            bool IsDetained = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT 1 
                             FROM DetainedLicenses 
                             WHERE LicenseID = @LicenseID 
                             AND IsReleased = 0;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null)
                    IsDetained = true;

            }
            catch (Exception)
            {
                IsDetained = false;
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return IsDetained;
        }
    }
}