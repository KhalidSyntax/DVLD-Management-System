using System.Text.RegularExpressions;

namespace DVLD.Classes
{
    public class clsValidation
    {
        public static bool ValidateEmail(string emailAddress)
        {
            var pattern = @"^[a-zA-Z0-9.!#$%&'*+-/=?^_`{|}~]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$";
            var regex = new Regex(pattern);
            return regex.IsMatch(emailAddress);
        }

        public static bool ValidateInteger(string number)
        {
            var pattern = @"^[0-9]*$";
            var regex = new Regex(pattern);
            return regex.IsMatch(number);
        }

        public static bool ValidateFloat(string number)
        {
            var pattern = @"^[0-9]*(?:\.[0-9]*)?$";
            var regex = new Regex(pattern);
            return regex.IsMatch(number);
        }

        public static bool IsNumber(string number)
        {
            return ValidateInteger(number) || ValidateFloat(number);
        }
    }
}
