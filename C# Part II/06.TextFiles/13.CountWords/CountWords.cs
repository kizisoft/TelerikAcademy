using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _13.CountWords
{
    class CountWords
    {
        static void Main(string[] args)
        {
            string inputText = string.Empty;
            List<string> words = new List<string>();
            using (StreamReader reader = new StreamReader(@"..\..\words.txt"))
            {
                inputText = reader.ReadToEnd();
            }
            Match wordMatch = Regex.Match(inputText, @"(?<word>\w+)", RegexOptions.IgnoreCase);
            while (wordMatch.Success)
            {
                words.Add(wordMatch.Groups["word"].Value);
                wordMatch = wordMatch.NextMatch();
            }
            using (StreamReader reader = new StreamReader(@"..\..\test.txt"))
            {
                inputText = reader.ReadToEnd();
            }
            Dictionary<string, int> dic = new Dictionary<string, int>();

            for (int i = 0; i < words.Count; i++)
            {
                string word = words[i];
                int counter = 0;
                wordMatch = Regex.Match(inputText, word, RegexOptions.IgnoreCase);
                while (wordMatch.Success)
                {
                    counter++;
                    wordMatch = wordMatch.NextMatch();
                }

                words.RemoveAll(x => x == word);
                dic.Add(word, counter);
            }
            dic.OrderBy(x => x.Value);
            string outputText = "";
            foreach (var item in dic)
            {
                outputText += "The item {" + item.Key + "} is found " + item.Value + " times" + "\r\n";
            }
            try
            {
                using (StreamWriter writer = new StreamWriter(@"..\..\result.txt"))
                {
                    writer.Write(outputText);
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File was not found");
            }
            catch (IOException)
            {
                Console.WriteLine("Cannot write");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
