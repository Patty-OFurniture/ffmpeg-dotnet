
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
    [StructLayout(LayoutKind.Sequential)]
    public struct AVCodecParameters
    {
        #region Public Fields

        /**
         * General type of the encoded data.
         */
        public AVMediaType codec_type;
        /**
         * Specific type of the encoded data (the codec used).
         */
        public AVCodecID codec_id;
        /**
         * Additional information about the codec (corresponds to the AVI FOURCC).
         */
        public UInt32 codec_tag;

        /**
         * Extra binary data needed for initializing the decoder, codec-dependent.
         *
         * Must be allocated with av_malloc() and will be freed by
         * avcodec_parameters_free(). The allocated size of extradata must be at
         * least extradata_size + AV_INPUT_BUFFER_PADDING_SIZE, with the padding
         * bytes zeroed.
         */
        IntPtr extradata;
        /**
         * Size of the extradata content in bytes.
         */
        public int extradata_size;

        /**
         * Additional data associated with the entire stream.
         *
         * Should be allocated with av_packet_side_data_new() or
         * av_packet_side_data_add(), and will be freed by avcodec_parameters_free().
         */
        public IntPtr coded_side_data; // AVPacketSideData

        /**
         * Amount of entries in @ref coded_side_data.
         */
        public int nb_coded_side_data;

        /**
         * - video: the pixel format, the value corresponds to enum AVPixelFormat.
         * - audio: the sample format, the value corresponds to enum AVSampleFormat.
         */
        public int format;

        /**
         * The average bitrate of the encoded data (in bits per second).
         */
        public Int64 bit_rate;

        /**
         * The number of bits per sample in the codedwords.
         *
         * This is basically the bitrate per sample. It is mandatory for a bunch of
         * formats to actually decode them. It's the number of bits for one sample in
         * the actual coded bitstream.
         *
         * This could be for example 4 for ADPCM
         * For PCM formats this matches bits_per_raw_sample
         * Can be 0
         */
        public int bits_per_coded_sample;

        /**
         * This is the number of valid bits in each output sample. If the
         * sample format has more bits, the least significant bits are additional
         * padding bits, which are always 0. Use right shifts to reduce the sample
         * to its actual size. For example, audio formats with 24 bit samples will
         * have bits_per_raw_sample set to 24, and format set to AV_SAMPLE_FMT_S32.
         * To get the original sample use "(int32_t)sample >> 8"."
         *
         * For ADPCM this might be 12 or 16 or similar
         * Can be 0
         */
        public int bits_per_raw_sample;

        /**
         * Codec-specific bitstream restrictions that the stream conforms to.
         */
        public int profile;
        public int level;

        /**
         * Video only. The dimensions of the video frame in pixels.
         */
        public int width;
        public int height;

        /**
         * Video only. The aspect ratio (width / height) which a single pixel
         * should have when displayed.
         *
         * When the aspect ratio is unknown / undefined, the numerator should be
         * set to 0 (the denominator may have any value).
         */
        public AVRational sample_aspect_ratio;

        /**
         * Video only. Number of frames per second, for streams with constant frame
         * durations. Should be set to { 0, 1 } when some frames have differing
         * durations or if the value is not known.
         *
         * @note This field corresponds to values that are stored in codec-level
         * headers and is typically overridden by container/transport-layer
         * timestamps, when available. It should thus be used only as a last resort,
         * when no higher-level timing information is available.
         */
        public AVRational framerate;

        /**
         * Video only. The order of the fields in interlaced video.
         */
        public AVFieldOrder field_order;

        /**
         * Video only. Additional colorspace characteristics.
         */
        public AVColorRange color_range;
        public AVColorPrimaries color_primaries;
        public AVColorTransferCharacteristic color_trc;
        public AVColorSpace color_space;
        public AVChromaLocation chroma_location;

        /**
         * Video only. Number of delayed frames.
         */
        public int video_delay;

        /**
         * Audio only. The channel layout and number of channels.
         */
        public AVChannelLayout ch_layout;
        /**
         * Audio only. The number of audio samples per second.
         */
        public int sample_rate;
        /**
         * Audio only. The number of bytes per coded audio frame, required by some
         * formats.
         *
         * Corresponds to nBlockAlign in WAVEFORMATEX.
         */
        public int block_align;
        /**
         * Audio only. Audio frame size, if known. Required by some formats to be static.
         */
        public int frame_size;

        /**
         * Audio only. The amount of padding (in samples) inserted by the encoder at
         * the beginning of the audio. I.e. this number of leading decoded samples
         * must be discarded by the caller to get the original audio without leading
         * padding.
         */
        public int initial_padding;
        /**
         * Audio only. The amount of padding (in samples) appended by the encoder to
         * the end of the audio. I.e. this number of decoded samples must be
         * discarded by the caller from the end of the stream to get the original
         * audio without any trailing padding.
         */
        public int trailing_padding;
        /**
         * Audio only. Number of samples to skip after a discontinuity.
         */
        public int seek_preroll;

        #endregion
    }
}