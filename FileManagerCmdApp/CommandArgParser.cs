using FileAccess;
using System;

namespace FileManagerCmdApp
{
    internal class CommandArgParser
    {
        internal static Command Parse(string[] args)
        {
            if (args.Length < 1)
            {
                return Command.Error;
            }

            if (args[0] == "-h" || args[0] == "--help")
            {
                return Command.Help;
            }

            if (args.Length > 1)
            {
                IFileSystemService fileSystem = new FileSystemService();
                bool isValid1 = fileSystem.IsPathValid(args[0]).Result == Result.Success;
                bool isValid2 = fileSystem.IsPathValid(args[1]).Result == Result.Success;

                if (isValid1 && isValid2)
                {
                    return Command.Run;
                }
                else
                {
                    return Command.Error;
                }
            }

            return Command.Error;
        }
    }
}