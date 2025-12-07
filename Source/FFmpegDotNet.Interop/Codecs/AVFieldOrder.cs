
#region Using Directives

using FFmpegDotNet.Interop.Utilities;
using System;
using System.Runtime.InteropServices;

#endregion

namespace FFmpegDotNet.Interop.Codecs
{
    /// <summary>
    /// Represents a codec.
    /// </summary>
    /// avcodec.h
    public enum AVFieldOrder
    {
        AV_FIELD_UNKNOWN,
        AV_FIELD_PROGRESSIVE,
        AV_FIELD_TT,          ///< Top coded_first, top displayed first
        AV_FIELD_BB,          ///< Bottom coded first, bottom displayed first
        AV_FIELD_TB,          ///< Top coded first, bottom displayed first
        AV_FIELD_BT,          ///< Bottom coded first, top displayed first
    };
}
