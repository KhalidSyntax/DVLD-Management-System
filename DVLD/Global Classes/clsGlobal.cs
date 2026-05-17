using System;
using DVLD_Business;
using System.Windows.Forms;
using Microsoft.Win32; 

namespace DVLD.Classes
{
    internal static class clsGlobal
    {
        public static clsUser currentUser;
        private static string keyPath = @"HKEY_CURRENT_USER\Software\DVLD\Login";

        public static bool ClearStoredCredential()
        {
            try
            {
                Registry.SetValue(keyPath, "UserName", "");
                Registry.SetValue(keyPath, "Password", "");

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }
        }

        private static string EncryptPassword(string password)
        {
            return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(password));
        }

        private static string DecryptPassword(string encryptedPassword)
        {
            return System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(encryptedPassword));
        }

        public static bool RememberUsernameAndPassword(string userName, string password)
        {
            try
            {
                string valueUserName = userName;
                string valuePasswordData = EncryptPassword(password);

                Registry.SetValue(keyPath, "UserName", valueUserName, RegistryValueKind.String);
                Registry.SetValue(keyPath, "Password", valuePasswordData, RegistryValueKind.String);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }
        }

        public static bool GetStoredCredential(ref string userName, ref string password)
        {
            try
            {
                string storedUserName = Registry.GetValue(keyPath, "UserName", null) as string;
                string storedPassword = Registry.GetValue(keyPath, "Password", null) as string;

                if (storedUserName != null && storedPassword != null)
                {
                    userName = storedUserName;
                    password = DecryptPassword(storedPassword);
                    return true;
                }
                return false;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }
        }
    }
}