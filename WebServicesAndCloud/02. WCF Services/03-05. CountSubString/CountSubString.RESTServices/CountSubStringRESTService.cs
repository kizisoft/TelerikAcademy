namespace CountSubString.RESTServices
{
    public class CountSubStringRESTService : ICountSubStringRESTService
    {
        public int CountSubStringREST(string text, string subString)
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