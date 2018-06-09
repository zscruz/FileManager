using System;
using System.Collections.ObjectModel;
using System.Windows.Forms;

namespace FileManagerGuiApp
{
    public class MainWindowViewModel : NotifyPropertyChanged
    {
        private FolderBrowserDialog browser;
        private string sourcePath;
        private string destinationPath;
        private OrganizerModel model;

        public MainWindowViewModel(OrganizerModel model)
        {
            this.sourcePath = string.Empty;
            this.destinationPath = string.Empty;
            this.Log = new ObservableCollection<string>();
            this.model = model;
            this.model.PropertyChanged += Model_PropertyChanged;
        }

        public string SourcePath
        {
            get
            {
                return this.sourcePath;
            }
            set
            {
                if (this.sourcePath != value)
                {
                    this.sourcePath = value;
                    this.RaisePropertyChangedEvent(nameof(this.SourcePath));
                }
            }
        }

        public string DestinationPath
        {
            get
            {
                return this.destinationPath;
            }
            set
            {
                if (this.destinationPath != value)
                {
                    this.destinationPath = value;
                    this.RaisePropertyChangedEvent(nameof(this.DestinationPath));
                }
            }
        }

        public string Progress
        {
            get
            {
                return this.model.Progress;
            }
        }

        public ObservableCollection<string> Log { get; }

        private void Model_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            this.Log.Add(this.Progress);
            this.RaisePropertyChangedEvent(nameof(this.Progress));
        }

        public void SortFiles()
        {
            if (this.IsInputValid())
            {
                this.model.Organize(this.SourcePath, this.DestinationPath);
            }
            else
            {
                MessageBox.Show("Please select a source and a destination!");
            }
        }

        private bool IsInputValid()
        {
            return !string.IsNullOrEmpty(this.SourcePath) &&
                !string.IsNullOrEmpty(this.DestinationPath);
        }

        public void SelectSource()
        {
            if (browser == null)
            {
                this.InitializeDirectoryDialog();
            }

            DialogResult result = browser.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.SourcePath = browser.SelectedPath;
            }
        }

        public void SelectDestination()
        {
            if (browser == null)
            {
                this.InitializeDirectoryDialog();
            }

            DialogResult result = browser.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.DestinationPath = browser.SelectedPath;
            }
        }

        private void InitializeDirectoryDialog()
        {
            this.browser = new FolderBrowserDialog();
            browser.RootFolder = Environment.SpecialFolder.UserProfile;
            browser.ShowNewFolderButton = true;
        }

        public void ClearLog()
        {
            this.Log.Clear();
        }
    }
}
