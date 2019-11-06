using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Panuon.UI.Silver
{
    /// <summary>
    /// A temporary directory class. Delete when disposing.
    /// </summary>
    public class TemporaryDirectory : IDisposable
    {
        #region Ctor
        static TemporaryDirectory()
        {
            StorageDirectoryPath = Path.Combine(Path.GetTempPath(), "Panuon");
        }

        /// <summary>
        /// Create temporary directory object.
        /// </summary>
        public TemporaryDirectory()
        {
            if (!Directory.Exists(StorageDirectoryPath))
            {
                Directory.CreateDirectory(StorageDirectoryPath);
            }

            var folderName = Guid.NewGuid().ToString().ToLower();
            SourcePath = Path.Combine(StorageDirectoryPath, folderName);

            if(!Directory.Exists(SourcePath))
                Directory.CreateDirectory(SourcePath);
        }
        #endregion

        #region Property
        /// <summary>
        /// Directory path to stoarge temporary folders. Default is "%temp%\Panuon".
        /// </summary>
        public static string StorageDirectoryPath { get; set; }

        public string SourcePath { get; }

        #endregion

        #region Dispose
        public void Dispose()
        {
            if (!string.IsNullOrEmpty(SourcePath) && Directory.Exists(SourcePath))
                Directory.Delete(SourcePath, true);
        }
        #endregion
    }
}
