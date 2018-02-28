using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationJampay.CardReaderAPI.Interop.Windows
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    internal struct SCARD_READERSTATE
    {
        internal IntPtr pszReader;
        internal IntPtr pvUserData;
        internal int dwCurrentState;
        internal int dwEventState;
        internal int cbAtr;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = WinSCardAPI.MAX_ATR_SIZE, ArraySubType = UnmanagedType.U1)]
        internal byte[] rgbAtr;
    }
}
