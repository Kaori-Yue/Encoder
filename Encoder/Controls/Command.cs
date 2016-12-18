using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Encoder.Controls
{
    class Command
    {
        Controls.API api = new Controls.API();
        Controls.Path path = new Controls.Path();


        public string pass1()
        {
            StringBuilder str = new StringBuilder();
            //str.Append("\"" + api.MeGUI + path.avs264 + "\"");
            str.Append(" --level 4.1");
            str.Append(" --preset " + api.Preset.ToLower());
            str.Append(" --tune animation");
            str.Append(" --pass 1");
            str.Append(" --bitrate " + api.Bitrate_Video);
            str.Append(" --stats \"" + AppDomain.CurrentDomain.BaseDirectory + "Temporary\\" + System.IO.Path.GetFileNameWithoutExtension(api.Input_Video) + ".stat\"");
            str.Append(" --keyint 240");
            str.Append(" --vbv-bufsize 78125");
            str.Append(" --vbv-maxrate 62500");
            str.Append(" --stitchable");
            str.Append(" --sar 1:1");
            str.Append(" --output NUL");
            str.Append(" \"" + AppDomain.CurrentDomain.BaseDirectory + "Temporary\\Encode.avs\"");
            return str.ToString();
        }

        public string pass2()
        {
            StringBuilder str = new StringBuilder();
            //str.Append("\"" + api.MeGUI + path.avs264 + "\"");
            str.Append(" --level 4.1");
            str.Append(" --preset " + api.Preset.ToLower());
            str.Append(" --tune animation");
            str.Append(" --pass 2");
            str.Append(" --bitrate " + api.Bitrate_Video);
            str.Append(" --stats \"" + AppDomain.CurrentDomain.BaseDirectory + "Temporary\\" + System.IO.Path.GetFileNameWithoutExtension(api.Input_Video) + ".stat\"");
            str.Append(" --keyint 240");
            str.Append(" --vbv-bufsize 78125");
            str.Append(" --vbv-maxrate 62500");
            str.Append(" --stitchable");
            str.Append(" --sar 1:1");
            str.Append(" --output \"" + AppDomain.CurrentDomain.BaseDirectory + "Temporary\\" + System.IO.Path.GetFileNameWithoutExtension(api.Input_Video) + ".264\"");
            str.Append(" \"" + AppDomain.CurrentDomain.BaseDirectory + "Temporary\\Encode.avs\"");
            return str.ToString();
        }

        public string Batch()
        {
            StringBuilder str = new StringBuilder();
            str.Append("\"" + path.megui + path.bepipe + "\"");
            str.Append(" --script \"Import(^" + AppDomain.CurrentDomain.BaseDirectory + "Temporary\\Encode.avs^)\" | \"" + path.megui + path.aac + "\"");
            str.Append(" -cbr " + api.Bitrate_Audio + "000");
            str.Append(" -lc");
            str.Append(" -igonrelength");
            str.Append(" -if - -of");
            str.Append(" \"" + AppDomain.CurrentDomain.BaseDirectory + "Temporary\\" + System.IO.Path.GetFileNameWithoutExtension(api.Input_Video) + ".m4a\"");
            return str.ToString();
        }

        public string AVS()
        {
            StringBuilder str = new StringBuilder();
            str.Append("DirectShowSource(\"" + api.Input_Video + "\"");
            str.Append(", fps=" + api.FPS);
            str.Append(", audio=true");
            str.Append(", convertfps=true)");

            //str.Append(".AssumeFPS(x,x)");
            str.Append(".ssrc(" + api.SR + ")");
            if (!(string.IsNullOrEmpty(api.Input_Sub1) && string.IsNullOrEmpty(api.Input_Sub2) && string.IsNullOrEmpty(api.Input_Sub3)))
            {
                str.Append("\n");
                str.Append("LoadPlugin(\"" + path.megui + path.vsfilter + "\")");
                if (!(string.IsNullOrEmpty(api.Input_Sub1))) str.Append("\nTextSub(\"" + api.Input_Sub1 + "\", 1)");
                if (!(string.IsNullOrEmpty(api.Input_Sub2))) str.Append("\nTextSub(\"" + api.Input_Sub2 + "\", 1)");
                if (!(string.IsNullOrEmpty(api.Input_Sub3))) str.Append("\nTextSub(\"" + api.Input_Sub3 + "\", 1)");
            }
            
            // ass pls
            return str.ToString();
        }

        public string mp4box()
        {
            StringBuilder str = new StringBuilder();
            str.Append("-add");
            str.Append(" \"" + AppDomain.CurrentDomain.BaseDirectory + "Temporary\\" + System.IO.Path.GetFileNameWithoutExtension(api.Input_Video) + ".264");
            str.Append(":fps=" + api.FPS);
            str.Append(":name=Season-Subs\"");

            str.Append(" -add");
            str.Append(" \"" + AppDomain.CurrentDomain.BaseDirectory + "Temporary\\" + System.IO.Path.GetFileNameWithoutExtension(api.Input_Video) + ".m4a");
            str.Append(":name=Season-Subs\"");

            str.Append(" -tmp");
            str.Append(" \"" + AppDomain.CurrentDomain.BaseDirectory + "Temporary\"");

            str.Append(" -new");
            str.Append(" \"" + api.Output_Video + "\"");
            return str.ToString();
        }
    }
}
