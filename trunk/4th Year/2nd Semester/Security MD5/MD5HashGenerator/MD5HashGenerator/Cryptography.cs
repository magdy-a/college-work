namespace MD5HashGenerator
{

    /// <summary>
    /// Enumerator for the Cryptography Type
    /// </summary>
    public enum CryptographyType
    {
        /// <summary>
        /// Shifting every char with specific number
        /// </summary>
        CeaserCipher,
        /// <summary>
        /// Mapping every Char to another one
        /// </summary>
        MonoAlphabetic,
        /// <summary>
        /// 5x5 table
        /// </summary>
        PlayFair,
        /// <summary>
        /// Blocks of 512 bits
        /// </summary>
        MD5
    }

    /// <summary>
    /// Parent Class for all Cryptography Classes
    /// </summary>
    public abstract class Cryptography : ICryptography
    {
        protected string _pt;
        protected string _ct;
        public const int NUMENGLISHCHARACTERS = 26;
        public const string ENGLISHCHARACTERS = "abcdefghijklmnopqrstuvwxyz";

        public Cryptography()
        {
            this._pt = this._ct = string.Empty;
        }

        public abstract int GetID();

        public abstract CryptographyType GetCryptographyType();

        public string PlainText
        {
            get { return this._pt; }
            set { this._pt = value; }
        }

        public string CipherText
        {
            get { return this._ct; }
            set { this._ct = value; }
        }

        public abstract void Encrypt();

        public abstract void Decrypt();
    }
}
