using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Encoder.Controls
{
    public class FrameRate //: INotifyPropertyChanged
    {
        private List<string> _FPS = new List<string>()
        {
            "23.976",
            "30.000"
        };

        public List<string> FPS
        {
            get { return _FPS; }
            set { FPS = value; }
        }

        public string FPS_Selected { get; set; }

        // Constructor Method
        public FrameRate()
        {
            //Console.WriteLine(FPS_Selected);
        }
    }
}
