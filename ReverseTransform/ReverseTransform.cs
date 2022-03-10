using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Interfaces.Streaming;
using Microsoft.Analytics.Types.Sql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using PluginApp;
using System.Drawing;

namespace ReverseTransform
{
    [Version(1, 0)]
    public class ReverseTransform : IPlugin
    {
        public string Name
        {
            get
            {
                return "Image flip";
            }
        }

        public string Author
        {
            get
            {
                return "Bogdan Polygalov";
            }
        }

        public void PluginMethod(Bitmap bitmap)
        {
            for (int i = 0; i < bitmap.Width; ++i)
                for (int j = 0; j < bitmap.Height / 2; ++j)
                {
                    Color color = bitmap.GetPixel(i, j);
                    bitmap.SetPixel(i, j, bitmap.GetPixel(i, bitmap.Height - j - 1));
                    bitmap.SetPixel(i, bitmap.Height - j - 1, color);
                }
        }

    }
}
