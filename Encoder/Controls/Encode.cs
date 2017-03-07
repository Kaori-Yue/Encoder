using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Encoder.Controls
{
    public class Encode //: INotifyPropertyChanged
    {
        //Controls.Config conf = new Controls.Config();

        private string xml(string node1, string node2)
        {
            Controls.Config config = new Controls.Config();
            string node = config.xml.Element(node1).Element(node2).Value;
            if (!string.IsNullOrEmpty(node))
            {
                return node;
            }
            else
            {
                return null;
            }
        }

        private string xml(string node1)
        {
            Controls.Config config = new Controls.Config();
            string node = config.xml.Element(node1).Value;
            if (!string.IsNullOrEmpty(node))
            {
                return node;
            }
            else
            {
                return null;
            }
        }
        
        
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
        private static string _FPS_Selected;
        public string FPS_Selected
        {
            get
            {
                //string fps = conf.xml.Element("Video").Element("Framerate").Value;
                //_FPS_Selected = _FPS_Selected ?? (string.IsNullOrEmpty(fps) ? "23.976" : fps);
                //return _FPS_Selected;
                _FPS_Selected = _FPS_Selected ?? xml("Video", "Framerate") ?? "23.976"; return _FPS_Selected;
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
            get { _SR = _SR ?? xml("Audio", "SR") ?? "44100"; return _SR; }
            set { _SR = value; }
        }

        // bitrate auidio
        private static string _Bitrate_Audio;
        public string Bitrate_Audio
        {
            //get { _Bitrate_Audio = _Bitrate_Audio ?? (string.IsNullOrEmpty(conf.xml.Element("Audio").Element("Bitrate").Value)) ? "192" : ""; return _Bitrate_Audio; }
            get { _Bitrate_Audio = _Bitrate_Audio ?? xml("Audio", "Bitrate") ?? "192"; return _Bitrate_Audio; }
            set { _Bitrate_Audio = value; }
        }

        // bitrate [abr] video
        private static string _Bitrate_Video;
        public string Bitrate_Video
        {
            get { _Bitrate_Video = _Bitrate_Video ?? xml("Video", "Bitrate") ?? "1500"; return _Bitrate_Video; }
            set { _Bitrate_Video = value; }
        }

        // quality [crf] video
        private static string _Quality_Video;
        public string Quality_Video
        {
            get { _Quality_Video = _Quality_Video ?? xml("Video", "Quality") ?? "20.0"; return _Quality_Video; }
            set { _Quality_Video = value; }
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
            get { _Preset_Selected = _Preset_Selected ?? xml("Video", "Preset") ?? "Medium"; return _Preset_Selected; }
            set { _Preset_Selected = value; }
        }

        // Size
        private List<string> _Resize = new List<string>()
        {
            "Default",
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
            get { _Resize_Selected = _Resize_Selected ?? xml("Video", "Resize") ?? "Default"; return _Resize_Selected; }
            set { _Resize_Selected = value; }
        }


        //
        private string _ABR;

        public bool ABR
        {
            get
            {
                if (_ABR == null)
                {
                    try
                    {
                        _ABR = xml("Video", "ABR");
                        return bool.Parse(_ABR);
                    }
                    catch
                    {
                        return (CRF == false) ? true : false;
                    }
                }
                else
                {
                    return bool.Parse(_ABR); ;
                }
            }
            //get { _ABR = "true"; return bool.Parse(_ABR); }
            set { _ABR = value.ToString(); }
        }


        private string _CRF;

        public bool CRF
        {
            get
            {
                if (_CRF == null)
                {
                    try
                    {
                        _CRF = xml("Video", "CRF");
                        return bool.Parse(_CRF);
                    }
                    catch
                    {
                        return false;
                    }
                }
                else
                {
                    return bool.Parse(_CRF); ;
                }
            }
            set { _CRF = value.ToString(); }
        }

        // Bit
        private string _Bit8;

        public bool Bit8
        {
            get
            {
                if (_Bit8 == null)
                {
                    try
                    {
                        _Bit8 = xml("Video", "Bit8");
                        return bool.Parse(_Bit8);
                    }
                    catch
                    {
                        return (Bit10 == false) ? true : false;
                    }
                }
                else
                {
                    return bool.Parse(_Bit8); ;
                }
            }
            //get { _ABR = "true"; return bool.Parse(_ABR); }
            set { _Bit8 = value.ToString(); }
        }


        private string _Bit10;

        public bool Bit10
        {
            get
            {
                if (_Bit10 == null)
                {
                    try
                    {
                        _Bit10 = xml("Video", "Bit10");
                        return bool.Parse(_Bit10);
                    }
                    catch
                    {
                        return false;
                    }
                }
                else
                {
                    return bool.Parse(_Bit10); ;
                }
            }
            set { _Bit10 = value.ToString(); }
        }

        private static string _MeGUI;
        public string MeGUI
        {
            get { _MeGUI = _MeGUI ?? xml("MeGUI"); return _MeGUI; }
            set { _MeGUI = value; }
        }
        //
        /*
         * 
        // Constructor Method
        public FrameRate()
        {
            //Console.WriteLine(FPS_Selected);
        }
        */
        private static string _input_video;
        public string Input_Video
        {
            get { return _input_video; }
            set { _input_video = value; }
        }

        private static string _input_subtitle1;
        public string Input_Subtitle1
        {
            get { return _input_subtitle1; }
            set { _input_subtitle1 = value; }
        }

        private static string _input_subtitle2;
        public string Input_Subtitle2
        {
            get { return _input_subtitle2; }
            set { _input_subtitle2 = value; }
        }

        private static string _input_subtitle3;
        public string Input_Subtitle3
        {
            get { return _input_subtitle3; }
            set { _input_subtitle3 = value; }
        }

        private static string _output_video;
        public string Output_Video
        {
            get { return _output_video; }
            set { _output_video = value; }
        }
    }
}
