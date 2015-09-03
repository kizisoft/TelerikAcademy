// Write a program that parses an URL address given in the format:
// [protocol]://[server]/[resource]
// and extracts from it the [protocol], [server] and [resource] elements. For example from the URL http://www.devbg.org/forum/index.php the following information should be extracted:
//        [protocol] = "http"
//        [server] = "www.devbg.org"
//        [resource] = "/forum/index.php"

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.ParseURL
{
    class ParseURL
    {
        static void Main()
        {
            // http://www.devbg.org/forum/index.php 
            Console.Write("Input an URL address: ");
            string url = Console.ReadLine();

            int protocolIndex = url.IndexOf(':');
            string protocol = url.Substring(0, protocolIndex);
            int serverIndex = url.IndexOf('/', protocolIndex);

            // Jump over the first two '/' to find the end of the server which is the third '/'
            int serverIndexEnd = url.IndexOf('/', serverIndex + 2);
            string server = url.Substring(serverIndex + 2, serverIndexEnd - serverIndex - 2);

            // From the end of the server till the end of the url is the resource substring
            string resource = url.Substring(serverIndexEnd + 1);
            Console.WriteLine("[protocol]= \"{0}\"", protocol);
            Console.WriteLine("[server]= \"{0}\"", server);
            Console.WriteLine("[resource]= \"{0}\"", resource);
        }
    }
}