using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

class DownloadFile
{
    static void Main(string[] args)
    {
        WebClient wc = null;
        string errorMessage = null;
        string url = Console.ReadLine();

        try
        {
            wc = new WebClient();
            // Download a file from i-net to parent directory of parent directory.
            wc.DownloadFile(url, @"..\..\download.txt");
        }
        catch (WebException we)
        {
            errorMessage = we.Message;
        }
        catch (NotSupportedException nse)
        {
            errorMessage = nse.Message;
        }
        catch (Exception e)
        {
            errorMessage = e.Message;
        }
        finally
        {
            if (errorMessage != null) Console.WriteLine(errorMessage);
        }
    }
}