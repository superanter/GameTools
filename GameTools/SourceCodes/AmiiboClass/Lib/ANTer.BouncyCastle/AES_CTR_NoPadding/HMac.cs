using System;
using System.Security.Cryptography;

namespace ANTer.BouncyCastle.AES_CTR_NoPadding  //Crypto.Macs

{
    class HMac
    {
        private HMACSHA256 hmacSHA256;
        private byte[] hmacByte;
        private byte[] tempHmac;
        private bool IsFristUpdata;

        public HMac(Sha256Digest My_Sha256Digest)
        {
            hmacSHA256 = new HMACSHA256();
            hmacByte = new byte[540];
            tempHmac = new byte[1];
            IsFristUpdata = true;
        }

        public void Init(KeyParameter parameters)
        {
            hmacSHA256.Key = parameters.GetKey();
            IsFristUpdata = true;
        }

        public void BlockUpdate(byte[] input, int inOff, int len)
        {
            if (IsFristUpdata)
            {
                Array.Resize(ref tempHmac, len);
                Array.Copy(input, inOff, tempHmac,0, len);
                IsFristUpdata = false;
            }
            else
            {
                Array.Resize(ref tempHmac, tempHmac.Length + len);
                Array.Copy(input, inOff, tempHmac, tempHmac.Length - len, len);
            }
        }

        public void DoFinal(byte[] output, int outOff)
        {
            hmacByte = hmacSHA256.ComputeHash(tempHmac);
            Array.Copy(hmacByte, 0, output, outOff, hmacByte.Length);
        }

        public void Reset()
        {
            IsFristUpdata = true;
        }
    }
}
