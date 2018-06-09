using FileOrganizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagerGuiApp
{
    public class OrganizerModel : NotifyPropertyChanged
    {
        private Organizer organizer;

        public OrganizerModel()
        {
            this.organizer = new Organizer();
            this.organizer.Progress.ProgressChanged += Progress_ProgressChanged;
        }

        public string Progress { get; set; }

        private void Progress_ProgressChanged(object sender, EventArgs e)
        {
            this.Progress = this.organizer.Progress.CurrentProgressStep;
            this.RaisePropertyChangedEvent(nameof(this.Progress));
        }

        public void Organize(string source, string destination)
        {
            this.organizer.OrganizeByDateTaken(source, destination);
        }
    }
}
