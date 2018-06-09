using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileOrganizer
{
    public class ProgressStep
    {
        public string CurrentProgressStep { get; set; }

        public event EventHandler ProgressChanged;

        public void OnProgressChanged(EventArgs e)
        {
            ProgressChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
