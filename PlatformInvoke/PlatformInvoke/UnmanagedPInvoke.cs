using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PlatformInvoke
{
    /// <summary>
    /// Class that uses unmanaged code.
    /// </summary>
    internal class UnmanagedPInvoke
    {
        #region Constants

        private const string LIBRARY_NAME = "UnmanagedCode.dll";

        #endregion Constants

        #region Methods

        [DllImport(LIBRARY_NAME, EntryPoint = "GetPlatformDescription")]
        public static extern IntPtr GetCustomDescription();

        [DllImport(LIBRARY_NAME, EntryPoint = "GetPlatformDescription", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.LPTStr)]
        public static extern string GetCustomDescriptionVariant();

        #endregion Methods
    }
}
