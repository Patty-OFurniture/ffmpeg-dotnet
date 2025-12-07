
#region Using Directives

using FFmpegDotNet.Interop.Utilities;
using System;
using System.Runtime.InteropServices;

#endregion

namespace FFmpegDotNet.Interop.Codecs
{
    /// <summary>
    /// Represents the codec context, which is a main external API structure. Please use AVOptions (av_opt* / av_set/get*()) to access these fields from user
    /// applications.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct AVCodecContext
    {
        #region Public Fields

        /// <summary>
        /// Contains the information on the structure for av_log. This is set by avcodec_alloc_context3.
        /// </summary>
        public IntPtr av_class;

        /// <summary>
        /// Contains the log level offset.
        /// </summary>
        public int log_level_offset;

        /// <summary>
        /// Contains the media type of the codec.
        /// </summary>
    	public AVMediaType codec_type;

        /// <summary>
        /// Contains a pointer to the codec (of type <see cref="AVCodec"/>).
        /// </summary>
        public IntPtr codec;

        /// <summary>
        /// Contains the ID of the codec.
        /// </summary>
        public AVCodecID codec_id;

        /// <summary>
        /// Contains the fourcc (LSB first, so "ABCD" -> ('D' << 24) + ('C' << 16) + ('B' << 8) + 'A'). This is used to work around some encoder bugs. A
        /// demuxer should set this to what is stored in the field used to identify the codec. If there are multiple such fields in a container then the
        /// demuxer should choose the one which maximizes the information about the used codec. If the codec tag field in a container is larger than 32
        /// bits then the demuxer should remap the longer ID to 32 bits with a table or other structure. Alternatively a new extra_codec_tag + size could
        /// be added but for this a clear advantage must be demonstrated first. When encoding this is set by the suer, if not then the default based on
        /// codec_id will be used. When decoding this is set by the user and will be converted to uppercase by libavcodec during init.
        /// </summary>
        public uint codec_tag;

        /// <summary>
        /// Contains format private data.
        /// </summary>
        public IntPtr priv_data;

        /// <summary>
        /// Contains private context used for intrenal data. Unlike priv_data, this is not codec-specific. It is used in general libavcodec functions.
        /// </summary>
        public IntPtr @internal;

        /// <summary>
        /// Contains private data of the user and can be used to carry application specific stuff.
        /// </summary>
        public IntPtr opaque;

        /// <summary>
        /// Contains the average bitrate. When encoding this is set by the user and remains unused for constant quantizer encoding. For decoding this is set
        /// by the user but may be overwritten by libavcodec if this info is available in the stream.
        /// </summary>
        public Int64 bit_rate;

        /// <summary>
        /// Contains AV_CODEC_FLAG_* flags. When encoding as well as decoding this is set by the user.
        /// </summary>
        AVCodecFlag flags;

        /// <summary>
        /// Contains AV_CODEC_FLAG2_* flags. When encoding as well as decoding this is set by the user.
        /// </summary>
        AVCodecFlag2 flags2;

        /// <summary>
        /// Contains extra data. Some codecs need/can use extradata like Huffman tables: MJPEG: Huffman tables, rv10: additional flags, MPEG-4: global
        /// headers (they can be in the bitstream or here). The allocated memory should be AV_INPUT_BUFFER_PADDING_SIZE bytes larger than extradata_size to
        /// avoid problems if it is read with the bitstream reader. The bytewise contents of extradata must not depend on the architecture or CPU endianness.
        /// When encoding this is set/allocated/freed by libavcodec. When decodnig this is set/allocated/freed by the user.
        /// </summary>
        public IntPtr extradata;

        /// <summary>
        /// Contains the size of the extra data.
        /// </summary>
        public int extradata_size;

        /// <summary>
        /// Contains the fundamental unit of time (in seconds) in terms of which frame timestamps are represented. For fixed-fps content, timebase should be
        /// 1/framerate and timestamp increments should be identically 1. This often, but not always is the inverse of the frame rate or field rate for video.
        /// 1/time_base is not the average frame rate if the frame rate is not constant. Like containers, elementary streams also can store timestamps,
        /// 1/time_base is the unit in which these timestamps are specified. As example of such codec time base see ISO/IEC 14496-2:2001(E)
        /// vop_time_increment_resolution and fixed_vop_rate (fixed_vop_rate == 0 implies that it is different from the framerate). When encoding it MUST be
        /// set by the user. When decoding the use of this field for decoding is deprecated. Use framerate instead.
        /// </summary>
        public AVRational time_base;

        public AVRational pkt_timebase;

        /// <summary>
        /// Contains the ticks per frame. For some codecs, the time base is closer to the field rate than the frame rate. Most notably, H.264 and MPEG-2
        /// specify time_base as half of frame duration if no telecine is used. Set to time_base ticks per frame. Default 1, e.g., H.264/MPEG-2 set it to 2.
        /// </summary>
        public AVRational framerate;

        /// <summary>
        /// Contains the codec delay. When encoding the number of frames delay there will be from the encoder input to the decoder output. (we assume the
        /// decoder matches the spec). When decoding the number of frames delay in addition to what a standard decoder as specified in the spec would produce.
        /// For videos the number of frames the decoded output will be delayed relative to the encoded input. For audio encoding this field is unused (see
        /// initial_padding). For audio decoding, this is the number of samples the decoder needs to output before the decoder's output is valid. When
        /// seeking, you should start decoding this many samples prior to your desired seek point.
        /// </summary>
        public int delay;

        /// <summary>
        /// Contains the width of the video (this is for video only). Note, this field may not match the values of the last <see cref="AVFrame"/> output by
        /// avcodec_decode_video2 due frame reordering. For encoding this MUST be set by the user. For decoding this may be set by the user before opening
        /// the decoder if known e.g. from the container. Some decoders will require the dimensions to be set by the caller. During decoding, the decoder may
        /// overwrite those values as required while parsing the data.
        /// </summary>
        public int width;

        /// <summary>
        /// Contains the height of the video (this is for video only). Note, this field may not match the values of the last <see cref="AVFrame"/> output by
        /// avcodec_decode_video2 due frame reordering. For encoding this MUST be set by the user. For decoding this may be set by the user before opening
        /// the decoder if known e.g. from the container. Some decoders will require the dimensions to be set by the caller. During decoding, the decoder may
        /// overwrite those values as required while parsing the data.
        /// </summary>
        public int height;

        /// <summary>
        /// Contains the bitstream width. This may be different from width e.g. when the decoded frame is cropped before being output or lowres is
        /// enabled. Note, this field may not match the value of the last <see cref="AVFrame"/> output by avcodec_receive_frame() due frame reordering. This
        /// is unused when encoding. When decoding this may be set by the user before opening the decoder if known e.g. from the container. During decoding,
        /// the decoder may overwrite those values as required while parsing the data.
        /// </summary>
        public int coded_width;

        /// <summary>
        /// Contains the bitstream height. This may be different from height e.g. when the decoded frame is cropped before being output or lowres is
        /// enabled. Note, this field may not match the value of the last <see cref="AVFrame"/> output by avcodec_receive_frame() due frame reordering. This
        /// is unused when encoding. When decoding this may be set by the user before opening the decoder if known e.g. from the container. During decoding,
        /// the decoder may overwrite those values as required while parsing the data.
        /// </summary>
        public int coded_height;

        AVRational sample_aspect_ratio;

        /// <summary>
        /// Contains the pixel format, see AV_PIX_FMT_xxx. May be set by the demuxer if known from headers. May be overridden by the decoder if it knows
        /// better. Note this field may not match the value of the last <see cref="AVFrame"/> output by avcodec_receive_frame() due frame reordering. When
        /// encoding this is set by the user. When decoding this is set by the user if known and otherwise overridden by libavcodec while parsing the data.
        /// </summary>
        public AVPixelFormat pix_fmt;

        public AVPixelFormat sw_pix_fmt;

        AVColorPrimaries color_primaries;

        AVColorTransferCharacteristic color_trc;

        AVColorSpace colorspace;

        AVColorRange color_range;

        AVChromaLocation chroma_sample_location;

        AVFieldOrder field_order;

        /**
         * number of reference frames
         * - encoding: Set by user.
         * - decoding: Set by lavc.
         */
        int refs;

        int has_b_frames;

        AVCodecSliceFlag slice_flags;

        // TODO: missing lots of members

        /**
         * If non NULL, 'draw_horiz_band' is called by the libavcodec
         * decoder to draw a horizontal band. It improves cache usage. Not
         * all codecs can do that. You must check the codec capabilities
         * beforehand.
         * When multithreading is used, it may be called from multiple threads
         * at the same time; threads might draw different parts of the same AVFrame,
         * or multiple AVFrames, and there is no guarantee that slices will be drawn
         * in order.
         * The function is also used by hardware acceleration APIs.
         * It is called at least once during frame decoding to pass
         * the data needed for hardware render.
         * In that mode instead of pixel data, AVFrame points to
         * a structure specific to the acceleration API. The application
         * reads the structure and can change some fields to indicate progress
         * or mark state.
         * - encoding: unused
         * - decoding: Set by user.
         * @param height the height of the slice
         * @param y the y position of the slice
         * @param type 1->top field, 2->bottom field, 3->frame
         * @param offset offset into the AVFrame.data from which the slice should be read
         */
        IntPtr draw_horiz_band;

        /**
         * Callback to negotiate the pixel format. Decoding only, may be set by the
         * caller before avcodec_open2().
         *
         * Called by some decoders to select the pixel format that will be used for
         * the output frames. This is mainly used to set up hardware acceleration,
         * then the provided format list contains the corresponding hwaccel pixel
         * formats alongside the "software" one. The software pixel format may also
         * be retrieved from \ref sw_pix_fmt.
         *
         * This callback will be called when the coded frame properties (such as
         * resolution, pixel format, etc.) change and more than one output format is
         * supported for those new properties. If a hardware pixel format is chosen
         * and initialization for it fails, the callback may be called again
         * immediately.
         *
         * This callback may be called from different threads if the decoder is
         * multi-threaded, but not from more than one thread simultaneously.
         *
         * @param fmt list of formats which may be used in the current
         *            configuration, terminated by AV_PIX_FMT_NONE.
         * @warning Behavior is undefined if the callback returns a value other
         *          than one of the formats in fmt or AV_PIX_FMT_NONE.
         * @return the chosen format or AV_PIX_FMT_NONE
         */
        IntPtr get_format;

        /**
         * maximum number of B-frames between non-B-frames
         * Note: The output will be delayed by max_b_frames+1 relative to the input.
         * - encoding: Set by user.
         * - decoding: unused
         */
        int max_b_frames;

        /**
         * qscale factor between IP and B-frames
         * If > 0 then the last P-frame quantizer will be used (q= lastp_q*factor+offset).
         * If < 0 then normal ratecontrol will be done (q= -normal_q*factor+offset).
         * - encoding: Set by user.
         * - decoding: unused
         */
        AVRational b_quant_factor;

        /**
         * qscale offset between IP and B-frames
         * - encoding: Set by user.
         * - decoding: unused
         */
        AVRational b_quant_offset;

        /**
         * qscale factor between P- and I-frames
         * If > 0 then the last P-frame quantizer will be used (q = lastp_q * factor + offset).
         * If < 0 then normal ratecontrol will be done (q= -normal_q*factor+offset).
         * - encoding: Set by user.
         * - decoding: unused
         */
        AVRational i_quant_factor;

        /**
         * qscale offset between P and I-frames
         * - encoding: Set by user.
         * - decoding: unused
         */
        AVRational i_quant_offset;

        /**
         * luminance masking (0-> disabled)
         * - encoding: Set by user.
         * - decoding: unused
         */
        AVRational lumi_masking;

        /**
         * temporary complexity masking (0-> disabled)
         * - encoding: Set by user.
         * - decoding: unused
         */
        AVRational temporal_cplx_masking;

        /**
         * spatial complexity masking (0-> disabled)
         * - encoding: Set by user.
         * - decoding: unused
         */
        AVRational spatial_cplx_masking;

        /**
         * p block masking (0-> disabled)
         * - encoding: Set by user.
         * - decoding: unused
         */
        AVRational p_masking;

        /**
         * darkness masking (0-> disabled)
         * - encoding: Set by user.
         * - decoding: unused
         */
        AVRational dark_masking;

        /**
         * noise vs. sse weight for the nsse comparison function
         * - encoding: Set by user.
         * - decoding: unused
         */
        int nsse_weight;

        /**
         * motion estimation comparison function
         * - encoding: Set by user.
         * - decoding: unused
         */
        int me_cmp;
        /**
         * subpixel motion estimation comparison function
         * - encoding: Set by user.
         * - decoding: unused
         */
        int me_sub_cmp;
        /**
         * macroblock comparison function (not supported yet)
         * - encoding: Set by user.
         * - decoding: unused
         */
        int mb_cmp;
        /**
         * interlaced DCT comparison function
         * - encoding: Set by user.
         * - decoding: unused
         */
        AVCodecIDCTComparison ildct_cmp;

        /**
         * ME diamond size & shape
         * - encoding: Set by user.
         * - decoding: unused
         */
        int dia_size;

        /**
         * amount of previous MV predictors (2a+1 x 2a+1 square)
         * - encoding: Set by user.
         * - decoding: unused
         */
        int last_predictor_count;

        /**
         * motion estimation prepass comparison function
         * - encoding: Set by user.
         * - decoding: unused
         */
        int me_pre_cmp;

        /**
         * ME prepass diamond size & shape
         * - encoding: Set by user.
         * - decoding: unused
         */
        int pre_dia_size;

        /**
         * subpel ME quality
         * - encoding: Set by user.
         * - decoding: unused
         */
        int me_subpel_quality;

        /**
         * maximum motion estimation search range in subpel units
         * If 0 then no limit.
         *
         * - encoding: Set by user.
         * - decoding: unused
         */
        int me_range;

        /**
         * macroblock decision mode
         * - encoding: Set by user.
         * - decoding: unused
         */
        AVCodecMacroblockDecision mb_decision;

        /**
         * custom intra quantization matrix
         * Must be allocated with the av_malloc() family of functions, and will be freed in
         * avcodec_free_context().
         * - encoding: Set/allocated by user, freed by libavcodec. Can be NULL.
         * - decoding: Set/allocated/freed by libavcodec.
         */
        IntPtr intra_matrix;

        /**
            * custom inter quantization matrix
            * Must be allocated with the av_malloc() family of functions, and will be freed in
            * avcodec_free_context().
            * - encoding: Set/allocated by user, freed by libavcodec. Can be NULL.
            * - decoding: Set/allocated/freed by libavcodec.
            */
        IntPtr inter_matrix;

        /**
            * custom intra quantization matrix
            * - encoding: Set by user, can be NULL.
            * - decoding: unused.
            */
        IntPtr chroma_intra_matrix;

        /**
         * precision of the intra DC coefficient - 8
         * - encoding: Set by user.
         * - decoding: Set by libavcodec
         */
        int intra_dc_precision;

        /**
         * minimum MB Lagrange multiplier
         * - encoding: Set by user.
         * - decoding: unused
         */
        int mb_lmin;

        /**
         * maximum MB Lagrange multiplier
         * - encoding: Set by user.
         * - decoding: unused
         */
        int mb_lmax;

        /**
         * - encoding: Set by user.
         * - decoding: unused
         */
        int bidir_refine;

        /**
         * minimum GOP size
         * - encoding: Set by user.
         * - decoding: unused
         */
        int keyint_min;

        /**
         * the number of pictures in a group of pictures, or 0 for intra_only
         * - encoding: Set by user.
         * - decoding: unused
         */
        int gop_size;

        /**
         * Note: Value depends upon the compare function used for fullpel ME.
         * - encoding: Set by user.
         * - decoding: unused
         */
        int mv0_threshold;

        /**
         * Number of slices.
         * Indicates number of picture subdivisions. Used for parallelized
         * decoding.
         * - encoding: Set by user
         * - decoding: unused
         */
        public int slices;

        /* audio only */
        public int sample_rate; ///< samples per second

        /**
         * audio sample format
         * - encoding: Set by user.
         * - decoding: Set by libavcodec.
         */
        public AVSampleFormat sample_fmt;  ///< sample format

        /**
         * Audio channel layout.
         * - encoding: must be set by the caller, to one of AVCodec.ch_layouts.
         * - decoding: may be set by the caller if known e.g. from the container.
         *             The decoder can then override during decoding as needed.
         */
        AVChannelLayout ch_layout;

        /* The following data should not be initialized. */
        /**
         * Number of samples per channel in an audio frame.
         *
         * - encoding: set by libavcodec in avcodec_open2(). Each submitted frame
         *   except the last must contain exactly frame_size samples per channel.
         *   May be 0 when the codec has AV_CODEC_CAP_VARIABLE_FRAME_SIZE set, then the
         *   frame size is not restricted.
         * - decoding: may be set by some decoders to indicate constant frame size
         */
        int frame_size;

        /**
         * number of bytes per packet if constant and known or 0
         * Used by some WAV based audio codecs.
         */
        int block_align;

        /**
         * Audio cutoff bandwidth (0 means "automatic")
         * - encoding: Set by user.
         * - decoding: unused
         */
        int cutoff;

        /**
         * Type of service that the audio stream conveys.
         * - encoding: Set by user.
         * - decoding: Set by libavcodec.
         */
        AVAudioServiceType audio_service_type;

    /**
     * desired sample format
     * - encoding: Not used.
     * - decoding: Set by user.
     * Decoder will decode to this format if it can.
     */
    AVSampleFormat request_sample_fmt;

    /**
     * Audio only. The number of "priming" samples (padding) inserted by the
     * encoder at the beginning of the audio. I.e. this number of leading
     * decoded samples must be discarded by the caller to get the original audio
     * without leading padding.
     *
     * - decoding: unused
     * - encoding: Set by libavcodec. The timestamps on the output packets are
     *             adjusted by the encoder so that they always refer to the
     *             first sample of the data actually contained in the packet,
     *             including any added padding.  E.g. if the timebase is
     *             1/samplerate and the timestamp of the first input sample is
     *             0, the timestamp of the first output packet will be
     *             -initial_padding.
     */
    int initial_padding;

        /**
         * Audio only. The amount of padding (in samples) appended by the encoder to
         * the end of the audio. I.e. this number of decoded samples must be
         * discarded by the caller from the end of the stream to get the original
         * audio without any trailing padding.
         *
         * - decoding: unused
         * - encoding: unused
         */
        int trailing_padding;

        /**
         * Number of samples to skip after a discontinuity
         * - decoding: unused
         * - encoding: set by libavcodec
         */
        int seek_preroll;

        /**
         * This callback is called at the beginning of each frame to get data
         * buffer(s) for it. There may be one contiguous buffer for all the data or
         * there may be a buffer per each data plane or anything in between. What
         * this means is, you may set however many entries in buf[] you feel necessary.
         * Each buffer must be reference-counted using the AVBuffer API (see description
         * of buf[] below).
         *
         * The following fields will be set in the frame before this callback is
         * called:
         * - format
         * - width, height (video only)
         * - sample_rate, channel_layout, nb_samples (audio only)
         * Their values may differ from the corresponding values in
         * AVCodecContext. This callback must use the frame values, not the codec
         * context values, to calculate the required buffer size.
         *
         * This callback must fill the following fields in the frame:
         * - data[]
         * - linesize[]
         * - extended_data:
         *   * if the data is planar audio with more than 8 channels, then this
         *     callback must allocate and fill extended_data to contain all pointers
         *     to all data planes. data[] must hold as many pointers as it can.
         *     extended_data must be allocated with av_malloc() and will be freed in
         *     av_frame_unref().
         *   * otherwise extended_data must point to data
         * - buf[] must contain one or more pointers to AVBufferRef structures. Each of
         *   the frame's data and extended_data pointers must be contained in these. That
         *   is, one AVBufferRef for each allocated chunk of memory, not necessarily one
         *   AVBufferRef per data[] entry. See: av_buffer_create(), av_buffer_alloc(),
         *   and av_buffer_ref().
         * - extended_buf and nb_extended_buf must be allocated with av_malloc() by
         *   this callback and filled with the extra buffers if there are more
         *   buffers than buf[] can hold. extended_buf will be freed in
         *   av_frame_unref().
         *   Decoders will generally initialize the whole buffer before it is output
         *   but it can in rare error conditions happen that uninitialized data is passed
         *   through. \important The buffers returned by get_buffer* should thus not contain sensitive
         *   data.
         *
         * If AV_CODEC_CAP_DR1 is not set then get_buffer2() must call
         * avcodec_default_get_buffer2() instead of providing buffers allocated by
         * some other means.
         *
         * Each data plane must be aligned to the maximum required by the target
         * CPU.
         *
         * @see avcodec_default_get_buffer2()
         *
         * Video:
         *
         * If AV_GET_BUFFER_FLAG_REF is set in flags then the frame may be reused
         * (read and/or written to if it is writable) later by libavcodec.
         *
         * avcodec_align_dimensions2() should be used to find the required width and
         * height, as they normally need to be rounded up to the next multiple of 16.
         *
         * Some decoders do not support linesizes changing between frames.
         *
         * If frame multithreading is used, this callback may be called from a
         * different thread, but not from more than one at once. Does not need to be
         * reentrant.
         *
         * @see avcodec_align_dimensions2()
         *
         * Audio:
         *
         * Decoders request a buffer of a particular size by setting
         * AVFrame.nb_samples prior to calling get_buffer2(). The decoder may,
         * however, utilize only part of the buffer by setting AVFrame.nb_samples
         * to a smaller value in the output frame.
         *
         * As a convenience, av_samples_get_buffer_size() and
         * av_samples_fill_arrays() in libavutil may be used by custom get_buffer2()
         * functions to find the required data size and to fill data pointers and
         * linesize. In AVFrame.linesize, only linesize[0] may be set for audio
         * since all planes must be the same size.
         *
         * @see av_samples_get_buffer_size(), av_samples_fill_arrays()
         *
         * - encoding: unused
         * - decoding: Set by libavcodec, user can override.
         */
        IntPtr get_buffer2;

        /* - encoding parameters */
        /**
         * number of bits the bitstream is allowed to diverge from the reference.
         *           the reference can be CBR (for CBR pass1) or VBR (for pass2)
         * - encoding: Set by user; unused for constant quantizer encoding.
         * - decoding: unused
         */
        int bit_rate_tolerance;

        /**
         * Global quality for codecs which cannot change it per frame.
         * This should be proportional to MPEG-1/2/4 qscale.
         * - encoding: Set by user.
         * - decoding: unused
         */
        int global_quality;

        /**
         * - encoding: Set by user.
         * - decoding: unused
         */
        int compression_level; // #define FF_COMPRESSION_DEFAULT -1

        AVRational qcompress;  ///< amount of qscale change between easy & hard scenes (0.0-1.0)
        AVRational qblur;      ///< amount of qscale smoothing over time (0.0-1.0)

        /**
         * minimum quantizer
         * - encoding: Set by user.
         * - decoding: unused
         */
        int qmin;

        /**
         * maximum quantizer
         * - encoding: Set by user.
         * - decoding: unused
         */
        int qmax;

        /**
         * maximum quantizer difference between frames
         * - encoding: Set by user.
         * - decoding: unused
         */
        int max_qdiff;

        /**
         * decoder bitstream buffer size
         * - encoding: Set by user.
         * - decoding: May be set by libavcodec.
         */
        int rc_buffer_size;

        /**
         * ratecontrol override, see RcOverride
         * - encoding: Allocated/set/freed by user.
         * - decoding: unused
         */
        int rc_override_count;
        IntPtr rc_override;

        /**
         * maximum bitrate
         * - encoding: Set by user.
         * - decoding: Set by user, may be overwritten by libavcodec.
         */
        Int64 rc_max_rate;

        /**
         * minimum bitrate
         * - encoding: Set by user.
         * - decoding: unused
         */
        Int64 rc_min_rate;

        /**
         * Ratecontrol attempt to use, at maximum, <value> of what can be used without an underflow.
         * - encoding: Set by user.
         * - decoding: unused.
         */
        AVRational rc_max_available_vbv_use;

        /**
         * Ratecontrol attempt to use, at least, <value> times the amount needed to prevent a vbv overflow.
         * - encoding: Set by user.
         * - decoding: unused.
         */
        AVRational rc_min_vbv_overflow_use;

        /**
         * Number of bits which should be loaded into the rc buffer before decoding starts.
         * - encoding: Set by user.
         * - decoding: unused
         */
        int rc_initial_buffer_occupancy;

        /**
         * trellis RD quantization
         * - encoding: Set by user.
         * - decoding: unused
         */
        int trellis;

        /**
         * pass1 encoding statistics output buffer
         * - encoding: Set by libavcodec.
         * - decoding: unused
         */
        IntPtr stats_out;

        /**
         * pass2 encoding statistics input buffer
         * Concatenated stuff from stats_out of pass1 should be placed here.
         * - encoding: Allocated/set/freed by user.
         * - decoding: unused
         */
        IntPtr stats_in;

        /**
         * Work around bugs in encoders which sometimes cannot be detected automatically.
         * - encoding: Set by user
         * - decoding: Set by user
         */
        AVCodecBug workaround_bugs;

        /**
         * strictly follow the standard (MPEG-4, ...).
         * - encoding: Set by user.
         * - decoding: Set by user.
         * Setting this to STRICT or higher means the encoder and decoder will
         * generally do stupid things, whereas setting it to unofficial or lower
         * will mean the encoder might produce output that is not supported by all
         * spec-compliant decoders. Decoders don't differentiate between normal,
         * unofficial and experimental (that is, they always try to decode things
         * when they can) unless they are explicitly asked to behave stupidly
         * (=strictly conform to the specs)
         * This may only be set to one of the FF_COMPLIANCE_* values in defs.h.
         */
        int strict_std_compliance;

        /**
         * error concealment flags
         * - encoding: unused
         * - decoding: Set by user.
         */
        AVCodecErrorConcealment error_concealment;

        /**
         * debug
         * - encoding: Set by user.
         * - decoding: Set by user.
         */
        AVCodecDebug debug;

        /**
         * Error recognition; may misdetect some more or less valid parts as errors.
         * This is a bitfield of the AV_EF_* values defined in defs.h.
         *
         * - encoding: Set by user.
         * - decoding: Set by user.
         */
        int err_recognition;

        /**
         * Hardware accelerator in use
         * - encoding: unused.
         * - decoding: Set by libavcodec
         */
        IntPtr hwaccel;

    /**
     * Legacy hardware accelerator context.
     *
     * For some hardware acceleration methods, the caller may use this field to
     * signal hwaccel-specific data to the codec. The struct pointed to by this
     * pointer is hwaccel-dependent and defined in the respective header. Please
     * refer to the FFmpeg HW accelerator documentation to know how to fill
     * this.
     *
     * In most cases this field is optional - the necessary information may also
     * be provided to libavcodec through @ref hw_frames_ctx or @ref
     * hw_device_ctx (see avcodec_get_hw_config()). However, in some cases it
     * may be the only method of signalling some (optional) information.
     *
     * The struct and its contents are owned by the caller.
     *
     * - encoding: May be set by the caller before avcodec_open2(). Must remain
     *             valid until avcodec_free_context().
     * - decoding: May be set by the caller in the get_format() callback.
     *             Must remain valid until the next get_format() call,
     *             or avcodec_free_context() (whichever comes first).
     */
    IntPtr hwaccel_context;

        /**
         * A reference to the AVHWFramesContext describing the input (for encoding)
         * or output (decoding) frames. The reference is set by the caller and
         * afterwards owned (and freed) by libavcodec - it should never be read by
         * the caller after being set.
         *
         * - decoding: This field should be set by the caller from the get_format()
         *             callback. The previous reference (if any) will always be
         *             unreffed by libavcodec before the get_format() call.
         *
         *             If the default get_buffer2() is used with a hwaccel pixel
         *             format, then this AVHWFramesContext will be used for
         *             allocating the frame buffers.
         *
         * - encoding: For hardware encoders configured to use a hwaccel pixel
         *             format, this field should be set by the caller to a reference
         *             to the AVHWFramesContext describing input frames.
         *             AVHWFramesContext.format must be equal to
         *             AVCodecContext.pix_fmt.
         *
         *             This field should be set before avcodec_open2() is called.
         */
        IntPtr hw_frames_ctx;

        /**
         * A reference to the AVHWDeviceContext describing the device which will
         * be used by a hardware encoder/decoder.  The reference is set by the
         * caller and afterwards owned (and freed) by libavcodec.
         *
         * This should be used if either the codec device does not require
         * hardware frames or any that are used are to be allocated internally by
         * libavcodec.  If the user wishes to supply any of the frames used as
         * encoder input or decoder output then hw_frames_ctx should be used
         * instead.  When hw_frames_ctx is set in get_format() for a decoder, this
         * field will be ignored while decoding the associated stream segment, but
         * may again be used on a following one after another get_format() call.
         *
         * For both encoders and decoders this field should be set before
         * avcodec_open2() is called and must not be written to thereafter.
         *
         * Note that some decoders may require this field to be set initially in
         * order to support hw_frames_ctx at all - in that case, all frames
         * contexts used must be created on the same device.
         */
        IntPtr hw_device_ctx;

        /**
         * Bit set of AV_HWACCEL_FLAG_* flags, which affect hardware accelerated
         * decoding (if active).
         * - encoding: unused
         * - decoding: Set by user (either before avcodec_open2(), or in the
         *             AVCodecContext.get_format callback)
         */
        int hwaccel_flags;

        /**
         * Video decoding only.  Sets the number of extra hardware frames which
         * the decoder will allocate for use by the caller.  This must be set
         * before avcodec_open2() is called.
         *
         * Some hardware decoders require all frames that they will use for
         * output to be defined in advance before decoding starts.  For such
         * decoders, the hardware frame pool must therefore be of a fixed size.
         * The extra frames set here are on top of any number that the decoder
         * needs internally in order to operate normally (for example, frames
         * used as reference pictures).
         */
        int extra_hw_frames;

        /**
         * error
         * - encoding: Set by libavcodec if flags & AV_CODEC_FLAG_PSNR.
         * - decoding: unused
         */
        IntPtr error;

        /**
         * DCT algorithm, see FF_DCT_* below
         * - encoding: Set by user.
         * - decoding: unused
         */
        int dct_algo;

        /**
         * IDCT algorithm, see FF_IDCT_* below.
         * - encoding: Set by user.
         * - decoding: Set by user.
         */
        AVCodecIDCTAlgorithm idct_algo;

        /**
         * bits per sample/pixel from the demuxer (needed for huffyuv).
         * - encoding: Set by libavcodec.
         * - decoding: Set by user.
         */
        int bits_per_coded_sample;

        /**
         * Bits per sample/pixel of internal libavcodec pixel/sample format.
         * - encoding: set by user.
         * - decoding: set by libavcodec.
         */
        int bits_per_raw_sample;

        /**
         * thread count
         * is used to decide how many independent tasks should be passed to execute()
         * - encoding: Set by user.
         * - decoding: Set by user.
         */
        int thread_count;

        /**
         * Which multithreading methods to use.
         * Use of FF_THREAD_FRAME will increase decoding delay by one frame per thread,
         * so clients which cannot provide future frames should not use it.
         *
         * - encoding: Set by user, otherwise the default is used.
         * - decoding: Set by user, otherwise the default is used.
         */
        int thread_type;
        // #define FF_THREAD_FRAME   1 ///< Decode more than one frame at once
        // #define FF_THREAD_SLICE   2 ///< Decode more than one part of a single frame at once

        /**
         * Which multithreading methods are in use by the codec.
         * - encoding: Set by libavcodec.
         * - decoding: Set by libavcodec.
         */
        int active_thread_type;

        /**
         * The codec may call this to execute several independent things.
         * It will return only after finishing all tasks.
         * The user may replace this with some multithreaded implementation,
         * the default implementation will execute the parts serially.
         * @param count the number of things to execute
         * - encoding: Set by libavcodec, user can override.
         * - decoding: Set by libavcodec, user can override.
         */
        IntPtr execute;

        /**
         * The codec may call this to execute several independent things.
         * It will return only after finishing all tasks.
         * The user may replace this with some multithreaded implementation,
         * the default implementation will execute the parts serially.
         * @param c context passed also to func
         * @param count the number of things to execute
         * @param arg2 argument passed unchanged to func
         * @param ret return values of executed functions, must have space for "count" values. May be NULL.
         * @param func function that will be called count times, with jobnr from 0 to count-1.
         *             threadnr will be in the range 0 to c->thread_count-1 < MAX_THREADS and so that no
         *             two instances of func executing at the same time will have the same threadnr.
         * @return always 0 currently, but code should handle a future improvement where when any call to func
         *         returns < 0 no further calls to func may be done and < 0 is returned.
         * - encoding: Set by libavcodec, user can override.
         * - decoding: Set by libavcodec, user can override.
         */
        IntPtr execute2;

        /**
         * profile
         * - encoding: Set by user.
         * - decoding: Set by libavcodec.
         * See the AV_PROFILE_* defines in defs.h.
         */
        int profile;

        /**
         * Encoding level descriptor.
         * - encoding: Set by user, corresponds to a specific level defined by the
         *   codec, usually corresponding to the profile level, if not specified it
         *   is set to AV_LEVEL_UNKNOWN.
         * - decoding: Set by libavcodec.
         * See AV_LEVEL_* in defs.h.
         */
        int level;

#if FF_API_CODEC_PROPS
    /**
     * Properties of the stream that gets decoded
     * - encoding: unused
     * - decoding: set by libavcodec
     */
    attribute_deprecated
    unsigned properties;
// #define FF_CODEC_PROPERTY_LOSSLESS        0x00000001
// #define FF_CODEC_PROPERTY_CLOSED_CAPTIONS 0x00000002
// #define FF_CODEC_PROPERTY_FILM_GRAIN      0x00000004
#endif

        /**
         * Skip loop filtering for selected frames.
         * - encoding: unused
         * - decoding: Set by user.
         */
        AVDiscard skip_loop_filter;

    /**
     * Skip IDCT/dequantization for selected frames.
     * - encoding: unused
     * - decoding: Set by user.
     */
    AVDiscard skip_idct;

    /**
     * Skip decoding for selected frames.
     * - encoding: unused
     * - decoding: Set by user.
     */
    AVDiscard skip_frame;

    /**
     * Skip processing alpha if supported by codec.
     * Note that if the format uses pre-multiplied alpha (common with VP6,
     * and recommended due to better video quality/compression)
     * the image will look as if alpha-blended onto a black background.
     * However for formats that do not use pre-multiplied alpha
     * there might be serious artefacts (though e.g. libswscale currently
     * assumes pre-multiplied alpha anyway).
     *
     * - decoding: set by user
     * - encoding: unused
     */
    int skip_alpha;

        /**
         * Number of macroblock rows at the top which are skipped.
         * - encoding: unused
         * - decoding: Set by user.
         */
        int skip_top;

        /**
         * Number of macroblock rows at the bottom which are skipped.
         * - encoding: unused
         * - decoding: Set by user.
         */
        int skip_bottom;

        /**
         * low resolution decoding, 1-> 1/2 size, 2->1/4 size
         * - encoding: unused
         * - decoding: Set by user.
         */
        int lowres;

        /**
         * AVCodecDescriptor
         * - encoding: unused.
         * - decoding: set by libavcodec.
         */
        IntPtr codec_descriptor;

        /**
         * Character encoding of the input subtitles file.
         * - decoding: set by user
         * - encoding: unused
         */
        IntPtr sub_charenc;

        /**
         * Subtitles character encoding mode. Formats or codecs might be adjusting
         * this setting (if they are doing the conversion themselves for instance).
         * - decoding: set by libavcodec
         * - encoding: unused
         */
        AVCodecSubtitleEncoding sub_charenc_mode;

        /**
         * Header containing style information for text subtitles.
         * For SUBTITLE_ASS subtitle type, it should contain the whole ASS
         * [Script Info] and [V4+ Styles] section, plus the [Events] line and
         * the Format line following. It shouldn't include any Dialogue line.
         *
         * - encoding: May be set by the caller before avcodec_open2() to an array
         *   allocated with the av_malloc() family of functions.
         * - decoding: May be set by libavcodec in avcodec_open2().
         *
         * After being set, the array is owned by the codec and freed in
         * avcodec_free_context().
         */
        int subtitle_header_size;
        IntPtr subtitle_header;

        /**
         * dump format separator.
         * can be ", " or "\n      " or anything else
         * - encoding: Set by user.
         * - decoding: Set by user.
         */
        [MarshalAs(UnmanagedType.LPStr)]
        public string dump_separator;

        /**
         * ',' separated list of allowed decoders.
         * If NULL then all are allowed
         * - encoding: unused
         * - decoding: set by user
         */
        [MarshalAs(UnmanagedType.LPStr)]
        public string codec_whitelist;

        /**
         * Additional data associated with the entire coded stream.
         *
         * - decoding: may be set by user before calling avcodec_open2().
         * - encoding: may be set by libavcodec after avcodec_open2().
         */
        IntPtr coded_side_data;
        int nb_coded_side_data;

        /**
         * Bit set of AV_CODEC_EXPORT_DATA_* flags, which affects the kind of
         * metadata exported in frame, packet, or coded stream side data by
         * decoders and encoders.
         *
         * - decoding: set by user
         * - encoding: set by user
         */
        int export_side_data;

        /**
         * The number of pixels per image to maximally accept.
         *
         * - decoding: set by user
         * - encoding: set by user
         */
        Int64 max_pixels;

        /**
         * Video decoding only. Certain video codecs support cropping, meaning that
         * only a sub-rectangle of the decoded frame is intended for display.  This
         * option controls how cropping is handled by libavcodec.
         *
         * When set to 1 (the default), libavcodec will apply cropping internally.
         * I.e. it will modify the output frame width/height fields and offset the
         * data pointers (only by as much as possible while preserving alignment, or
         * by the full amount if the AV_CODEC_FLAG_UNALIGNED flag is set) so that
         * the frames output by the decoder refer only to the cropped area. The
         * crop_* fields of the output frames will be zero.
         *
         * When set to 0, the width/height fields of the output frames will be set
         * to the coded dimensions and the crop_* fields will describe the cropping
         * rectangle. Applying the cropping is left to the caller.
         *
         * @warning When hardware acceleration with opaque output frames is used,
         * libavcodec is unable to apply cropping from the top/left border.
         *
         * @note when this option is set to zero, the width/height fields of the
         * AVCodecContext and output AVFrames have different meanings. The codec
         * context fields store display dimensions (with the coded dimensions in
         * coded_width/height), while the frame fields store the coded dimensions
         * (with the display dimensions being determined by the crop_* fields).
         */
        int apply_cropping;

        /**
         * The percentage of damaged samples to discard a frame.
         *
         * - decoding: set by user
         * - encoding: unused
         */
        int discard_damaged_percentage;

        /**
         * The number of samples per frame to maximally accept.
         *
         * - decoding: set by user
         * - encoding: set by user
         */
        Int64 max_samples;

        /**
         * This callback is called at the beginning of each packet to get a data
         * buffer for it.
         *
         * The following field will be set in the packet before this callback is
         * called:
         * - size
         * This callback must use the above value to calculate the required buffer size,
         * which must padded by at least AV_INPUT_BUFFER_PADDING_SIZE bytes.
         *
         * In some specific cases, the encoder may not use the entire buffer allocated by this
         * callback. This will be reflected in the size value in the packet once returned by
         * avcodec_receive_packet().
         *
         * This callback must fill the following fields in the packet:
         * - data: alignment requirements for AVPacket apply, if any. Some architectures and
         *   encoders may benefit from having aligned data.
         * - buf: must contain a pointer to an AVBufferRef structure. The packet's
         *   data pointer must be contained in it. See: av_buffer_create(), av_buffer_alloc(),
         *   and av_buffer_ref().
         *
         * If AV_CODEC_CAP_DR1 is not set then get_encode_buffer() must call
         * avcodec_default_get_encode_buffer() instead of providing a buffer allocated by
         * some other means.
         *
         * The flags field may contain a combination of AV_GET_ENCODE_BUFFER_FLAG_ flags.
         * They may be used for example to hint what use the buffer may get after being
         * created.
         * Implementations of this callback may ignore flags they don't understand.
         * If AV_GET_ENCODE_BUFFER_FLAG_REF is set in flags then the packet may be reused
         * (read and/or written to if it is writable) later by libavcodec.
         *
         * This callback must be thread-safe, as when frame threading is used, it may
         * be called from multiple threads simultaneously.
         *
         * @see avcodec_default_get_encode_buffer()
         *
         * - encoding: Set by libavcodec, user can override.
         * - decoding: unused
         */
        IntPtr get_encode_buffer;

        /**
         * Frame counter, set by libavcodec.
         *
         * - decoding: total number of frames returned from the decoder so far.
         * - encoding: total number of frames passed to the encoder so far.
         *
         *   @note the counter is not incremented if encoding/decoding resulted in
         *   an error.
         */
        Int64 frame_num;

        /**
         * Decoding only. May be set by the caller before avcodec_open2() to an
         * av_malloc()'ed array (or via AVOptions). Owned and freed by the decoder
         * afterwards.
         *
         * Side data attached to decoded frames may come from several sources:
         * 1. coded_side_data, which the decoder will for certain types translate
         *    from packet-type to frame-type and attach to frames;
         * 2. side data attached to an AVPacket sent for decoding (same
         *    considerations as above);
         * 3. extracted from the coded bytestream.
         * The first two cases are supplied by the caller and typically come from a
         * container.
         *
         * This array configures decoder behaviour in cases when side data of the
         * same type is present both in the coded bytestream and in the
         * user-supplied side data (items 1. and 2. above). In all cases, at most
         * one instance of each side data type will be attached to output frames. By
         * default it will be the bytestream side data. Adding an
         * AVPacketSideDataType value to this array will flip the preference for
         * this type, thus making the decoder prefer user-supplied side data over
         * bytestream. In case side data of the same type is present both in
         * coded_data and attacked to a packet, the packet instance always has
         * priority.
         *
         * The array may also contain a single -1, in which case the preference is
         * switched for all side data types.
         */
        IntPtr side_data_prefer_packet;
        /**
         * Number of entries in side_data_prefer_packet.
         */
        uint nb_side_data_prefer_packet;

        /**
         * Array containing static side data, such as HDR10 CLL / MDCV structures.
         * Side data entries should be allocated by usage of helpers defined in
         * libavutil/frame.h.
         *
         * - encoding: may be set by user before calling avcodec_open2() for
         *             encoder configuration. Afterwards owned and freed by the
         *             encoder.
         * - decoding: may be set by libavcodec in avcodec_open2().
         */
        IntPtr decoded_side_data;
        int nb_decoded_side_data;
    }

    #endregion
}
