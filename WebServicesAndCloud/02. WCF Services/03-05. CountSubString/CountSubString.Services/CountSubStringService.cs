namespace CountSubString.Services
{
    public class CountSubStringService : ICountSubStringService
    {
        public int CountSubString(string text, string subString)
        {
            if (text == null || subString == null)
            {
                return 0;
            }

            var offset = subString.Length;
            var currentIndex = 0;
            var count = 0;

            while (currentIndex >= 0)
            {
                currentIndex = text.IndexOf(subString, currentIndex);
                if (currentIndex >= 0)
                {
                    count++;
                    currentIndex += offset;
                }
            }

            return count;
        }
    }
}