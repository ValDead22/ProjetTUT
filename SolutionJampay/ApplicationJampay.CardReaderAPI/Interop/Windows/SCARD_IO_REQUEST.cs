using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationJampay.CardReaderAPI.Interop.Windows
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    internal class SCARD_IO_REQUEST
    {
        internal int dwProtocol;
        internal int cbPciLength;

        internal SCARD_IO_REQUEST()
        {
            dwProtocol = 0;
        }
    }
}
