using System;
using System.Collections.Generic;

namespace lab04
{
    public class Encryption
    {
        public static string Encrypt(string[] input)
        {
            var result = "";

            foreach (var line in input)
            {
                foreach (var ch in line)
                {
                    var numOfelem = Convert.ToInt32(ch);
                    if (ch == '?')
                    {
                        numOfelem = Convert.ToInt32('a');
                    }
                    else
                    {
                        numOfelem++;
                    }

                    result += Convert.ToChar(numOfelem);
                }
            }

            return result;
        }

        public static byte[] Encrypt(byte[] input)
        {
            var result = new List<byte>();

            foreach (var byteItem in input)
            {
                var bt = byteItem;
                if (bt == 255)
                {
                    bt = 0;
                }
                else
                {
                    bt++;
                }

                result.Add(bt);
            }

            return result.ToArray();
        }

        public static string Decrypt(string[] input)
        {
            var result = "";

            foreach (var line in input)
            {
                foreach (var elem in line)
                {
                    var numOfElem = Convert.ToInt32(elem);
                    if (elem == 'a')
                    {
                        numOfElem = Convert.ToInt32('?');
                    }
                    else
                    {
                        numOfElem--;
                    }

                    result += Convert.ToChar(numOfElem);
                }
            }

            return result;
        }

        public static byte[] Decrypt(byte[] input)
        {
            var result = new List<byte>();

            foreach (var byteItem in input)
            {
                var bt = byteItem;
                if (bt == 0)
                {
                    bt = 255;
                }
                else
                {
                    bt--;
                }

                result.Add(bt);
            }

            return result.ToArray();
        }
    }
}