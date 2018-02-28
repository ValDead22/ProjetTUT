﻿using System.ComponentModel;

namespace ApplicationJampay.CardReaderAPI
{
    public enum SCardShareMode
    {
        /// <summary>This application will NOT allow others to share the reader. (SCARD_SHARE_EXCLUSIVE)</summary>
        [Description("Exclusive mode only")]
        Exclusive = 0x0001,

        /// <summary>This application will allow others to share the reader. (SCARD_SHARE_SHARED)</summary>
        [Description("Shared mode only")]
        Shared = 0x0002,

        /// <summary>Direct control of the reader, even without a card. (SCARD_SHARE_DIRECT)</summary>
        [Description("Raw mode only")]
        Direct = 0x0003
    }
}