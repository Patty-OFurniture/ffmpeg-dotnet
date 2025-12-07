
#region Using Directives

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace FFmpegDotNet.Interop.Utilities
{
    enum AVChannel
    {
        /// Invalid channel index
        AV_CHAN_NONE = -1,
        AV_CHAN_FRONT_LEFT,
        AV_CHAN_FRONT_RIGHT,
        AV_CHAN_FRONT_CENTER,
        AV_CHAN_LOW_FREQUENCY,
        AV_CHAN_BACK_LEFT,
        AV_CHAN_BACK_RIGHT,
        AV_CHAN_FRONT_LEFT_OF_CENTER,
        AV_CHAN_FRONT_RIGHT_OF_CENTER,
        AV_CHAN_BACK_CENTER,
        AV_CHAN_SIDE_LEFT,
        AV_CHAN_SIDE_RIGHT,
        AV_CHAN_TOP_CENTER,
        AV_CHAN_TOP_FRONT_LEFT,
        AV_CHAN_TOP_FRONT_CENTER,
        AV_CHAN_TOP_FRONT_RIGHT,
        AV_CHAN_TOP_BACK_LEFT,
        AV_CHAN_TOP_BACK_CENTER,
        AV_CHAN_TOP_BACK_RIGHT,
        /** Stereo downmix. */
        AV_CHAN_STEREO_LEFT = 29,
        /** See above. */
        AV_CHAN_STEREO_RIGHT,
        AV_CHAN_WIDE_LEFT,
        AV_CHAN_WIDE_RIGHT,
        AV_CHAN_SURROUND_DIRECT_LEFT,
        AV_CHAN_SURROUND_DIRECT_RIGHT,
        AV_CHAN_LOW_FREQUENCY_2,
        AV_CHAN_TOP_SIDE_LEFT,
        AV_CHAN_TOP_SIDE_RIGHT,
        AV_CHAN_BOTTOM_FRONT_CENTER,
        AV_CHAN_BOTTOM_FRONT_LEFT,
        AV_CHAN_BOTTOM_FRONT_RIGHT,
        AV_CHAN_SIDE_SURROUND_LEFT,     ///<  +90 degrees, Lss, SiL
        AV_CHAN_SIDE_SURROUND_RIGHT,    ///<  -90 degrees, Rss, SiR
        AV_CHAN_TOP_SURROUND_LEFT,      ///< +110 degrees, Lvs, TpLS
        AV_CHAN_TOP_SURROUND_RIGHT,     ///< -110 degrees, Rvs, TpRS

        AV_CHAN_BINAURAL_LEFT = 61,
        AV_CHAN_BINAURAL_RIGHT,

        /** Channel is empty can be safely skipped. */
        AV_CHAN_UNUSED = 0x200,

        /** Channel contains data, but its position is unknown. */
        AV_CHAN_UNKNOWN = 0x300,

        /**
         * Range of channels between AV_CHAN_AMBISONIC_BASE and
         * AV_CHAN_AMBISONIC_END represent Ambisonic components using the ACN system.
         *
         * Given a channel id `<i>` between AV_CHAN_AMBISONIC_BASE and
         * AV_CHAN_AMBISONIC_END (inclusive), the ACN index of the channel `<n>` is
         * `<n> = <i> - AV_CHAN_AMBISONIC_BASE`.
         *
         * @note these values are only used for AV_CHANNEL_ORDER_CUSTOM channel
         * orderings, the AV_CHANNEL_ORDER_AMBISONIC ordering orders the channels
         * implicitly by their position in the stream.
         */
        AV_CHAN_AMBISONIC_BASE = 0x400,
        // leave space for 1024 ids, which correspond to maximum order-32 harmonics,
        // which should be enough for the foreseeable use cases
        AV_CHAN_AMBISONIC_END = 0x7ff,
    }
}
