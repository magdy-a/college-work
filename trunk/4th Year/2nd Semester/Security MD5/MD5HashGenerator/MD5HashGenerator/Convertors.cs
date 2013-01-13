// -----------------------------------------------------------------------
// <copyright file="Convertors.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace MD5HashGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Convertors
    {
        public static string FromIntToHex(int hexValue)
        {
            return string.Format("{0:x}", hexValue);
        }

        public static string FromIntToHex(uint hexValue)
        {
            return string.Format("{0:x}", hexValue);
        }

        public static string FromHexToText(string hexstring)
        {
            StringBuilder text = new StringBuilder(hexstring.Length / 2);

            for (int i = 0; i < (hexstring.Length / 2); i++)
            {
                string word = hexstring.Substring(i * 2, 2);
                text.Append((char)Convert.ToInt32(word, 16));
            }

            return text.ToString();
        }

        public static string FromBinaryToText(string binarystring)
        {
            StringBuilder text = new StringBuilder(binarystring.Length / 8);

            for (int i = 0; i < (binarystring.Length / 8); i++)
            {
                string word = binarystring.Substring(i * 8, 8);
                text.Append((char)Convert.ToInt32(word, 2));
            }

            return text.ToString();
        }

        public static string FromTextToBinary(string text)
        {
            StringBuilder binarystring = new StringBuilder(text.Length * 8);

            foreach (char c in text)
            {
                int binary = (int)c;
                //int factor = 128;

                for (int i = 7; i >= 0; i--)
                    if ((binary & 1 << i) > 0)
                        binarystring.Append("1");
                    else
                        binarystring.Append("0");

                //for (int j = 0; j < 8; j++)
                //{
                //    if (Int32 >= factor)
                //    {
                //        Int32 -= factor;
                //        binarystring.Append("1");
                //    }
                //    else
                //    {
                //        binarystring.Append("0");
                //    }
                //    factor /= 2;
                //}
            }

            return binarystring.ToString();
        }

        public static int FromTextToInt32(string text)
        {
            if (text.Length != 32)
            {
                throw new Exception("Wrong integer format, must equal 32 bit");
            }

            List<byte> bytes = new List<byte>();

            foreach (char c in Convertors.FromBinaryToText(text))
            {
                bytes.Add((byte)c);
            }

            bytes.Reverse();

            return BitConverter.ToInt32(bytes.ToArray(), 0);
        }

        #region UintConvertors_JustForTesting

        public static string FromIntToBinary(uint value)
        {
            string binaryString = string.Empty;

            List<byte> bytes = new List<byte>(BitConverter.GetBytes(value));

            bytes.Reverse();

            bytes.ForEach(x => binaryString += Convertors.FromIntToBinary(x, 8));

            return binaryString;
        }

        public static string FromIntToBinary(uint num, int baseN)
        {
            if (num < 0)
            {
                Console.WriteLine("It requires a integer greater than 0.");
                return null;
            }

            string binarystring = "";
            double factor = Math.Pow(2, baseN - 1);

            for (int i = 0; i < baseN; i++)
            {
                if (num >= factor)
                {
                    num -= (uint)factor;
                    binarystring += "1";
                }
                else
                {
                    binarystring += "0";
                }
                factor /= 2;
            }

            return binarystring;
        }

        #endregion UintConvertors_JustForTesting

        public static string FromIntToBinary(int value)
        {
            string binaryString = string.Empty;

            List<byte> bytes = new List<byte>(BitConverter.GetBytes(value));

            bytes.Reverse();

            bytes.ForEach(x => binaryString += Convertors.FromIntToBinary(x, 8));

            return binaryString;
        }

        public static string FromIntToBinary(byte num, int baseN)
        {
            if (num < 0)
            {
                Console.WriteLine("It requires a integer greater than 0.");
                return null;
            }

            string binarystring = "";
            byte factor = (byte)Math.Pow(2, baseN - 1);

            for (int i = 0; i < baseN; i++)
            {
                if (num >= factor)
                {
                    num -= factor;
                    binarystring += "1";
                }
                else
                {
                    binarystring += "0";
                }
                factor /= 2;
            }

            return binarystring;
        }

        public static string FromIntToBinary(int num, int baseN)
        {
            if (num < 0)
            {
                Console.WriteLine("It requires a integer greater than 0.");
                return null;
            }

            string binarystring = "";
            double factor = Math.Pow(2, baseN - 1);

            for (int i = 0; i < baseN; i++)
            {
                if (num >= factor)
                {
                    num -= (int)factor;
                    binarystring += "1";
                }
                else
                {
                    binarystring += "0";
                }
                factor /= 2;
            }

            return binarystring;
        }

        public static byte FromBinaryToByte(string binary)
        {
            byte value = 0;
            int factor = 128;

            for (int i = 0; i < 8; i++)
            {
                if (binary[i] == '1')
                {
                    value += (byte)factor;
                }

                factor /= 2;
            }

            return value;
        }

        public static string FromHexToBinary(string hexstring)
        {
            string binarystring = "";

            try
            {
                for (int i = 0; i < hexstring.Length; i++)
                {
                    int hex = Convert.ToInt32(hexstring[i].ToString(), 16);

                    int factor = 8;

                    for (int j = 0; j < 4; j++)
                    {
                        if (hex >= factor)
                        {
                            hex -= factor;
                            binarystring += "1";
                        }
                        else
                        {
                            binarystring += "0";
                        }
                        factor /= 2;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + " - wrong hexa integer format.");
            }

            return binarystring;
        }

        public static string SetTextMutipleOf128Bits(string text)
        {
            if ((text.Length % 128) != 0)
            {
                int maxLength = 0;
                maxLength = ((text.Length / 128) + 1) * 128;

                text = text.PadRight(maxLength, '0');
            }

            return text;
        }

        public static uint ToLittleEndian(uint value)
        {
            List<byte> bytes = new List<byte>(BitConverter.GetBytes(value));

            bytes.Reverse();

            return (uint)BitConverter.ToInt32(bytes.ToArray(), 0);
        }

        public static string ToLittleEndian(string Int64Binary)
        {
            List<byte> myList = new List<byte>(8);

            for (int i = 0; i < 8; i++)
            {
                myList.Add(Convertors.FromBinaryToByte(Int64Binary.Substring(i * 8, 8)));
            }

            myList.Reverse();

            Int64Binary = string.Empty;

            for (int i = 0; i < 8; i++)
            {
                Int64Binary += Convertors.FromIntToBinary(myList[i], 8);
            }

            //return string.Format("{0:x}", BitConverter.ToInt64(myList.ToArray(), 0));
            return Int64Binary;
        }
    }
}
