using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Encoder.Controls
{
    class Startup
    {
        public void Main()
        {
            //
            //CurrentTheme();
            
            Controls.Config config = new Controls.Config();
            Controls.Theme theme = new Controls.Theme();
            //theme.Accents_Selected = config.getXML("Theme", "Accent");
        }

        void CheckFile()
        {
            if (File.Exists(""))
            {
                //
            }
        }

        //

        void CurrentTheme()
        {
            Tuple<MahApps.Metro.AppTheme, MahApps.Metro.Accent> current = MahApps.Metro.ThemeManager.DetectAppStyle(System.Windows.Application.Current);
            //System.Windows.MessageBox.Show(current.Item2.Name.ToString());
            /*
            List<MahApps.Metro.Accent> style = MahApps.Metro.ThemeManager.Accents.ToList();
            Console.WriteLine();

            Console.WriteLine("Log:");
            Console.WriteLine(style[1].Name);
            //System.Windows.MessageBox.Show(style[1].Name);
            //Console.WriteLine(MahApps.Metro.ThemeManager.GetAccent(style[1]).Name.ToString());
            //style.ForEach(Console.WriteLine);
            */

    }
    }
}
