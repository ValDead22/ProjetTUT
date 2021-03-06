﻿using ApplicationJampay.CardReaderAPI.ISO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationJampay.CardReaderAPI
{
    public abstract class Apdu
    {
        /// <summary>The currently used ISO case.</summary>
        public IsoCase Case { get; protected set; }

        /// <summary>The currently used protocol.</summary>
        public SCardProtocol Protocol { get; protected set; }

        /// <summary>Converts the APDU structure to a transmittable byte array.</summary>
        /// <returns>A byte array containing the APDU parameters and data in the correct order.</returns>
        public abstract byte[] ToArray();

        /// <summary>Indicates if the APDU is valid.</summary>
        /// <value><see langword="true" /> if the APDU is valid.</value>
        public abstract bool IsValid { get; }


        /// <summary>Converts the APDU structure to a transmittable byte array.</summary>
        /// <param name="apdu">The APDU.</param>
        /// <returns>The supplied APDU as byte array.</returns>
        public static explicit operator byte[] (Apdu apdu)
        {
            return apdu.ToArray();
        }
    }
}
