// Write a program that replaces in a HTML document given as string all
// the tags <a href="…">…</a> with corresponding tags [URL=…]…/URL]. Sample
// HTML fragment:
//
// <p>Please visit <a href="http://academy.telerik. com">our site</a> to choose a training course.
// Also visit <a href="www.devbg.org">our forum</a> to discuss the courses.</p>
// <p>Please visit [URL=http://academy.telerik. com]our site[/URL] to choose a training course.
// Also visit [URL=www.devbg.org]our forum[/URL] to discuss the courses.</p>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15.ReplaceTagsInHTML
{
    class ReplaceTagsInHTML
    {
        static void Main()
        {
            Console.Write("Input a text: ");
            string text = Console.ReadLine();

            int hrefStart = 0;

            while (hrefStart < text.Length)
            {
                hrefStart = text.IndexOf(@"<a href=""", hrefStart);

                // If there are no more <a href=... exit the loop
                if (hrefStart == -1)
                {
                    break;
                }

                int hrefEnd = text.IndexOf(@""">", hrefStart);
                text = text.Remove(hrefEnd, 1);
                text = text.Insert(hrefEnd, "]");
                hrefStart = hrefStart + 1;
            }

            text = text.Replace(@"<a href=""", "[URL=");
            text = text.Replace("</a>", "[/URL]");
            Console.WriteLine(text);
        }
    }
}