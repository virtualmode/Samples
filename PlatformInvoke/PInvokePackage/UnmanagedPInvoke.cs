using System;
using System.Runtime.InteropServices;

namespace PInvokePackage
{
    /// <summary>
    /// Class that uses unmanaged code.
    /// </summary>
    internal class UnmanagedPInvoke
    {
        private static object _legacyPInvoke = LegacyPInvoke.Initialize(); // TODO Only for .NET Framework support.

        #region Constants

        private const string LIBRARY_NAME = "UnmanagedCode";

        #endregion Constants

        #region Methods

        //[DefaultDllImportSearchPaths(DllImportSearchPath.UserDirectories)]
        [DllImport(LIBRARY_NAME, EntryPoint = "GetPlatformDescription")]
        public static extern IntPtr GetCustomDescription();

        [DllImport(LIBRARY_NAME, EntryPoint = "GetPlatformDescription", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.LPTStr)]
        public static extern string GetCustomDescriptionVariant();

        #endregion Methods
    }
}
