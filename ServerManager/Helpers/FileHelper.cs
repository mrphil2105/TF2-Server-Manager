using System;
using System.IO;

namespace ServerManager.Helpers
{
    public static class FileHelper
    {
        public static bool IsDirectoryValid(string directory)
        {
            if (string.IsNullOrEmpty(directory))
            {
                throw new ArgumentException("Value cannot be null or empty.", nameof(directory));
            }

            try
            {
                Path.GetFullPath(directory);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
