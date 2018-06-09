using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FileAccess
{
    public class DateTimeUtilities
    {
        /// <summary>
        /// Parses the date taken Exif property item value to a DateTime object.
        /// </summary>
        /// <param name="rawDateTakenData">Date taken property 0x9003</param>
        /// <returns>Returns a DateTime object.</returns>
        /// <remarks>The data is ASCII and in the following format: YYYY:MM:DD HH:MM:SS with
        ///          null terminator at the end.
        /// </remarks>
        public static DateTime ParseDateTimeFromExifProperty(byte[] rawDateTakenData)
        {
            Regex r = new Regex(":");
            string dateTaken = Encoding.ASCII.GetString(rawDateTakenData).Trim('\0');
            string[] dateParts = dateTaken.Split(' ');
            string date = dateParts[0].Replace(':', '/');
            string time = dateParts[1];
            string dateToParse = date + " " + time;
            return DateTime.Parse(dateToParse);
        }

        public static string NumberToMonth(int month)
        {
            switch(month)
            {
                case 1:
                    return "January";
                case 2:
                    return "Feburary";
                case 3:
                    return "March";
                case 4:
                    return "April";
                case 5:
                    return "May";
                case 6:
                    return "June";
                case 7:
                    return "July";
                case 8:
                    return "August";
                case 9:
                    return "September";
                case 10:
                    return "October";
                case 11:
                    return "November";
                case 12:
                    return "December";
                default:
                    return "Invalid month";
            }
        }
    }
}
