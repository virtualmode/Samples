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

        [DllImport(LIBRARY_NAME, EntryPoint = "GetPlatformDescription", CallingConvention = CallingConvention.Cdecl)]
        public static extern string GetCustomDescription();

        #endregion Methods
    }
}
