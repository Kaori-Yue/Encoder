using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Encoder.Controls
{
    class API
    {
        /*
        public API()
        {

        }
        */
        public void MainWindow()
        {

        }
        //
        ////private string _FPS_Selected;
        //private static string _FPS_Selected;
        //public static string FPS_Selected { get { return _FPS_Selected; } set {_FPS_Selected = value; } }
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
        public string Bitrate_Audio { get { Controls.Encode ba = new Controls.Encode(); return ba.Bitrate_Audio; } }
        public string Resize { get { Controls.Encode rs = new Controls.Encode(); return rs.Resize_Selected; } }
        public string Bitrate_Video { get { Controls.Encode bv = new Controls.Encode(); return bv.Bitrate_Video; } }
        public string Quality_Video { get { Controls.Encode qv = new Controls.Encode(); return qv.Quality_Video; } }

        public bool ABR { get { Controls.Encode abr = new Controls.Encode(); return abr.ABR; } }
        public bool CRF { get { Controls.Encode crf = new Controls.Encode(); return crf.CRF; } }
        public bool Bit8 { get { Controls.Encode bit8 = new Controls.Encode(); return bit8.Bit8; } }
        public bool Bit10 { get { Controls.Encode bit10 = new Controls.Encode(); return bit10.Bit10; } }

        public string MeGUI { get { Controls.Encode me = new Controls.Encode(); return me.MeGUI; } }

        public string Input_Video { get { Controls.Encode iv = new Controls.Encode(); return iv.Input_Video; } }
        public string Input_Sub1 { get { Controls.Encode is1 = new Controls.Encode(); return is1.Input_Subtitle1; } }
        public string Input_Sub2 { get { Controls.Encode is2 = new Controls.Encode(); return is2.Input_Subtitle2; } }
        public string Input_Sub3 { get { Controls.Encode is3 = new Controls.Encode(); return is3.Input_Subtitle3; } }
        public string Output_Video { get { Controls.Encode ov = new Controls.Encode(); return ov.Output_Video; } }
        //public string SR { get }

    }
}
