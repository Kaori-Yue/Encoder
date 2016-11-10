using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Encoder.Controls
{
    public class Theme
    {

        private List<string> _Accents = new List<string>()
        {
            //
        };


        public Theme()
        {
            
        }


        public List<string> Accents
        {
            get
            {
                List<MahApps.Metro.Accent> style = MahApps.Metro.ThemeManager.Accents.ToList();
                for (int i = 0; i < style.Count - 1; i++)
                {
                    _Accents.Add(style[i].Name);
                }
                //
                _Accents.Sort();
                return _Accents;
            }
            /*
            set
            {

            }
            */
        }

        private string _Accents_Selected;
        public string Accents_Selected
        {
            get
            {
                if (_Accents_Selected == null)
                {
                    Controls.Config conf = new Controls.Config();
                    string accent = conf.Accent;
                    if (accent == null)
                    {
                        MahApps.Metro.ThemeManager.ChangeAppStyle(System.Windows.Application.Current, MahApps.Metro.ThemeManager.GetAccent(accent), MahApps.Metro.ThemeManager.GetAppTheme("BaseLight"));
                        return accent;
                    }
                    else
                    {
                        MahApps.Metro.ThemeManager.ChangeAppStyle(System.Windows.Application.Current, MahApps.Metro.ThemeManager.GetAccent("Blue"), MahApps.Metro.ThemeManager.GetAppTheme("BaseLight"));
                        return "Blue";
                    }
                }
                else
                {
                    return _Accents_Selected;
                }
            }
            //get { return _Accents_Selected; }
            /*
            get
            {
                /*
                Console.WriteLine("T");
                Controls.Config conf = new Controls.Config();
                //
                string accent = conf.Accent;
                if (accent != null)
                {
                    MahApps.Metro.ThemeManager.ChangeAppStyle(System.Windows.Application.Current, MahApps.Metro.ThemeManager.GetAccent(accent), MahApps.Metro.ThemeManager.GetAppTheme("BaseLight"));
                    return accent;
                }
                else
                {
                    return "";
                }
                
            }
        */
            set
            {
                _Accents_Selected = value;
                MahApps.Metro.ThemeManager.ChangeAppStyle(System.Windows.Application.Current, MahApps.Metro.ThemeManager.GetAccent(value), MahApps.Metro.ThemeManager.GetAppTheme("BaseLight"));
            }
        }

        /*
        public string getCurrentTheme()
        {
            Tuple<MahApps.Metro.AppTheme, MahApps.Metro.Accent> current = MahApps.Metro.ThemeManager.DetectAppStyle(System.Windows.Application.Current);
            return current.Item2.Name.ToString();
        }
        */
        public string getCurrentTheme
        {
            get { Tuple<MahApps.Metro.AppTheme, MahApps.Metro.Accent> current = MahApps.Metro.ThemeManager.DetectAppStyle(System.Windows.Application.Current); return current.Item2.Name.ToString(); }
        }
        
    }
}
