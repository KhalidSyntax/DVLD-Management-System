using System;
using System.Data;
using System.Data.SqlClient;
using DVLD.Common;

namespace DVLD_DataAccess
{
    public class clsInternationalLicenseDataAccess
    {
        public static bool GetInternationalLicenseInfoByID(
            int InternationalLicenseID,
            ref int ApplicationID,
            ref int DriverID,
            ref int IssuedUsingLocalLicenseID,
            ref int CreatedByUserID,
            ref DateTime IssueDate,
            ref DateTime ExpirationDate,
            ref bool IsActive)
        {

            bool isFound = false;

            SqlConnection connection =
                new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM InternationalLicenses
                             WHERE InternationalLicenseID = @InternationalLicenseID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    ApplicationID = (int)reader["ApplicationID"];
                    DriverID = (int)reader["DriverID"];
                    IssuedUsingLocalLicenseID = (int)reader["IssuedUsingLocalLicenseID"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    IssueDate = (DateTime)reader["IssueDate"];
                    ExpirationDate = (DateTime)reader["ExpirationDate"];
                    IsActive = (bool)reader["IsActive"];
                }
                else
                    isFound = false;

                reader.Close();
            }
            catch (Exception ex)
            {
                isFound = false;
                Logger.LogError(ex.ToString());
            }
            finally
            {
                connection.Close();
            }
            return isFound;
        }

        public static int AddNewInternationalLicense(
            int ApplicationID,
            int DriverID,
            int IssuedUsingLocalLicenseID,
            int CreatedByUserID,
            DateTime IssueDate,
            DateTime ExpirationDate,
            bool IsActive)
        {

            int InternationalLicenseID = -1;

            SqlConnection connection =
                new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"
                            UPDATE InternationalLicenses
                            SET IsActive = 0
                            WHERE DriverID = @DriverID;

                            INSERT INTO InternationalLicenses
                            (ApplicationID,
                             DriverID,
                             IssuedUsingLocalLicenseID,
                             CreatedByUserID,
                             IssueDate,
                             ExpirationDate,
                             IsActive)

                            VALUES
                            (@ApplicationID,
                             @DriverID,
                             @IssuedUsingLocalLicenseID,
                             @CreatedByUserID,
                             @IssueDate,
                             @ExpirationDate,
                             @IsActive);

                            SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            command.Parameters.AddWithValue("@IsActive", IsActive);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null &&
                    int.TryParse(result.ToString(), out int insertedID))
                {
                    InternationalLicenseID = insertedID;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.ToString());
            }
            finally
            {
                connection.Close();
            }
            return InternationalLicenseID;
        }

        public static bool UpdateInternationalLicense(
            int InternationalLicenseID,
            int ApplicationID,
            int DriverID,
            int IssuedUsingLocalLicenseID,
            int CreatedByUserID,
            DateTime IssueDate,
            DateTime ExpirationDate,
            bool IsActive)
        {

            int rowsAffected = 0;

            SqlConnection connection =
                new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE InternationalLicenses SET

                            ApplicationID = @ApplicationID,
                            DriverID = @DriverID,
                            IssuedUsingLocalLicenseID = @IssuedUsingLocalLicenseID,
                            CreatedByUserID = @CreatedByUserID,
                            IssueDate = @IssueDate,
                            ExpirationDate = @ExpirationDate,
                            IsActive = @IsActive

                            WHERE InternationalLicenseID = @InternationalLicenseID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            command.Parameters.AddWithValue("@IsActive", IsActive);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.ToString());
                return false;
            }
            finally
            {
                connection.Close();
            }
            return (rowsAffected > 0);
        }

        public static bool DeleteInternationalLicense(int InternationalLicenseID)
        {

            int rowsAffected = 0;

            SqlConnection connection =
                new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"DELETE FROM InternationalLicenses
                             WHERE InternationalLicenseID = @InternationalLicenseID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                Logger.LogError(ex.ToString());
            }
            finally
            {
                connection.Close();
            }
            return (rowsAffected > 0);
        }

        public static int GetActiveInternationalLicenseByDriverID(int DriverID)
        {
            int InternationalLicenseID = -1;

            SqlConnection connection =
                new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT TOP 1 InternationalLicenseID
                             FROM InternationalLicenses
                             WHERE DriverID = @DriverID
                             AND IsActive = 1
                             AND GETDATE() BETWEEN IssueDate AND ExpirationDate
                             ORDER BY ExpirationDate DESC;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DriverID", DriverID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null &&
                    int.TryParse(result.ToString(), out int ID))
                {
                    InternationalLicenseID = ID;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.ToString());
            }
            finally
            {
                connection.Close();
            }
            return InternationalLicenseID;
        }

        public static DataTable GetAllInternationalLicenses()
        {
            DataTable dt = new DataTable();

            SqlConnection connection =
                new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT
                            InternationalLicenseID,
                            ApplicationID,
                            DriverID,
                            IssuedUsingLocalLicenseID,
                            IssueDate,
                            ExpirationDate,
                            IsActive
                            FROM InternationalLicenses
                            ORDER BY IsActive, ExpirationDate DESC";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                    dt.Load(reader);

                reader.Close();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.ToString());
            }
            finally
            {
                connection.Close();
            }
            return dt;
        }

        public static DataTable GetDriverInternationalLicenses(int DriverID)
        {
            DataTable dt = new DataTable();

            SqlConnection connection =
                new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT
                            InternationalLicenseID,
                            ApplicationID,
                            IssuedUsingLocalLicenseID,
                            IssueDate,
                            ExpirationDate,
                            IsActive
                            FROM InternationalLicenses
                            WHERE DriverID=@DriverID
                            ORDER BY ExpirationDate DESC";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DriverID", DriverID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                    dt.Load(reader);

                reader.Close();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.ToString());
            }
            finally
            {
                connection.Close();
            }
            return dt;
        }
    }
}