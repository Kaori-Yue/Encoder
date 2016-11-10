using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Encoder.Controls
{
    class Config
    {
        string filename = "Config.xml";
        //
        public void SaveFile()
        {
            Controls.API api = new Controls.API();
            if (System.IO.File.Exists(filename))
            {
                // found file ->
                XElement xmlconf = XElement.Load(filename);
                // LIB
                
                //
                try
                {
                    xmlconf.Element("Theme").Element("Accent").ReplaceNodes(api.Theme);
                    xmlconf.Element("Audio").Element("SR").ReplaceNodes(api.SR);
                    xmlconf.Element("Video").Element("Preset").ReplaceNodes(api.Preset);

                    // Save
                    xmlconf.Save(filename);
                }
                catch
                {
                    System.Windows.MessageBox.Show("Error XML Element", "XML parse error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Asterisk);
                    return;
                }
            }
            else
            {
                // not found -> create new file
                Controls.Theme currenttheme = new Controls.Theme();
                //

                XElement xmlNode =
                    new XElement("Config",
                        new XElement("Theme",
                            new XElement("Accent", currenttheme.getCurrentTheme)
                        ),

                        new XElement("Video",
                            //new XElement("Mode", ""),
                            //new XElement("Bit", ""),
                            //new XElement("CRF", ""),
                            new XElement("Framerate", null),
                            new XElement("Preset", api.Preset),
                            new XElement("Resize", "")
                        ),
                        
                        new XElement ("Audio",
                            //new XElement("Mode", ""),
                            new XElement("Bitrate", null),
                            new XElement("SR", api.SR)
                       )
                    );


                xmlNode.Save(filename);
            }
        }


        public void LoadFile()
        {
            if (System.IO.File.Exists(filename))
            {
                //found
                XElement xmlconf = XElement.Load(filename);
                try
                {
                    //Controls.Encode enc = new Controls.Encode();
                    //enc.FPS_Selected = xmlconf.Element("Theme").Element("Accent")
                    Controls.Theme theme = new Controls.Theme();
                    //theme.Accents_Selected = xmlconf.Element("Theme").Element("Accent").Value;
                }
                catch
                {
                    System.Windows.MessageBox.Show("XML parse error", "XML can't read", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Asterisk);
                    return;
                }
            }
            else
            {
                //not found
            }
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////
        
        public string Accent
        {
            get
            {         
                if (System.IO.File.Exists(filename))
                {
                    //found
                    XElement xmlconf = XElement.Load(filename);
                    try
                    {
                        return xmlconf.Element("Theme").Element("Accent").Value;
                    }
                    catch
                    {
                        return "Green";
                    }
                }
                else
                {
                    // not found
                    return "Amber";
                }
            }
        }
        
        
        public string getXML(string element1, string element2)
        {
            if (System.IO.File.Exists(filename))
            {
                //found
                XElement xmlconf = XElement.Load(filename);
                try
                {
                    return xmlconf.Element(element1).Element(element2).Value;
                }
                catch
                {
                    System.Windows.MessageBox.Show("XML parse error", "XML can't read", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Asterisk);
                    return "";
                }
            }
            else
            {
                //not found
                return "";
            }
        }
        
    }
}
