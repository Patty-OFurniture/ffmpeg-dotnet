
#region Using Directives

using System;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;

#endregion

namespace FFmpegDotNet.Interop.Utilities
{
    enum AVChannelOrder
    {
        /**
         * Only the channel count is specified, without any further information
         * about the channel order.
         */
        AV_CHANNEL_ORDER_UNSPEC,
        /**
         * The native channel order, i.e. the channels are in the same order in
         * which they are defined in the AVChannel enum. This supports up to 63
         * different channels.
         */
        AV_CHANNEL_ORDER_NATIVE,
        /**
         * The channel order does not correspond to any other predefined order and
         * is stored as an explicit map. For example, this could be used to support
         * layouts with 64 or more channels, or with empty/skipped (AV_CHAN_UNUSED)
         * channels at arbitrary positions.
         */
        AV_CHANNEL_ORDER_CUSTOM,
        /**
         * The audio is represented as the decomposition of the sound field into
         * spherical harmonics. Each channel corresponds to a single expansion
         * component. Channels are ordered according to ACN (Ambisonic Channel
         * Number).
         *
         * The channel with the index n in the stream contains the spherical
         * harmonic of degree l and order m given by
         * @code{.unparsed}
         *   l   = floor(sqrt(n)),
         *   m   = n - l * (l + 1).
         * @endcode
         *
         * Conversely given a spherical harmonic of degree l and order m, the
         * corresponding channel index n is given by
         * @code{.unparsed}
         *   n = l * (l + 1) + m.
         * @endcode
         *
         * Normalization is assumed to be SN3D (Schmidt Semi-Normalization)
         * as defined in AmbiX format $ 2.1.
         */
        AV_CHANNEL_ORDER_AMBISONIC,
        /**
         * Number of channel orders, not part of ABI/API
         */
        FF_CHANNEL_ORDER_NB
    }
}
