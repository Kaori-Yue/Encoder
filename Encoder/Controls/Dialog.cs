using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Encoder.Controls
{
    class Dialog
    {
        // Open
        public string Openfile(string filter)
        {
            Microsoft.Win32.OpenFileDialog open = new Microsoft.Win32.OpenFileDialog();
            open.Filter = filter;
            Nullable<bool> result = open.ShowDialog();
            if (result == true)
            {
                return open.FileName;
            }
            return null;
        }

        //Save
        public string Savefile(string filter)
        {
            Microsoft.Win32.SaveFileDialog save = new Microsoft.Win32.SaveFileDialog();
            save.Filter = filter;
            Nullable<bool> result = save.ShowDialog();
            if (result == true)
            {
                return save.FileName;
            }
            return null;
        }
    }
}
