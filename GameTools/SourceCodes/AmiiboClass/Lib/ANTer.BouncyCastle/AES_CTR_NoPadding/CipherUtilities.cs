using System;
//using System.Collections;
using System.Globalization;

namespace ANTer.BouncyCastle.AES_CTR_NoPadding //Security
{
    /// <remarks>
    ///  Cipher Utility class contains methods that can not be specifically grouped into other classes.
    /// </remarks>
    public sealed class CipherUtilities
    {
        private CipherUtilities()
        {
        }

        public static BufferedCipherBase GetCipher(string algorithm)
        {
            if (algorithm == null)
                throw new ArgumentNullException("algorithm");

            string algorithmUpper = algorithm.ToUpper(CultureInfo.InvariantCulture);

            IBlockCipher blockCipher = null;

            if (algorithmUpper == "AES/CTR/NOPADDING")
            {

                blockCipher = new AesFastEngine();
                blockCipher = new SicBlockCipher(blockCipher);
                BufferedCipherBase BCBblockCipher = new BufferedBlockCipher(blockCipher);
                return BCBblockCipher;
            }
            throw new Exception("Cipher " + algorithm + " not recognised.");
        }
    }
}
