using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Encoder.Controls
{
    class Config
    {
        private string filename = "Config.xml";
        //
        private void createfile()
        {
            Controls.API api = new Controls.API();
            XElement xmlNode =
                    new XElement("Config",
                        new XElement("Theme",
                            new XElement("Accent")
                        ),

                        new XElement("Video",
                            //new XElement("Mode", ""),
                            //new XElement("Bit", ""),
                            new XElement("ABR"),
                            new XElement("CRF"),
                            new XElement("Bitrate"),
                            new XElement("Quality"),
                            new XElement("Bit8"), // 8Bit > Bit8 [ XML Can't start with number ]
                            new XElement("Bit10"),
                            new XElement("Framerate"),
                            new XElement("Preset"),
                            new XElement("Resize")
                        ),

                        new XElement("Audio",
                            //new XElement("Mode", ""),
                            new XElement("Bitrate"),
                            new XElement("SR")
                       ),
                        new XElement("MeGUI")
                    );
            xmlNode.Save(filename);
        }

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
                    //xmlconf.Element("Video").Element("Framerate").ReplaceNodes(api.SR);
                    //xmlconf.Element("Video").Element("Framerate").ReplaceNodes(api.SR);
                    xmlconf.Element("Video").Element("ABR").ReplaceNodes(api.ABR);
                    xmlconf.Element("Video").Element("CRF").ReplaceNodes(api.CRF);
                    xmlconf.Element("Video").Element("Bitrate").ReplaceNodes(api.Bitrate_Video);
                    xmlconf.Element("Video").Element("Quality").ReplaceNodes(api.Quality_Video);
                    xmlconf.Element("Video").Element("Framerate").ReplaceNodes(api.FPS);
                    xmlconf.Element("Video").Element("Preset").ReplaceNodes(api.Preset);
                    xmlconf.Element("Video").Element("Resize").ReplaceNodes(api.Resize);
                    xmlconf.Element("Audio").Element("Bitrate").ReplaceNodes(api.Bitrate_Audio);
                    xmlconf.Element("Audio").Element("SR").ReplaceNodes(api.SR);
                    xmlconf.Element("MeGUI").ReplaceNodes(api.MeGUI);

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
                //createfile();
                SaveFile();
                // not found -> create new file
                //Controls.Theme currenttheme = new Controls.Theme();
                //
                /*
                XElement xmlNode =
                    new XElement("Config",
                        new XElement("Theme",
                            new XElement("Accent", api.Theme)
                        ),

                        new XElement("Video",
                            //new XElement("Mode", ""),
                            //new XElement("Bit", ""),
                            new XElement("ABR", api.ABR),
                            new XElement("CRF", api.CRF),
                            new XElement("Framerate", api.FPS),
                            new XElement("Preset", api.Preset),
                            new XElement("Resize", api.Resize)
                        ),

                        new XElement("Audio",
                            //new XElement("Mode", ""),
                            new XElement("Bitrate", api.Bitrate_Audio),
                            new XElement("SR", api.SR)
                       )
                    );


                xmlNode.Save(filename);
                */

            }
        }

        //private static XElement _xml = XElement.Load(filename);
        /*
        XElement loadXML()
        {
            if (System.IO.File.Exists(filename))
            {
                try
                {
                    return XElement.Load(filename);
                }
                catch
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
        */
        private XElement _xml;
        public XElement xml
        {
            get
            {
                if (_xml == null)
                {
                    _xml = LoadFile();
                    return _xml;
                }
                else
                {
                    return _xml;
                }
            }
            set
            {
                _xml = value;
            }
        }
        
        private XElement LoadFile()
        {
            if (System.IO.File.Exists(filename))
            {
                //found
                XElement xmlconf = XElement.Load(filename);
                try
                {
                    return xmlconf;
                    //aa = xmlconf;
                    //Controls.Encode enc = new Controls.Encode();
                    //enc.FPS_Selected = xmlconf.Element("Theme").Element("Accent")
                    //Controls.Theme theme = new Controls.Theme();
                    //theme.Accents_Selected = xmlconf.Element("Theme").Element("Accent").Value;
                }
                catch
                {
                    System.Windows.MessageBox.Show("XML parse error", "XML can't read", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Asterisk);
                    return null;
                }
            }
            else
            {
                //not found
                //SaveFile();
                //XElement xmlconf = XElement.Load(filename);
                //return xmlconf;
                createfile();
                XElement xmlconf = XElement.Load(filename);
                return xmlconf;
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
                        System.Windows.MessageBox.Show("Theme->Accent not found", "XML parse error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Asterisk);
                        return "Blue";
                    }
                }
                else
                {
                    // not found
                    //System.Windows.MessageBox.Show("Theme->Accent not found", "XML parse error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Asterisk);
                    return "Blue";
                }
            }
        }
        
        /*
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
        */
        
    }
}
