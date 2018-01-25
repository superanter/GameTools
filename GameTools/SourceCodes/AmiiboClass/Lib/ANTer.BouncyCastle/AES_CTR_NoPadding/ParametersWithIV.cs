using System;

namespace ANTer.BouncyCastle.AES_CTR_NoPadding  //Crypto.Parameters
{
    public class ParametersWithIV : ICipherParameters
    {
		private readonly ICipherParameters	parameters;
		private readonly byte[]				iv;
        //0047
        public ParametersWithIV(ICipherParameters parameters, byte[] iv) : this(parameters, iv, 0, iv.Length)
        {
        }
        //0048
        public ParametersWithIV(ICipherParameters parameters, byte[] iv, int ivOff, int ivLen)
        {
            // NOTE: 'parameters' may be null to imply key re-use
            if (iv == null)
                throw new ArgumentNullException("iv");

            this.parameters = parameters;
            this.iv = new byte[ivLen];
            Array.Copy(iv, ivOff, this.iv, 0, ivLen);
        }
        //0057
        public byte[] GetIV()
        {
			return (byte[]) iv.Clone();
        }

		public ICipherParameters Parameters
        {
            get { return parameters; }
        }
    }
}
