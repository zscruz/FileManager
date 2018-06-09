using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileAccess
{
    public static class FileSystemServiceFactory
    {
        public static IFileSystemService Create()
        {
            return new FileSystemService();
        }
    }
}
