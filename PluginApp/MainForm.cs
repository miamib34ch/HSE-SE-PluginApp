using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PluginApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            FindPlugins();
            CreatePluginsMenu();
        }

        Dictionary<string, IPlugin> plugins = new Dictionary<string, IPlugin>();

        void FindPlugins()
        {
            // папка с плагинами
            string folder = System.AppDomain.CurrentDomain.BaseDirectory;

            // dll-файлы в этой папке
            string[] files = Directory.GetFiles(folder, "*.dll");

            foreach (string file in files)
                try
                {
                    Assembly assembly = Assembly.LoadFile(file);

                    foreach (Type type in assembly.GetTypes())
                    {
                        Type iface = type.GetInterface("PluginApp.IPlugin");

                        if (iface != null)
                        {
                            IPlugin plugin = (IPlugin)Activator.CreateInstance(type);
                            plugins.Add(plugin.Name, plugin);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка загрузки плагина\n" + ex.Message);
                }
        }

        private void OnPluginClick(object sender, EventArgs args)
        {
            dynamic plugin = plugins[((ToolStripMenuItem)sender).Text];
            Type type = plugin.GetType();
            MethodInfo info = type.GetMethod("PluginMethod");
            if (info != null)
                plugin.PluginMethod((Bitmap)pictureBox.Image);
            pictureBox.Refresh();
        }

        void CreatePluginsMenu()
        {
            foreach (IPlugin p in plugins.Values)
            {
                var menuItem = new ToolStripMenuItem(p.Name);
                menuItem.Click += OnPluginClick;

                filtersToolStripMenuItem.DropDownItems.Add(menuItem);
            }
        }
    }
}
