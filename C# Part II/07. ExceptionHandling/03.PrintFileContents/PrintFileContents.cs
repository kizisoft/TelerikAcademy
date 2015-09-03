using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

class PrintFileContents
{
    static void Main(string[] args)
    {
        string errorMessage = null;
        string filePath = Console.ReadLine();

        try
        {
            Console.WriteLine(FileToString(filePath));
        }
        catch (ArgumentNullException ane)
        {
            errorMessage = ane.Message;
        }
        catch (ArgumentException ae)
        {
            errorMessage = ae.Message;
        }
        catch (PathTooLongException ptle)
        {
            errorMessage = ptle.Message;
        }
        catch (DirectoryNotFoundException dnfe)
        {
            errorMessage = dnfe.Message;
        }
        catch (FileNotFoundException fnfe)
        {
            errorMessage = fnfe.Message;
        }
        catch (IOException ioe)
        {
            errorMessage = ioe.Message;
        }
        catch (UnauthorizedAccessException uae)
        {
            errorMessage = uae.Message;
        }
        catch (NotSupportedException nse)
        {
            errorMessage = nse.Message;
        }
        catch (SecurityException se)
        {
            errorMessage = se.Message;
        }
        catch (Exception e)
        {
            errorMessage = e.Message;
        }
        finally
        {
            if (errorMessage != null)
            {
                Console.WriteLine(errorMessage);
            }
        }
    }

    private static string FileToString(string filePath)
    {
        string toString = File.ReadAllText(filePath, Encoding.UTF8);
        return toString;
    }

}