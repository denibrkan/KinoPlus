namespace KinoPlus.WinUI.Utils
{
    public static class LetterEnding
    {
        public static string GetLetterEnding(int number, string word)
        {
            if (number == 12 || number == 13 || number == 14)
                return word;

            var lastNumber = number % 10;

            switch (lastNumber)
            {
                case 2:
                case 3:
                case 4:
                    return word[..^1] + 'e'; ;
                default:
                    return word;
            };
        }
    }
}