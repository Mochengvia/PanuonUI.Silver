using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Panuon.UI.Silver
{
    /// <summary>
    /// A temporary file class. Delete when disposing.
    /// </summary>
    public class TemporaryFile : IDisposable
    {
        #region Ctor
        /// <summary>
        /// Create temporary file object.
        /// </summary>
        /// <param name="directoryPath">Storage folder path. Create if not exists.</param>
        public TemporaryFile(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            var fileName = Guid.NewGuid().ToString().ToLower();
            SourcePath = Path.Combine(directoryPath, fileName);
            using (File.Create(SourcePath)) ;
        }
        #endregion

        #region Property
        public string SourcePath { get; }

        #endregion

        #region Dispose
        public void Dispose()
        {
            if (!string.IsNullOrEmpty(SourcePath) && File.Exists(SourcePath))
                File.Delete(SourcePath);
        }
        #endregion
    }
}
