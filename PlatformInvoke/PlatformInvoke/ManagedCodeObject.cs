using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PlatformInvoke
{
    /// <summary>
    /// This solution is used commonly to present unmanaged object.
    /// </summary>
    public class ManagedCodeObject : SafeHandle
    {
        #region Properties

        public override bool IsInvalid => handle == IntPtr.Zero;

        #endregion Properties

        #region Constructors

        private ManagedCodeObject() :
            base(IntPtr.Zero, true)
        {
        }

        #endregion Constructors

        #region Methods

        protected override bool ReleaseHandle()
        {
            // TODO Here you must release resources.
            handle = IntPtr.Zero;
            return IsInvalid;
        }

        public static ManagedCodeObject Create()
        {
            // TODO Here you can use unmanaged functions for creation.
            return new ManagedCodeObject();
        }

        public string GetPlatformDescription()
        {
            return Marshal.PtrToStringAnsi(UnmanagedPInvoke.GetCustomDescription());
        }

        #endregion Methods
    }
}
