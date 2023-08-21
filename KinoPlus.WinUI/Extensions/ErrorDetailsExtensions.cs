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
                string fieldName = error.Key;
                List<string> errorMessages = error.Value;

                stringBuilder.AppendLine($"Polje: {fieldName}");
                foreach (string errorMessage in errorMessages)
                {
                    stringBuilder.AppendLine($"Greška: {errorMessage}");
                }
                stringBuilder.AppendLine();
            }

            return stringBuilder.ToString();
        }
    }
}