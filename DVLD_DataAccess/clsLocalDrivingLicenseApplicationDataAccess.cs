using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccess
{
    public class clsLocalDrivingLicenseApplicationDataAccess
    {
        public static bool GetLocalDrivingLicenseApplicationInfoByID(
        int LocalDrivingLicenseApplicationID,
        ref int ApplicationID,
        ref int LicenseClassID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * From LocalDrivingLicenseApplications WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    ApplicationID = (int)reader["ApplicationID"];
                    LicenseClassID = (int)reader["LicenseClassID"];
                }

                reader.Close();
            }
            catch (Exception)
            {
                // Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static bool GetLocalDrivingLicenseApplicationInfoByApplicationID(
        int ApplicationID,
        ref int LocalDrivingLicenseApplicationID,
        ref int LicenseClassID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * From LocalDrivingLicenseApplications WHERE ApplicationID = @ApplicationID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    LocalDrivingLicenseApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];
                    LicenseClassID = (int)reader["LicenseClassID"];
                }

                reader.Close();
            }
            catch (Exception)
            {
                // Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static int AddNewLocalDrivingLicenseApplication(int ApplicationID, int LicenseClassID)
        {
            int LocalDrivingLicenseApplicationID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO LocalDrivingLicenseApplications
                    (ApplicationID, LicenseClassID)
                     VALUES
                    (@ApplicationID, @LicenseClassID);
                     SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    LocalDrivingLicenseApplicationID = insertedID;
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

            return LocalDrivingLicenseApplicationID;
        }

        public static bool UpdateLocalDrivingLicenseApplication(
        int LocalDrivingLicenseApplicationID,
        int ApplicationID,
        int LicenseClassID)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE LocalDrivingLicenseApplications SET
                    ApplicationID = @ApplicationID,
                    LicenseClassID = @LicenseClassID
                    WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

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

        public static bool DeleteLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "DELETE FROM LocalDrivingLicenseApplications WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }

        public static DataTable GetAllLocalDrivingLicenseApplications()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "Select * From vw_LocalDrivingLicenseApplications ORDER BY ApplicationDate DESC;";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }

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

        public static bool DoesPassTestType(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            bool Result = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"
                    SELECT TOP 1 TestResult
                    FROM LocalDrivingLicenseApplications 
                    INNER JOIN TestAppointments 
                        ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID
                    INNER JOIN Tests 
                        ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                    WHERE LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                      AND TestAppointments.TestTypeID = @TestTypeID
                    ORDER BY TestAppointments.TestAppointmentID DESC;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && bool.TryParse(result.ToString(), out bool returnedResult))
                {
                    Result = returnedResult;
                }
            }
            catch (Exception)
            {
                // Console.WriteLine("Error: " + ex.Message);
                Result = false;
            }
            finally
            {
                connection.Close();
            }

            return Result;
        }

        public static bool DoesAttendTestType(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"
                    SELECT TOP 1 1 AS Found
                    FROM LocalDrivingLicenseApplications 
                    INNER JOIN TestAppointments 
                        ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID
                    INNER JOIN Tests 
                        ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                    WHERE LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                      AND TestAppointments.TestTypeID = @TestTypeID
                    ORDER BY TestAppointments.TestAppointmentID DESC;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null)
                {
                    isFound = true;
                }
            }
            catch (Exception)
            {
                // Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static byte TotalTrialsPerTest(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            byte TotalTrialsPerTest = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"
                    SELECT COUNT(TestID) AS TotalTrialsPerTest
                    FROM LocalDrivingLicenseApplications 
                    INNER JOIN TestAppointments 
                        ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID
                    INNER JOIN Tests 
                        ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                    WHERE LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                      AND TestAppointments.TestTypeID = @TestTypeID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && byte.TryParse(result.ToString(), out byte Trials))
                {
                    TotalTrialsPerTest = Trials;
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

            return TotalTrialsPerTest;
        }

        public static bool IsThereAnActiveScheduledTest(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            bool Result = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"
                            SELECT 1
                            FROM TestAppointments TA
                            WHERE TA.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                            AND TA.TestTypeID = @TestTypeID
                            AND TA.IsLocked = 0;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();

                object value = command.ExecuteScalar();

                if (value != null)
                    Result = true;
            }
            catch (Exception)
            {
                Result = false;
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return Result;
        }

        public static DateTime GetLastTestAppointmentDate(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            DateTime result = DateTime.Now;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"
                    SELECT Top 1 TestAppointmentDate
                    FROM TestAppointments 
                    WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                    AND TestTypeID = @TestTypeID
                    Order By TestAppointmentID Desc;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();

                object value = command.ExecuteScalar();

                if (value != null && DateTime.TryParse(value.ToString(), out DateTime dt))
                {
                    result = dt;
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

            return result;
        }
    }
}
