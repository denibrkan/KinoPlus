using System.Text;
using System.Text.Json;

namespace KinoPlus.WinUI.Extensions
{
    public static class StringExtensions
    {
        public static bool IsJson(this string value)
        {
            // Try to parse the input string as a JSON element
            // Create a Utf8JsonReader from the input string
            var utf8Bytes = Encoding.UTF8.GetBytes(value);
            var jsonReader = new Utf8JsonReader(utf8Bytes, isFinalBlock: true, state: default);

            try
            {
                while (jsonReader.Read())
                {
                    // Continue reading to validate JSON structure
                }

                return true;
            }
            catch (JsonException)
            {
                return false;
            }
        }
    }
}
