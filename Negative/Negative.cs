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

namespace Negative
{
    [Version(1, 0)]
    public class Negative : IPlugin
    {
        public string Name
        {
            get
            {
                return "Make image negative";
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
            for (int i = 0; i < bitmap.Width; i++)
                for (int j = 0; j < bitmap.Height; j++)
                {
                    bitmap.SetPixel(i,j, Color.FromArgb(255 - bitmap.GetPixel(i, j).A, 255 - bitmap.GetPixel(i, j).R, 255 - bitmap.GetPixel(i, j).G, 255 - bitmap.GetPixel(i, j).B));
                }
        }

    }
}