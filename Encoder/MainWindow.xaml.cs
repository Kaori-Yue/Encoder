using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using System.Diagnostics;

using Encoder.Controls;
using System.Text.RegularExpressions;
using System.Threading;

namespace Encoder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            // Startup
            Controls.Startup startup = new Controls.Startup();
            startup.Main();


            //this.DataContext = new Controls.FrameRate();
            //Controls.FPS fps = new Controls.FPS();
            //DataContext = fps.test();
            //Controls.FrameRate class2 = new Controls.FrameRate(this);
        }

        // toggle Flyout
        private void toggleFlyoutVideo(object sender, RoutedEventArgs e)
        {
            //FrameRate fps = new FrameRate();
            //var obj = sender as Button;
            /*
            Button obj = sender as Button;
            Console.WriteLine(obj.Name);
            */
            //Console.WriteLine(FrameRate.FPS_Selected);
            if (Setting_Video_Flyout.IsOpen == true)
            { Setting_Video_Flyout.IsOpen = false; }
            else
            { Setting_Video_Flyout.IsOpen = true; }
        }
        //
        private void toggleFlyoutAudio(object sender, RoutedEventArgs e)
        {
            if (Setting_Audio_Flyout.IsOpen == true)
            { Setting_Audio_Flyout.IsOpen = false; }
            else
            { Setting_Audio_Flyout.IsOpen = true; }
        }
        //
        private void toggleFlyoutPath(object sender, RoutedEventArgs e)
        {
            if (Setting_Path_Flyout.IsOpen == true)
            { Setting_Path_Flyout.IsOpen = false; }
            else
            { Setting_Path_Flyout.IsOpen = true; }
        }

        //
        // Dialog Open/Save file
        private void _Openfile_Video(object sender, MouseButtonEventArgs e)
        {
            var obj = sender as TextBox;
            if (obj != null)
            {
                Controls.Dialog file = new Controls.Dialog();
                var filename = file.Openfile("Video file (*.mp4;*.mkv)|*.mp4;*.mkv|All file (*.*)|*.*");
                //check select file
                if (filename != null)
                {
                    obj.Text = filename;
                }
            }
        }

        // Subtitle
        private void _Openfile_Ass(object sender, MouseButtonEventArgs e)
        {
            var obj = sender as TextBox;
            if (obj != null)
            {
                Controls.Dialog file = new Controls.Dialog();
                var filename = file.Openfile("Subtitle file (*.ass)|*.ass|All file (*.*)|*.*");
                //check select file
                if (filename != null)
                {
                    obj.Text = filename;
                }
            }
        }

        // Save file
        private void _Savefile_Video(object sender, MouseButtonEventArgs e)
        {
            var obj = sender as TextBox;
            if (obj != null)
            {
                Controls.Dialog file = new Controls.Dialog();
                var filename = file.Savefile("MP4 file (*.mp4)|*.mp4|All file (*.*)|*.*");
                //check
                if (filename != null)
                {
                    obj.Text = filename;
                }
            }
        }

        private void Video_ABR_Checked(object sender, RoutedEventArgs e)
        {
            quality_cb.Visibility = Visibility.Hidden;
            quality_label.Visibility = Visibility.Hidden;
            //
            bitrate_cb.Visibility = Visibility.Visible;
            bitrate_label.Visibility = Visibility.Visible;
        }

        private void Video_CRF_Checked(object sender, RoutedEventArgs e)
        {
            bitrate_cb.Visibility = Visibility.Hidden;
            bitrate_label.Visibility = Visibility.Hidden;
            //
            quality_cb.Visibility = Visibility.Visible;
            quality_label.Visibility = Visibility.Visible;
        }

        private void MeGUI_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var obj = sender as TextBox;
            if (obj != null)
            {
                Controls.Dialog file = new Controls.Dialog();
                var filename = file.Openfile("MeGUI.exe|MeGUI.exe|All file (*.*)|*.*");
                //check
                if (filename != null)
                {
                    obj.Text = filename;
                }
            }
        }

        private void Encode_bt_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (!System.IO.Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "Temporary")) System.IO.Directory.CreateDirectory("Temporary");
            /*
            API api = new API();
            if (api.Input_Video == null)
            {
                MessageBox.Show("null");
            }
            if (api.Input_Video == "")
            {
                MessageBox.Show("empty");
            }
            return;
            */
            Command com = new Command();
            //Console.WriteLine(com.pass1());
            /*
            using (System.IO.StreamWriter script = new System.IO.StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "Temporary/Encode.avs"))
            {
                script.WriteLine(com.AVS());
            }
            //
            */
            
            ProcessStartInfo b = new ProcessStartInfo();

            //b.FileName = @"E:\MeGUI\tools\x264\avs4x264mod.exe";
            //b.Arguments = "\"" + AppDomain.CurrentDomain.BaseDirectory + "Temporary\\Encode.avs\" -o test.mp4";
            //b.FileName = @"E:\MeGUI\tools\BePipe\BePipe.exe";
            //b.Arguments = "--script \"Import(^C:\\Users\\CrossKnight\\Documents\\GitHub\\Encoder\\Encoder\\bin\\Debug\\Temporary\\Encode.avs^)\" | \"E:\\MeGUI\\tools\\eac3to\\neroAacEnc.exe\" -cbr 192000 -lc -if - -of \"test.m4a\"";
            b.FileName = @"E:\MeGUI\tools\BePipe\bat.bat";
            b.UseShellExecute = false;
            b.RedirectStandardOutput = true;
            b.RedirectStandardError = true;
            b.CreateNoWindow = true;

            Console.WriteLine(b.Arguments.ToString());

            using (Process exe = Process.Start(b))
            {
                exe.ErrorDataReceived += (aa, ee) =>
                {
                    if (ee.Data != null) { Console.WriteLine(ee.Data); }
                };
                exe.OutputDataReceived += (aa, ee) =>
                {
                    if (ee.Data != null) { Console.WriteLine(ee.Data); }
                };
                exe.EnableRaisingEvents = true;
                exe.BeginOutputReadLine();
                exe.BeginErrorReadLine();
                exe.WaitForExit();
            }
            //
        }

        //
        //////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////
        private void Encode_bt_Click(object sender, RoutedEventArgs e)
        {
            Controls.API api = new Controls.API();
            Controls.Command cmd = new Controls.Command();
            Controls.Path path = new Controls.Path();
            if (string.IsNullOrEmpty(api.Input_Video)) return;
            if (string.IsNullOrEmpty(api.Output_Video)) return;
            if (!System.IO.Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "Temporary")) System.IO.Directory.CreateDirectory("Temporary");

            
            using (System.IO.StreamWriter script = new System.IO.StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "Temporary\\Encode.avs"))
            {
                script.WriteLine(cmd.AVS());
            }

            using (System.IO.StreamWriter script = new System.IO.StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "Temporary\\Audio.bat"))
            {
                script.WriteLine(cmd.Batch());
            }
            //
            Thread com = new Thread(delegate ()
            {
                command("Temporary\\Audio.bat", "", "audio");
                command(path.megui + path.avs264, cmd.pass1(), "pass1");
                command(path.megui + path.avs264, cmd.pass2(), "pass2");
                //Console.WriteLine(cmd.mp4box());
                command(path.megui + path.mp4box, cmd.mp4box(), "mp4box");
                complete();
            });
            com.Start();
        }

        private void command(string filename, string argv, string stage)
        {
            ProcessStartInfo build = new ProcessStartInfo();
            build.FileName = filename;
            build.Arguments = argv;

            build.UseShellExecute = false;
            build.RedirectStandardOutput = true;
            build.RedirectStandardError = true;
            build.CreateNoWindow = true;

            //Dispatcher.Invoke(new Action(() => progress.Maximum = 1000));
            //
            switch (stage)
            {
                case "pass1":
                    {
                        using (Process exe = Process.Start(build))
                        {
                            Dispatcher.Invoke(new Action(() => progress.Maximum = 1000));
                            exe.ErrorDataReceived += (sender, e) =>
                            {
                                if (e.Data != null) { command_report_pass1(e.Data.ToString()); }
                            };
                            exe.OutputDataReceived += (sender, e) =>
                            {
                                if (e.Data != null) { command_report_pass1(e.Data.ToString()); }
                            };
                            exe.EnableRaisingEvents = true;
                            exe.BeginOutputReadLine();
                            exe.BeginErrorReadLine();
                            exe.WaitForExit();
                        }
                        break;
                    }
                case "pass2":
                    {
                        using (Process exe = Process.Start(build))
                        {
                            Dispatcher.Invoke(new Action(() => progress.Maximum = 1000));
                            exe.ErrorDataReceived += (sender, e) =>
                            {
                                if (e.Data != null) { command_report_pass2(e.Data.ToString()); }
                            };
                            exe.OutputDataReceived += (sender, e) =>
                            {
                                if (e.Data != null) { command_report_pass2(e.Data.ToString()); }
                            };
                            exe.EnableRaisingEvents = true;
                            exe.BeginOutputReadLine();
                            exe.BeginErrorReadLine();
                            exe.WaitForExit();
                        }
                        break;
                    }
                case "audio":
                    {
                        using (Process exe = Process.Start(build))
                        {
                            Dispatcher.Invoke(new Action(() => progress.Maximum = 100));
                            exe.ErrorDataReceived += (sender, e) =>
                            {
                                if (e.Data != null) { command_report_audio(e.Data.ToString()); }
                            };
                            exe.OutputDataReceived += (sender, e) =>
                            {
                                if (e.Data != null) { command_report_audio(e.Data.ToString()); }
                            };
                            exe.EnableRaisingEvents = true;
                            exe.BeginOutputReadLine();
                            exe.BeginErrorReadLine();
                            exe.WaitForExit();
                        }
                        break;
                    }
                case "mp4box":
                    {
                        using (Process exe = Process.Start(build))
                        {
                            Dispatcher.Invoke(new Action(() => progress.Maximum = 100));
                            exe.ErrorDataReceived += (sender, e) =>
                            {
                                if (e.Data != null) { command_report_mp4box(e.Data.ToString()); }
                            };
                            exe.OutputDataReceived += (sender, e) =>
                            {
                                if (e.Data != null) { command_report_mp4box(e.Data.ToString()); }
                            };
                            exe.EnableRaisingEvents = true;
                            exe.BeginOutputReadLine();
                            exe.BeginErrorReadLine();
                            exe.WaitForExit();
                        }
                        break;
                    }
            }

            //
            
            //
        }
        //
        private void command_report_pass1(string data)
        {
            Match match = Regex.Match(data, @"\[(.*)%\] (.*)/(.*) frames, (.*) fps, .*/s, eta (\d+:\d+:\d+)", RegexOptions.IgnoreCase);
            //string to decimal
            decimal num_int;
            decimal.TryParse(match.Groups[1].ToString(), out num_int);
            //
            Dispatcher.Invoke(new Action(() => status.Content = "Video Encode Pass: 1 | Written: " + match.Groups[2].ToString() + "/" + match.Groups[3].ToString() + " | Speed: " + match.Groups[4].ToString() + " fps | eta: " + match.Groups[5].ToString() + " | Complete: " + match.Groups[1].ToString() + "%"));
            Dispatcher.Invoke(new Action(() => progress.Value = Convert.ToInt32(num_int) * 10));
            // taskbar
            Dispatcher.Invoke(new Action(() => TaskbarItemInfo.ProgressValue = Convert.ToDouble(num_int) / 100));
        }

        private void command_report_pass2(string data)
        {
            Match match = Regex.Match(data, @"\[(.*)%\] (.*)/(.*) frames, (.*) fps, .*/s, eta (\d+:\d+:\d+)", RegexOptions.IgnoreCase);
            //string to decimal
            decimal num_int;
            decimal.TryParse(match.Groups[1].ToString(), out num_int);
            //
            Dispatcher.Invoke(new Action(() => status.Content = "Video Encode Pass: 2 | Written: " + match.Groups[2].ToString() + "/" + match.Groups[3].ToString() + " | Speed: " + match.Groups[4].ToString() + " fps | eta: " + match.Groups[5].ToString() + " | Complete: " + match.Groups[1].ToString() + "%"));
            Dispatcher.Invoke(new Action(() => progress.Value = Convert.ToInt32(num_int) * 10));
            // taskbar
            Dispatcher.Invoke(new Action(() => TaskbarItemInfo.ProgressValue = Convert.ToDouble(num_int) / 100));
        }

        private void command_report_audio(string data)
        {
            Match match = Regex.Match(data, @"(\d+)\..*", RegexOptions.IgnoreCase);
            //string to decimal
            decimal num_int;
            decimal.TryParse(match.Groups[1].ToString(), out num_int);
            //
            Dispatcher.Invoke(new Action(() => status.Content = "Audio: " + num_int + "%"));
            Dispatcher.Invoke(new Action(() => progress.Value = Convert.ToInt32(num_int)));
            // taskbar
            Dispatcher.Invoke(new Action(() => TaskbarItemInfo.ProgressValue = Convert.ToDouble(num_int) / 100));
        }

        private void command_report_mp4box(string data)
        {
            Console.WriteLine(data);
            Match match = Regex.Match(data, @"\((\d+)/100\)", RegexOptions.IgnoreCase);
            //string to decimal
            decimal num_int;
            decimal.TryParse(match.Groups[1].ToString(), out num_int);
            //
            Dispatcher.Invoke(new Action(() => status.Content = "Muxer: " + num_int + "%"));
            Dispatcher.Invoke(new Action(() => progress.Value = Convert.ToInt32(num_int)));
            // taskbar
            Dispatcher.Invoke(new Action(() => TaskbarItemInfo.ProgressValue = Convert.ToDouble(num_int) / 100));
        }

        private void complete()
        {
            Controls.API api = new Controls.API();
            System.IO.File.Delete(AppDomain.CurrentDomain.BaseDirectory + "Temporary\\" + System.IO.Path.GetFileNameWithoutExtension(api.Input_Video) + ".264");
            System.IO.File.Delete(AppDomain.CurrentDomain.BaseDirectory + "Temporary\\" + System.IO.Path.GetFileNameWithoutExtension(api.Input_Video) + ".m4a");
            System.IO.File.Delete(AppDomain.CurrentDomain.BaseDirectory + "Temporary\\" + System.IO.Path.GetFileNameWithoutExtension(api.Input_Video) + ".stats");
            System.IO.File.Delete(AppDomain.CurrentDomain.BaseDirectory + "Temporary\\" +  System.IO.Path.GetFileNameWithoutExtension(api.Input_Video) + ".stats.mbtree");
            //
            System.IO.File.Delete(AppDomain.CurrentDomain.BaseDirectory + "Temporary\\" + System.IO.Path.GetFileNameWithoutExtension(api.Input_Video) + ".stats.mbtree.temp");
            System.IO.File.Delete(AppDomain.CurrentDomain.BaseDirectory + "Temporary\\" + System.IO.Path.GetFileNameWithoutExtension(api.Input_Video) + ".stats.temp");
            Dispatcher.Invoke(new Action(() => status.Content = "Idle"));
        }

    }
}
