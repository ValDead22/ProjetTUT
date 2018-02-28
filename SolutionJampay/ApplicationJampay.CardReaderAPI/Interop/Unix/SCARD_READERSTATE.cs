using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationJampay.CardReaderAPI.Interop.Unix
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct SCARD_READERSTATE
    {
        internal IntPtr pszReader;
        internal IntPtr pvUserData;
        internal IntPtr dwCurrentState;
        internal IntPtr dwEventState;
        internal IntPtr cbAtr;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = PCSCliteAPI.MAX_ATR_SIZE)]
        internal byte[] rgbAtr;
    }
}
