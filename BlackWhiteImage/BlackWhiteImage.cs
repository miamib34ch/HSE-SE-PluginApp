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

namespace BlackWhiteImage
{
    [Version(1, 0)]
    public class BlackWhiteImage : IPlugin
    {
        public string Name
        {
            get
            {
                return "Image discoloration";
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
                    // получаем (i, j) пиксель
                    UInt32 pixel = (UInt32)(bitmap.GetPixel(i, j).ToArgb());
                    // получаем компоненты цветов пикселя
                    float R = (float)((pixel & 0x00FF0000) >> 16); // красный
                    float G = (float)((pixel & 0x0000FF00) >> 8); // зеленый
                    float B = (float)(pixel & 0x000000FF); // синий
                                                           // делаем цвет черно-белым (оттенки серого) - находим среднее арифметическое
                    R = G = B = (R + G + B) / 3.0f;
                    // собираем новый пиксель по частям (по каналам)
                    UInt32 newPixel = 0xFF000000 | ((UInt32)R << 16) | ((UInt32)G << 8) | ((UInt32)B);
                    // добавляем его в Bitmap нового изображения
                    bitmap.SetPixel(i, j, Color.FromArgb((int)newPixel));
                }
        }

    }
}