using ApplicationJampay.CardReaderAPI;
using ApplicationJampay.CardReaderAPI.ISO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationJampay.Model.Service.SmartCardReader
{
    internal static class SmartCardReaderService
    {
        /// <summary>
        /// Get data writing on the card
        /// </summary>
        /// <returns></returns>
        public static byte[] GetDataFromTheCard()
        {
            var contextFactory = ContextFactory.Instance;
            using (var context = contextFactory.Establish(SCardScope.System))
            {
                var readerNames = context.GetReaders();
                if (readerNames == null)
                {
                    return null;
                }

                var readerName = readerNames[0];
                if (readerName == null)
                {
                    return null;
                }

                // 'using' statement to make sure the reader will be disposed (disconnected) on exit
                using (var rfidReader = context.ConnectReader(readerName, SCardShareMode.Shared, SCardProtocol.Any))
                {
                    var apdu = new CommandApdu(IsoCase.Case2Short, rfidReader.Protocol)
                    {
                        CLA = 0xFF,
                        Instruction = InstructionCode.ReadBinary,
                        P1 = 0x00,
                        P2 = 0x09,
                        Le = 0x07 // We don't know the ID tag size
                    };

                    using (rfidReader.Transaction(SCardReaderDisposition.Leave))
                    {
                        var sendPci = SCardPCI.GetPci(rfidReader.Protocol);
                        var receivePci = new SCardPCI(); // IO returned protocol control information.

                        var receiveBuffer = new byte[256];
                        var command = apdu.ToArray();

                        var bytesReceived = rfidReader.Transmit(
                            sendPci, // Protocol Control Information (T0, T1 or Raw)
                            command, // command APDU
                            command.Length,
                            receivePci, // returning Protocol Control Information
                            receiveBuffer,
                            receiveBuffer.Length); // data buffer

                        var responseApdu = new ResponseApdu(receiveBuffer, bytesReceived, IsoCase.Case2Short, rfidReader.Protocol);
                        return responseApdu.GetData();
                    }
                    
                }
            }
        }

        public static void WriteDataInTheCard(byte data)
        {
            throw new NotImplementedException();
        }
    }
}

