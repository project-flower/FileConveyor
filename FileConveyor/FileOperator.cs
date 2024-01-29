using FileConveyor.Constants;
using NativeMethods;
using System;
using System.IO;

namespace FileConveyor
{
    public class FileOperator
    {
        #region Public Methods

        public static void MoveFile(string fileName, string destination, string pattern, DateTimeSources dateTimeSource)
        {
            try
            {
                var fileInfo = new FileInfo(fileName);
                string newFileName = pattern.Replace("*", fileInfo.Name);

                if (pattern.Contains("?"))
                {
                    DateTime dateTime;

                    switch (dateTimeSource)
                    {
                        case DateTimeSources.FileCreated:
                            dateTime = fileInfo.CreationTime;
                            break;
                        default:
                        case DateTimeSources.FileUpdated:
                            dateTime = fileInfo.LastWriteTime;
                            break;
                        case DateTimeSources.SystemClock:
                            dateTime = DateTime.Now;
                            break;
                    }

                    newFileName = newFileName.Replace("?", dateTime.ToString("yyyyMMddHHmmss"));

                    var shFileOpStruct = new SHFILEOPSTRUCT
                    {
                        hwnd = IntPtr.Zero,
                        pFrom = $"{fileName}\0",
                        pTo = $"{Path.Combine(destination, newFileName)}{fileInfo.Extension}\0",
                        wFunc = FO.MOVE,
                        fFlags = (FILEOP_FLAGS.FOF_ALLOWUNDO | FILEOP_FLAGS.FOF_SILENT),
                        fAnyOperationsAborted = false,
                        hNameMappings = IntPtr.Zero,
                        lpszProgressTitle = string.Empty
                    };

                    int result = Shell32.SHFileOperation(ref shFileOpStruct);

                    if (result != 0)
                    {
                        throw new Exception(string.Format("File operation failed. (code: 0x{0:X4})", result));
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        #endregion
    }
}
