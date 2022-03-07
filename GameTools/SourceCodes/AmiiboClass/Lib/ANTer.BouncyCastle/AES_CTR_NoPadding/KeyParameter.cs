using System;

namespace ANTer.BouncyCastle.AES_CTR_NoPadding  //Crypto.Parameters
{
    public class KeyParameter : ICipherParameters
    {
        private readonly byte[] key;
        //0046
        public KeyParameter(byte[] key)
        {
            if (key == null)
                throw new ArgumentNullException("key");

            this.key = (byte[])key.Clone();
        }
        //0059
        public byte[] GetKey()
        {
            return (byte[])key.Clone();
        }
    }

}
