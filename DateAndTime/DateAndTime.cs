using System;
using System.Device.Location;
using PluginApp;
using System.Drawing;

namespace DateAndTime
{
    [Version(1, 0)]
    public class DateAndTime : IPlugin
    {
        public string Name
        {
            get
            {
                return "Add date and time and geo";
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
            Graphics g = Graphics.FromImage(bitmap);
            g.DrawString($"{DateTime.Now} {GetLocationProperty()}", new Font("Segoe UI", (float)5,FontStyle.Bold), //текст на картинке, шрифт и его размер
            new SolidBrush(Color.Red), bitmap.Width-200, bitmap.Height-50); //месторасположения текста
            g = null; //обнуляем переменные во избежании переполнения памяти
        }

        static string GetLocationProperty()
        {
            GeoCoordinateWatcher watcher = new GeoCoordinateWatcher();

            // Do not suppress prompt, and wait 1000 milliseconds to start.
            watcher.TryStart(false, TimeSpan.FromMilliseconds(1000));

            GeoCoordinate coord = watcher.Position.Location;

            if (coord.IsUnknown != true)
            {
                return $"Lat: {coord.Latitude}, Long: {coord.Longitude}";
            }
            else
            {
                return"Unknown latitude and longitude.";
            }
        }
    }
}