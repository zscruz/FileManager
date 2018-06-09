using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileAccess
{
    public class ExifPropertyReader : IExifPropertyReader
    {
        public DateTime GetDateTakenFromImage(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open, System.IO.FileAccess.Read))
            using (Image img = Image.FromStream(fs, false, false))
            {
                PropertyItem propItem = img.GetPropertyItem(ExifProperties.dateTaken);
                return DateTimeUtilities.ParseDateTimeFromExifProperty(propItem.Value);
            }
        }
    }
}
