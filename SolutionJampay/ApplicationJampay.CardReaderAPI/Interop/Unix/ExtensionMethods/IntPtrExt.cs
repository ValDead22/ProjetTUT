using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationJampay.CardReaderAPI.Interop.Unix.ExtensionMethods
{
    internal static class IntPtrExt
    {
        public static IntPtr Mask(this IntPtr value, long mask)
        {
            unchecked
            {
                var newValue = value.ToInt64() & mask;

                return new IntPtr(newValue);
            }
        }
    }
}
