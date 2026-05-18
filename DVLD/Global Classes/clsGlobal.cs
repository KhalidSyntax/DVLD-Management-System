using DVLD_Business;
using Microsoft.Win32; 
using System;
using System.Windows.Forms;
using DVLD.Common;

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
                Logger.LogError(ex.ToString());
                return false;
            }
        }

        public static bool RememberUsernameAndPassword(string userName, string password)
        {
            try
            {
                string valueUserName = userName;
                string valuePasswordData = password;

                Registry.SetValue(keyPath, "UserName", valueUserName, RegistryValueKind.String);
                Registry.SetValue(keyPath, "Password", valuePasswordData, RegistryValueKind.String);

                return true;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.ToString());
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
                    password = storedPassword;
                    return true;
                }
                return false;

            }
            catch (Exception ex)
            {
                Logger.LogError(ex.ToString());
                return false;
            }
        }
    }
}