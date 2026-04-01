using System;

namespace DVLD.Classes
{
    public class clsFormat
    {
        public static string DateToShort(DateTime dt)
        {
            return dt.ToString("dd/MMM/yyyy");
        }
    }
}
