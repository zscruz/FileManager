using FileAccess;
using FileOrganizer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagerCmdApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Command cmd = CommandArgParser.Parse(args);
            switch(cmd)
            {
                case Command.Error:
                    Console.WriteLine("Invalid command or arguments");
                    break;
                case Command.Help:
                    Console.WriteLine("HELP");
                    break;
                case Command.Run:
                    Organizer organizer = new Organizer();
                    organizer.Progress.ProgressChanged += Progress_ProgressChanged;
                    organizer.OrganizeByDateTaken(args[0], args[1]);
                    break;

            }
            Console.ReadLine();
            Environment.Exit(0);
        }

        private static void Progress_ProgressChanged(object sender, EventArgs e)
        {
            if (sender is ProgressStep)
            {
                Console.WriteLine(((ProgressStep)sender).CurrentProgressStep);
            }
        }
    }
}
