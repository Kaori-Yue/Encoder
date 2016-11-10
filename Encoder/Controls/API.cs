using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Encoder.Controls
{
    class API
    {
        public API()
        {

        }

        public void MainWindow()
        {

        }
        //
        //private string _FPS_Selected;
        private static string _FPS_Selected;
        public static string FPS_Selected { get { return _FPS_Selected; } set {_FPS_Selected = value; } }
        //
        /*
        public static string Preset()
        {
            Controls.Preset preset = new Controls.Preset();
            return preset.Presets.ToString();
        }
        */
        public string Theme { get { Controls.Theme theme = new Controls.Theme(); return theme.getCurrentTheme; } }
        public string Preset { get { Controls.Encode current = new Controls.Encode(); return current.Preset_Selected; } }
        public string FPS { get { Controls.Encode fps = new Controls.Encode(); return fps.FPS_Selected; } }
        public string SR { get { Controls.Encode sr = new Controls.Encode(); return sr.SR; } }
        //public string SR { get }

    }
}
