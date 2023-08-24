using KinoPlus.Models;
using System.Text;

namespace KinoPlus.WinUI.Extensions
{
    public static class ErrorDetailsExtensions
    {
        public static string ToErrorString(this ErrorDetails errorDetails)
        {
            if (errorDetails == null || errorDetails.Errors == null)
                return "Nepoznata greška.";

            StringBuilder stringBuilder = new StringBuilder();

            foreach (var error in errorDetails.Errors)
            {
                List<string> errorMessages = error.Value;

                foreach (string errorMessage in errorMessages)
                {
                    stringBuilder.AppendLine(errorMessage);
                }
                stringBuilder.AppendLine();
            }

            return stringBuilder.ToString();
        }
    }
}