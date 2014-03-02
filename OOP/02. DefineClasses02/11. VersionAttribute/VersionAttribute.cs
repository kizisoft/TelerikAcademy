// 11. Create a [Version] attribute that can be applied to structures,
//     classes, interfaces, enumerations and methods and holds a version
//     in the format major.minor (e.g. 2.11). Apply the version
//     attribute to a sample class and display its version at runtime.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.VersionAttribute
{
    // Define on which targets to apply the VersionAttribute
    [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Enum | AttributeTargets.Method, AllowMultiple = false)]
    class VersionAttribute : Attribute
    {
        // Store the current Version
        public string Version { get; private set; }

        // Constructor to create VersionAttribute
        public VersionAttribute(string version)
        {
            this.Version = version;
        }
    }
}