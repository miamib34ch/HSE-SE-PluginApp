using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PluginApp
{
    public interface IPlugin
    {
        string Name { get; }
        string Author { get; }
        void PluginMethod(Bitmap app);
    }

    public class VersionAttribute : Attribute
    {
        public int Major { get; private set; }
        public int Minor { get; private set; }
        public VersionAttribute(int major, int minor)
        {
            Major = major;
            Minor = minor;
        }
    }

}
