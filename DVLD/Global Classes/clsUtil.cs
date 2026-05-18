using DVLD.Common;
using System;
using System.IO;
using System.Windows.Forms;

namespace DVLD.Classes
{
    public class clsUtil
    {
        public static string GenerateGUID()
        {
            Guid newGuid = Guid.NewGuid();
            return newGuid.ToString();
        }

        public static bool CreateFolderIfDoesNotExist(string folderPath)
        {
            if(!Directory.Exists(folderPath))
            {
                try
                {
                    Directory.CreateDirectory(folderPath);
                }
                catch(Exception ex)
                {
                    Logger.LogError(ex.ToString());
                    return false;
                }
            }
            return true;
        }

        public static string ReplaceFileNameWithGUID(string sourceFile)
        {
            string fileName = sourceFile;
            FileInfo fileInfo = new FileInfo(fileName);
            string extension = fileInfo.Extension;
            return GenerateGUID() + extension;
        }

        public static bool CopyImageToProjectImagesFolder(ref string sourceFile)
        {
            string destinationFolder = @"C:\Users\huawei\Pictures\DVLD-People-Images\";

            if (!CreateFolderIfDoesNotExist(destinationFolder))
                return false;

            string destinationFile = destinationFolder + ReplaceFileNameWithGUID(sourceFile);

            try
            {
                File.Copy(sourceFile, destinationFile, true);
            }
            catch(IOException iox)
            {
                Logger.LogError(iox.ToString());
            }

            sourceFile = destinationFile;
            return true;
        }
    }
}
