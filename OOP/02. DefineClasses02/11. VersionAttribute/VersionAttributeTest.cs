using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.VersionAttribute
{
    // Create a VersionAttribute
    [Version("1.01")]
    public class VersionAttributeTest
    {
        static void Main(string[] args)
        {
            // Use a reflection to gets all attribute of type VersionAttribute
            Type type = typeof(VersionAttributeTest);
            object[] allAttributes = type.GetCustomAttributes(false);

            // Print Version
            foreach (VersionAttribute attr in allAttributes)
            {
                Console.WriteLine("Version {0}", attr.Version);
            }
        }
    }
}