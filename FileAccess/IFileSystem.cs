using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileAccess
{
    public interface IFileSystemService
    {
        Response CopyFile(string filePathSource, string filePathDestination);

        Response CreateDirectory(string path);

        Response Delete(string path);

        Response<bool> Exists(string path);

        Response<string[]> GetFiles(string path);

        Response<string[]> GetFiles(string path, string searchPattern, SearchOption searchOption);

        Response<bool> IsPathValid(string path);
    }
}
