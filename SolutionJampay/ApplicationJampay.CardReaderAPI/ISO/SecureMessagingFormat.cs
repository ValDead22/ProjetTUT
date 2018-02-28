using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationJampay.CardReaderAPI.ISO
{
    public enum SecureMessagingFormat : byte
    {
        /// <summary>No secure messaging</summary>
        None = 0x0,

        /// <summary>Proprietary secure messaging format</summary>
        Proprietary = 0x4,

        /// <summary>Command header not authenticated</summary>
        CommandHeaderNotAuthenticated = 0x8,

        /// <summary>Command header authenticated</summary>
        CommandHeaderAuthenticated = 0xC
    }
}
