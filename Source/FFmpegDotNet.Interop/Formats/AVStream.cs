
#region Using Directives

using FFmpegDotNet.Interop.Codecs;
using FFmpegDotNet.Interop.Utilities;
using System;
using System.Runtime.InteropServices;

#endregion

namespace FFmpegDotNet.Interop.Formats
{
    /// <summary>
    /// Represents a single stream within a format context.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct AVStream
    {
        #region Public Fields

        /// <summary>
        /// * A class for @ref avoptions. Set on stream creation.
        /// </summary>
        IntPtr av_class;

        /// <summary>
        /// Contains the stream index in the <see cref="AVFormatContext"/>.
        /// </summary>
        public int index;

        /// <summary>
        /// Contains the format-specific stream ID. When decoding this is set by libavformat. When encoding this is set by the user, but it is being
        /// replaced by libavformat if left unset.
        /// </summary>
        public int id;

        /// <summary>
        ///      * Codec parameters associated with this stream. Allocated and freed by
         /// * libavformat in avformat_new_stream() and avformat_free_context()
         /// * respectively.

        /// </summary>
        public IntPtr codecpar; // AVCodecParameters

        /// <summary>
        /// Contains format private data.
        /// </summary>
        public IntPtr priv_data;

        AVRational time_base;

        Int64 start_time;

        /**
         * Decoding: duration of the stream, in stream time base.
         * If a source file does not specify a duration, but does specify
         * a bitrate, this value will be estimated from bitrate and file size.
         *
         * Encoding: May be set by the caller before avformat_write_header() to
         * provide a hint to the muxer about the estimated duration.
         */
        Int64 duration;

        Int64 nb_frames;                 ///< number of frames in this stream if known or 0

        /**
         * Stream disposition - a combination of AV_DISPOSITION_* flags.
         * - demuxing: set by libavformat when creating the stream or in
         *             avformat_find_stream_info().
         * - muxing: may be set by the caller before avformat_write_header().
         */
        int disposition;

        AVDiscard discard; ///< Selects which packets can be discarded at will and do not need to be demuxed.

    /**
     * sample aspect ratio (0 if unknown)
     * - encoding: Set by user.
     * - decoding: Set by libavformat.
     */
    AVRational sample_aspect_ratio;

        IntPtr metadata;

        /**
         * Average framerate
         *
         * - demuxing: May be set by libavformat when creating the stream or in
         *             avformat_find_stream_info().
         * - muxing: May be set by the caller before avformat_write_header().
         */
        AVRational avg_frame_rate;

        /**
         * For streams with AV_DISPOSITION_ATTACHED_PIC disposition, this packet
         * will contain the attached picture.
         *
         * decoding: set by libavformat, must not be modified by the caller.
         * encoding: unused
         */
        AVPacket attached_pic;

        /**
         * Flags indicating events happening on the stream, a combination of
         * AVSTREAM_EVENT_FLAG_*.
         *
         * - demuxing: may be set by the demuxer in avformat_open_input(),
         *   avformat_find_stream_info() and av_read_frame(). Flags must be cleared
         *   by the user once the event has been handled.
         * - muxing: may be set by the user after avformat_write_header(). to
         *   indicate a user-triggered event.  The muxer will clear the flags for
         *   events it has handled in av_[interleaved]_write_frame().
         */
        AvStreamEvent event_flags;

        /**
         * Real base framerate of the stream.
         * This is the lowest framerate with which all timestamps can be
         * represented accurately (it is the least common multiple of all
         * framerates in the stream). Note, this value is just a guess!
         * For example, if the time base is 1/90000 and all frames have either
         * approximately 3600 or 1800 timer ticks, then r_frame_rate will be 50/1.
         */
        AVRational r_frame_rate;

        /**
         * Number of bits in timestamps. Used for wrapping control.
         *
         * - demuxing: set by libavformat
         * - muxing: set by libavformat
         *
         */
        int pts_wrap_bits;

        #endregion
    }
}