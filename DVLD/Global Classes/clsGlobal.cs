using System;
using System.IO;
using DVLD_Business;
using System.Windows.Forms;

namespace DVLD.Classes
{
    internal static class clsGlobal
    {
        public static clsUser currentUser;

        public static bool RememberUsernameAndPassword(string userName, string password)
        {
            try
            {
                string currentDirectory = System.IO.Directory.GetCurrentDirectory();
                string filePath = currentDirectory + "\\data.txt";

                if (string.IsNullOrEmpty(userName))
                {
                    if (File.Exists(filePath))
                        File.Delete(filePath);

                    return true;
                }

                string dataToSave = userName + "#//#" + password;

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine(dataToSave);
                    return true;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }
        }

        public static bool GetStoredCredential(ref string userName, ref string password)
        {
            try
            {
                string currentDirectory = System.IO.Directory.GetCurrentDirectory();
                string filePath = currentDirectory + "\\data.txt";

                if (File.Exists(filePath))
                {
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        string line = reader.ReadLine();

                        if (line != null)
                        {
                            string[] result = line.Split(new string[] { "#//#" }, StringSplitOptions.None);

                            if (result.Length == 2 && !string.IsNullOrEmpty(result[0]))
                            {
                                userName = result[0];
                                password = result[1];
                                return true;
                            }
                        }
                    }
                }
                return false;
            }
            catch(Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }
        }
    }
}
