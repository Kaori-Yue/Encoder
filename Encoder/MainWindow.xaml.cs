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
        }

        // toggle Flyout
        private void toggleFlyoutVideo(object sender, RoutedEventArgs e)
        {
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
        //
    }
}
