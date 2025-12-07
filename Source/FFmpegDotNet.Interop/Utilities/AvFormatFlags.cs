namespace FFmpegDotNet.Interop.Utilities
{
    /// avformat.h
    enum AvFormatFlags
    {
        AVFMT_FLAG_GENPTS = 0x0001, ///< Generate missing pts even if it requires parsing future frames.
        AVFMT_FLAG_IGNIDX = 0x0002, ///< Ignore index.
        AVFMT_FLAG_NONBLOCK = 0x0004, ///< Do not block when reading packets from input.
        AVFMT_FLAG_IGNDTS = 0x0008, ///< Ignore DTS on frames that contain both DTS & PTS
        AVFMT_FLAG_NOFILLIN = 0x0010, ///< Do not infer any values from other values, just return what is stored in the container
        AVFMT_FLAG_NOPARSE = 0x0020, ///< Do not use AVParsers, you also must set AVFMT_FLAG_NOFILLIN as the filling code works on frames and no parsing -> no frames. Also seeking to frames can not work if parsing to find frame boundaries has been disabled
        AVFMT_FLAG_NOBUFFER = 0x0040, ///< Do not buffer frames when possible
        AVFMT_FLAG_CUSTOM_IO = 0x0080, ///< The caller has supplied a custom AVIOContext, don't avio_close() it.
        AVFMT_FLAG_DISCARD_CORRUPT = 0x0100, ///< Discard frames marked corrupted
        AVFMT_FLAG_FLUSH_PACKETS = 0x0200, ///< Flush the AVIOContext every packet.
        /**
         * When muxing, try to avoid writing any random/volatile data to the output.
         * This includes any random IDs, real-time timestamps/dates, muxer version, etc.
         *
         * This flag is mainly intended for testing.
         */
        AVFMT_FLAG_BITEXACT = 0x0400,
        AVFMT_FLAG_SORT_DTS = 0x10000, ///< try to interleave outputted packets by dts (using this flag can slow demuxing down)
        AVFMT_FLAG_FAST_SEEK = 0x80000, ///< Enable fast, but inaccurate seeks for some formats
        AVFMT_FLAG_AUTO_BSF = 0x200000, ///< Add bitstream filters as requested by the muxer
    }
}
