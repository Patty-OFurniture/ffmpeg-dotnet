
#region Using Directives

using System;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;

#endregion

namespace FFmpegDotNet.Interop.Utilities
{
    [StructLayout(LayoutKind.Sequential)]
    struct AVChannelCustom
    {
        #region Public Fields

        AVChannel id;

        [MarshalAs(UnmanagedType.LPStr, SizeConst = 16)]
        public string name;

        IntPtr opaque;

        #endregion
    }
}
