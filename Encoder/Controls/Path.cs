using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Encoder.Controls
{
    class Path
    {
        Controls.Encode me = new Controls.Encode();
        public string megui { get { return System.IO.Path.GetDirectoryName(me.MeGUI); } }

        const string _avs264 = @"\tools\x264\avs4x264mod.exe";
        const string _bepipe = @"\tools\BePipe\Bepipe.exe";
        const string _vsfilter = @"\tools\avisynth_plugin\VSFilter.dll";
        const string _aac = @"\tools\eac3to\neroAacEnc.exe";
        const string _mp4box = @"\tools\mp4box\mp4box.exe";

        //
        public string avs264 { get { return _avs264; } }
        public string bepipe { get { return _bepipe; } }
        public string vsfilter { get { return _vsfilter; } }
        public string aac { get { return _aac; } }
        public string mp4box { get { return _mp4box; } }
    }
}
