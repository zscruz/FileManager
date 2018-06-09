using FileAccess;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileOrganizer
{
    public class Organizer
    {
        private IFileSystemService fileSystemService;
        public ProgressStep Progress {get; set;}

        public Organizer()
        {
            this.fileSystemService = FileSystemServiceFactory.Create();
            this.Progress = new ProgressStep();
        }

        public void OrganizeByDateTaken(string sourcePath, string destinationPath)
        {
            Response<string[]> resFiles = this.fileSystemService.GetFiles(sourcePath);
            if (resFiles.Result == Result.Success)
            {
                IExifPropertyReader reader = new ExifPropertyReader();
                DateTime fileDateTime;
                string[] files = resFiles.Data;
                foreach (var file in files)
                {
                    fileDateTime = reader.GetDateTakenFromImage(file);
                    int year = fileDateTime.Year;
                    int month = fileDateTime.Month;
                    string checkYearPath = Path.Combine(destinationPath, year.ToString());
                    string checkMonthPath = Path.Combine(checkYearPath, DateTimeUtilities.NumberToMonth(month));
                    if (!this.fileSystemService.Exists(checkYearPath).Data)
                    {
                        this.fileSystemService.CreateDirectory(checkYearPath);
                    }

                    if (!this.fileSystemService.Exists(checkMonthPath).Data)
                    {
                        this.fileSystemService.CreateDirectory(checkMonthPath);
                    }

                    Result result = this.fileSystemService.CopyFile(file, Path.Combine(checkMonthPath, Path.GetFileName(file))).Result;

                    if (result == Result.Success)
                    {
                        this.Progress.CurrentProgressStep = (Path.GetFileName(file) + " " + "successfully copied!");
                        this.Progress.OnProgressChanged(EventArgs.Empty);
                    }
                    else
                    {
                        this.Progress.CurrentProgressStep = (Path.GetFileName(file) + " " + "failed to copy!");
                        this.Progress.OnProgressChanged(EventArgs.Empty);
                    }
                }
            }
        }
    }
}
