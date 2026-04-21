using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccess
{
    public class clsTestDataAccess
    {
        public static bool GetTestByID(
            int TestID,
            ref int TestAppointmentID,
            ref bool TestResult,
            ref string Notes,
            ref int CreatedByUserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Tests
                             WHERE TestID = @TestID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestID", TestID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    TestAppointmentID = (int)reader["TestAppointmentID"];
                    TestResult = (bool)reader["TestResult"];

                    if (reader["Notes"] != DBNull.Value)
                        Notes = (string)reader["Notes"];
                    else
                        Notes = "";

                    CreatedByUserID = (int)reader["CreatedByUserID"];
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

        public static bool GetLastTestByPersonAndTestTypeAndLicenseClass(
            int PersonID,
            int LicenseClassID,
            int TestTypeID,
            ref int TestID,
            ref int TestAppointmentID,
            ref bool TestResult,
            ref string Notes,
            ref int CreatedByUserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"
                SELECT TOP 1 
                    Tests.TestID,
                    Tests.TestAppointmentID,
                    Tests.TestResult,
                    Tests.Notes,
                    Tests.CreatedByUserID,
                    Applications.ApplicantPersonID
                FROM LocalDrivingLicenseApplications
                INNER JOIN TestAppointments 
                    ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID
                INNER JOIN Tests 
                    ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID
                INNER JOIN Applications 
                    ON LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID
                WHERE Applications.ApplicantPersonID = @PersonID
                    AND LocalDrivingLicenseApplications.LicenseClassID = @LicenseClassID
                    AND TestAppointments.TestTypeID = @TestTypeID
                ORDER BY Tests.TestAppointmentID DESC";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    TestID = (int)reader["TestID"];
                    TestAppointmentID = (int)reader["TestAppointmentID"];
                    TestResult = (bool)reader["TestResult"];

                    if (reader["Notes"] == DBNull.Value)
                        Notes = "";
                    else
                        Notes = (string)reader["Notes"];

                    CreatedByUserID = (int)reader["CreatedByUserID"];
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

        public static int AddNewTest(
            int TestAppointmentID,
            bool TestResult,
            string Notes,
            int CreatedByUserID)
        {
            int TestID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO Tests
                            (TestAppointmentID, TestResult, Notes, CreatedByUserID)
                            VALUES
                            (@TestAppointmentID, @TestResult, @Notes, @CreatedByUserID);

                            UPDATE TestAppointments
                            SET IsLocked = 1
                            WHERE TestAppointmentID = @TestAppointmentID;

                            SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            command.Parameters.AddWithValue("@TestResult", TestResult);

            if (Notes == "" || Notes == null)
                command.Parameters.AddWithValue("@Notes", DBNull.Value);
            else
                command.Parameters.AddWithValue("@Notes", Notes);

            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    TestID = insertedID;
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
            return TestID;
        }

        public static bool UpdateTest(
            int TestID,
            int TestAppointmentID,
            bool TestResult,
            string Notes,
            int CreatedByUserID)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE Tests SET
                            TestAppointmentID = @TestAppointmentID,
                            TestResult = @TestResult,
                            Notes = @Notes,
                            CreatedByUserID = @CreatedByUserID
                            WHERE TestID = @TestID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestID", TestID);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            command.Parameters.AddWithValue("@TestResult", TestResult);

            if (Notes == "" || Notes == null)
                command.Parameters.AddWithValue("@Notes", DBNull.Value);
            else
                command.Parameters.AddWithValue("@Notes", Notes);

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
            return (rowsAffected > 0);
        }

        public static bool DeleteTest(int TestID)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"DELETE FROM Tests
                             WHERE TestID = @TestID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestID", TestID);

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

        public static byte GetPassedTestCount(int LocalDrivingLicenseApplicationID)
        {
            byte PassedTests = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"
                    SELECT COUNT(TestID)
                    FROM Tests

                    INNER JOIN TestAppointments
                    ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID

                    WHERE TestAppointments.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                    AND Tests.TestResult = 1;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && byte.TryParse(result.ToString(), out byte Trials))
                {
                    PassedTests = Trials;
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

            return PassedTests;
        }

        public static DataTable GetAllTests()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Tests";

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
    }
}