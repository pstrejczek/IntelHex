using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;

namespace IntelHex
{
    public class IntelHexConverter
    {
        private readonly Bitmap _image;
        private int _bytesInRow;

        public IntelHexConverter(string sourceFileName)
        {
            _image = new Bitmap(sourceFileName, true);
        }

        public List<string> ConverToIntelHex()
        {
            var result = new List<string> { GenerateHeader() + "\r" };

            var imageBytes = ImageToByteArray();

            var arrayPos = 0;
            var address = 10;

            while (arrayPos < imageBytes.Length)
            {
                if (_bytesInRow > 32)
                {
                    var line1 = string.Empty;
                    var line2 = string.Empty;

                    var adr1 = address.ToString("X");
                    var adr2 = (address + 32).ToString("X");

                    if (adr1.Length < 4)
                    {
                        var a1Diff = 4 - adr1.Length;
                        for (var i = 0; i < a1Diff - 1; i++) adr1 = "0" + adr1;
                    }

                    if (adr2.Length < 4)
                    {
                        var a2Diff = 4 - adr2.Length;
                        for (var i = 0; i < a2Diff - 1; i++) adr2 = "0" + adr1;
                    }

                    line1 += 32.ToString("X");
                    line2 += (_bytesInRow - 32).ToString("X");
                    line1 += adr1 + "00";
                    line2 += adr2 + "00";

                    var slicedArray1 = imageBytes.Skip(arrayPos).Take(32).ToList();
                    var slicedArray2 = imageBytes.Skip(arrayPos + 32).Take(_bytesInRow - 32).ToList();

                    foreach (var b in slicedArray1)
                    {
                        if (b.ToString("X").Length > 1)
                        {
                            line1 += b.ToString("X");
                        }
                        else
                        {
                            line1 += "0" + b.ToString("X");
                        }
                    }

                    if (slicedArray1.Count() < 32)
                    {
                        var diff = 32 - slicedArray1.Count();
                        for (var i = 0; i < diff - 1; i++) line1 += "00";
                    }

                    foreach (var b in slicedArray2)
                    {
                        if (b.ToString("X").Length > 1)
                        {
                            line1 += b.ToString("X");
                        }
                        else
                        {
                            line1 += "0" + b.ToString("X");
                        }
                    }

                    if (slicedArray2.Count() < 32)
                    {
                        var diff = 32 - slicedArray2.Count();
                        for (var i = 0; i < diff - 1; i++) line1 += "00";
                    }


                    line1 += CalculateChecksum(HexToByteArray(line1));
                    line2 += CalculateChecksum(HexToByteArray(line2));
                    line1 = ":" + line1;
                    line2 = ":" + line2;

                    result.Add(line1 + "\r");
                    result.Add(line2 + "\r");
                }
                else
                {
                    var line = string.Empty;

                    var addr = RotateBytes((short)address).ToString("X");
                    if (addr.Length < 4) addr = "0" + addr;

                    line += _bytesInRow.ToString("X");
                    line += addr + "00";

                    var slicedArray = imageBytes.Skip(arrayPos).Take(_bytesInRow);

                    foreach (byte b in slicedArray)
                    {
                        line += b.ToString("X");
                    }

                    line += CalculateChecksum(HexToByteArray(line));
                    line = ":" + line;

                    result.Add(line + "\r");
                }

                arrayPos += _bytesInRow;
                address += _bytesInRow;
            }

            result.Add(GenerateFooter() + "\r");

            return result;
        }

        private short RotateBytes(short sourceval)
        {
            var bytes = BitConverter.GetBytes(sourceval);

            var help = bytes[1];
            bytes[1] = bytes[0];
            bytes[0] = help;

            return BitConverter.ToInt16(bytes, 0);
        }

        private string GenerateHeader()
        {
            var headerString = "0A0000000A00";

            var imageHeight = RotateBytes((Int16)_image.Height).ToString("X");
            var imageWidth = RotateBytes((Int16)_image.Width).ToString("X");

            if (imageHeight.Length < 4)
            {
                var diff = 4 - imageHeight.Length;
                for (var i = 0; i < diff; i++) imageHeight = "0" + imageHeight;
            }


            headerString += imageHeight;
            headerString += imageWidth;

            _bytesInRow = (Int16)Math.Ceiling((double)(_image.Width / 8));

            var bytesInRowHex = RotateBytes((short)_bytesInRow).ToString("X");

            if (bytesInRowHex.Length < 4) bytesInRowHex = "0" + imageHeight;

            headerString += "0000";
            headerString += bytesInRowHex;

            headerString += CalculateChecksum(HexToByteArray(headerString));

            headerString = ":" + headerString;

            return headerString;
        }

        private string GenerateFooter()
        {
            return ":00000001FF";
        }

        private byte[] HexToByteArray(string hex)
        {
            var numberChars = hex.Length;

            byte[] bytes = new byte[numberChars / 2];

            for (var i = 0; i < numberChars - 1; i = i + 2)
            {
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            }

            return bytes;
        }

        private string CalculateChecksum(byte[] bytes)
        {
            byte sum = 0;

            for (var i = 0; i < bytes.Length - 1; i++)
            {
                sum += bytes[i];
            }

            var sumBytes = BitConverter.GetBytes(sum);

            string checksum;

            if (sumBytes[0] > 0)
            {
                checksum = ((byte)(256 - sumBytes[0])).ToString("X");
            }
            else
            {
                checksum = "0";
            }

            if (checksum.Length < 2) checksum = "0" + checksum;

            return checksum;
        }


        private byte[] ImageToByteArray()
        {
            var bitmapData = _image.LockBits(new Rectangle(0, 0, _image.Width, _image.Height), ImageLockMode.ReadWrite, _image.PixelFormat);

            var length = Math.Abs(bitmapData.Stride) * bitmapData.Height;

            var bitmapBytes = new byte[length];

            Marshal.Copy(bitmapData.Scan0, bitmapBytes, 0, length);
            _image.UnlockBits(bitmapData);

            return bitmapBytes;
        }
    }
}
