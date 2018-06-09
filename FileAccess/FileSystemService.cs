using System;
using System.IO;

namespace FileAccess
{
    public class FileSystemService : IFileSystemService
    {
        public Response<string[]> GetFiles(string path)
        {
            Result result = Guard.ShouldNotBeNullorEmpty(path);
            if (result == Result.Success)
            {
                try
                {
                    string[] files = Directory.GetFiles(path);
                    return new Response<string[]>(files);
                    
                }
                catch(Exception e)
                {
                    return new Response<string[]>(e);
                }
            }
            else
            {
                return new Response<string[]>(result);
            }
        }

        public Response CreateDirectory(string path)
        {
            Result result = Guard.ShouldNotBeNullorEmpty(path);
            if (result == Result.Success)
            {
                try
                {
                    var directoryInfo = Directory.CreateDirectory(path);
                    return new Response(Result.Success);

                }
                catch (Exception e)
                {
                    return new Response(e);
                }
            }
            else
            {
                return new Response(result);
            }
        }

        public Response Delete(string path)
        {
            Result result = Guard.ShouldNotBeNullorEmpty(path);
            if (result == Result.Success)
            {
                try
                {
                    Directory.Delete(path);
                    return new Response(Result.Success);

                }
                catch (Exception e)
                {
                    return new Response(e);
                }
            }
            else
            {
                return new Response(result);
            }

        }

        public Response<bool> Exists(string path)
        {
            Result result = Guard.ShouldNotBeNullorEmpty(path);
            if (result == Result.Success)
            {
                try
                {
                    bool exists = Directory.Exists(path);
                    return new Response<bool>(exists);

                }
                catch (Exception e)
                {
                    return new Response<bool>(e);
                }
            }
            else
            {
                return new Response<bool>(result);
            }

        }

        public Response<string[]> GetFiles(string path, string searchPattern, SearchOption searchOption)
        {

            Result result = Guard.ShouldNotBeNullorEmpty(path);
            if (result == Result.Success)
            {
                try
                {
                    string[] files = Directory.GetFiles(path, searchPattern, searchOption);
                    return new Response<string[]>(files);

                }
                catch (Exception e)
                {
                    return new Response<string[]>(e);
                }
            }
            else
            {
                return new Response<string[]>(result);
            }
        }

        public Response CopyFile(string filePathSource, string filePathDestination)
        {
            try
            {
                File.Copy(filePathSource, filePathDestination);
                return new Response(Result.Success);
            }
            catch (Exception e)
            {
                return new Response(e);
            }
        }

        public Response<bool> IsPathValid(string path)
        {
            bool isValid = false;
            Guard.AgainstNull(path, nameof(path));
            try
            {
                Path.GetFullPath(path);
                isValid = true;
            }
            catch (ArgumentException ae)
            {
                return new Response<bool>(ae);
            }
            catch (PathTooLongException ptle)
            {
                return new Response<bool>(ptle);
            }
            catch (Exception e) {
                return new Response<bool>(e);
            }

            return new Response<bool>(isValid);
        }
    }
}
