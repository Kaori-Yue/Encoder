using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Encoder.Controls
{
    public class Encode //: INotifyPropertyChanged
    {
        // FPS To combobox
        private List<string> _FPS = new List<string>()
        {
            "23.976",
            "30.000"
        };
        public List<string> FPS
        {
            get { return _FPS; }
        }

        // FPS value
        private string _FPS_Selected;
        public string FPS_Selected
        {
            get
            {
                return _FPS_Selected;
            }
            set
            {
                _FPS_Selected = value;
                Config f = new Config();
                f.SaveFile();
                /*
                API.FPS_Selected = value;
                Config f = new Config();
                f.SaveFile();
                */
            }
        }

        private static string _SR;
        public string SR
        {
            get
            {
                return _SR;
            }
            set
            {
                _SR = value;
                Config f = new Config();
                f.SaveFile();
            }
        }

        // Preset
        private List<string> _Preset = new List<string>()
        {
            "Medium",
            "Slow",
            "Slower",
            "Veryslow",
            "Placbo"
        };

        public List<string> Preset
        {
            get { return _Preset; }
        }

        private static string _Preset_Selected;
        public string Preset_Selected
        {
            get { return _Preset_Selected; }
            set { _Preset_Selected = value; }
        }

        // Size
        private List<string> _Resize = new List<string>()
        {
            "1280x720",
            "1920x1080"
        };
        public List<string> Resize
        {
            get { return _Resize; }
        }

        private static string _Resize_Selected;
        public string Resize_Selected
        {
            get { return _Resize_Selected; }
            set { _Resize_Selected = value; }
        }
        /*
        // Constructor Method
        public FrameRate()
        {
            //Console.WriteLine(FPS_Selected);
        }
        */
    }
}
