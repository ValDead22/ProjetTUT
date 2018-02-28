using System.ComponentModel;

namespace ApplicationJampay.CardReaderAPI.Enum
{
    public enum SCardScope
    {
        /// <summary>Scope in user space.</summary>
        [Description("Scope in user space")]
        User = 0x0000,

        /// <summary>Scope in terminal.</summary>
        [Description("Scope in terminal")]
        Terminal = 0x0001,

        /// <summary>Scope in system. Service on the local machine.</summary>
        [Description("Scope in system")]
        System = 0x0002,

        /** PC/SC Lite specific extensions */
        /// <summary>Scope is global. </summary>
        [Description("Scope is global")]
        Global = 0x0003
    }
}