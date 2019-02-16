using System.IO;
using ICSharpCode.SharpZipLib.Zip;

namespace DatabaseObjectPackageInstaller.Helpers
{
    internal static class CompressedFileHelper
    {
        internal static bool IsFileCompressed(string zipFilePath)
        {
            try
            {
                using (var zipFile = new ZipFile(zipFilePath))
                {
                    return zipFile.TestArchive(true);
                }
            }
            catch
            {
                return false;
            }
        }

        internal static string ExtractFiles(string zipFilePath, string targetPath)
        {
            var zipExtractor = new FastZip();
            targetPath = Path.Combine(targetPath, Path.GetFileNameWithoutExtension(zipFilePath));
            zipExtractor.ExtractZip(zipFilePath, targetPath, null);
            return targetPath;
        }
    }
}
