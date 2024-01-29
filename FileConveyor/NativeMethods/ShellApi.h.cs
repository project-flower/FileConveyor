using System;
using System.Runtime.InteropServices;

namespace NativeMethods
{
    public enum FILEOP_FLAGS : ushort
    {
        FOF_MULTIDESTFILES = 0x0001,
        FOF_CONFIRMMOUSE = 0x0002,
        FOF_SILENT = 0x0004,
        FOF_RENAMEONCOLLISION = 0x0008,
        FOF_NOCONFIRMATION = 0x0010,
        FOF_WANTMAPPINGHANDLE = 0x0020,
        FOF_ALLOWUNDO = 0x0040,
        FOF_FILESONLY = 0x0080,
        FOF_SIMPLEPROGRESS = 0x0100,
        FOF_NOCONFIRMMKDIR = 0x0200,
        FOF_NOERRORUI = 0x0400,
        FOF_NOCOPYSECURITYATTRIBS = 0x0800,
        FOF_NORECURSION = 0x1000,
        FOF_NO_CONNECTED_ELEMENTS = 0x2000,
        FOF_WANTNUKEWARNING = 0x4000,
        FOF_NORECURSEREPARSE = 0x8000
    }

    public enum FO
    {
        MOVE = 0x0001,
        COPY = 0x0002,
        DELETE = 0x0003,
        RENAME = 0x0004
    }

    public enum SEE_MASK : uint
    {
        IDLIST = 0x00000004,
        INVOKEIDLIST = 0x0000000C,
    }

    public static partial class Shell32
    {
        #region Public Methods

        [DllImport(LibraryName, CharSet = CharSet.Auto)]
        public static extern int ShellExecuteEx(ref SHELLEXECUTEINFO lpExecInfo);

        [DllImport(LibraryName, CharSet = CharSet.Unicode)]
        public static extern int SHFileOperation(ref SHFILEOPSTRUCT lpFileOp);

        #endregion
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct SHELLEXECUTEINFO
    {
        public uint cbSize;
        public SEE_MASK fMask;
        public IntPtr hwnd;
        public string lpVerb;
        public string lpFile;
        public string lpParameters;
        public string lpDirectory;
        public int nShow;
        public IntPtr hInstApp;
        public IntPtr lpIDList;
        public string lpClass;
        public IntPtr hkeyClass;
        public uint dwHotKey;
        public IntPtr hIcon;
        public IntPtr hProcess;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SHFILEOPSTRUCT
    {
        public IntPtr hwnd;
        public FO wFunc;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string pFrom;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string pTo;
        public FILEOP_FLAGS fFlags;
        public bool fAnyOperationsAborted;
        public IntPtr hNameMappings;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string lpszProgressTitle;
    }
}
