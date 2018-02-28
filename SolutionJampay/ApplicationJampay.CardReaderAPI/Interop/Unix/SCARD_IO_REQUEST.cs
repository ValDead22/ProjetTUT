using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationJampay.CardReaderAPI.Interop.Unix
{
    [StructLayout(LayoutKind.Sequential)]
    internal class SCARD_IO_REQUEST
    {
        internal SCARD_IO_REQUEST()
        {
            dwProtocol = IntPtr.Zero;
        }

        internal IntPtr dwProtocol; // Protocol identifier
        internal IntPtr cbPciLength; // Protocol Control Inf Length
    }
}
