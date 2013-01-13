namespace SecurityLibrary
{
    /// <summary>
    /// MonoAlphabetic Algorithm, that matches every english char to another one
    /// </summary>
    public class MonoAlphabetic : Cryptography
    {
        private string _key;

        public MonoAlphabetic()
        {
            this._key = string.Empty;
        }

        public string Key
        {
            get { return this._key; }
            set { this._key = value; }
        }

        public override int GetID()
        {
            return 1;
        }

        public override CryptographyType GetCryptographyType()
        {
            return CryptographyType.MonoAlphabetic;
        }

        public override void Encrypt()
        {
            this._pt = this._pt.ToLower();
            this._ct = string.Empty;
            this._key = this._key.ToLower();
        }

        public override void Decrypt()
        {
            this._ct = this._ct.ToLower();
            this._pt = string.Empty;
            this._key = string.Empty;
        }
    }
}