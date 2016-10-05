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
            List<MahApps.Metro.Accent> style = MahApps.Metro.ThemeManager.Accents.ToList();
            for (int i = 0; i < style.Count - 1; i++)
            {
                _Accents.Add(style[i].Name);
            }
            _Accents.Sort();

        }


        public List<string> Accents
        {
            get
            {
                return _Accents;
            }
            /*
            set
            {

            }
            */
        }



    }
}
