namespace SecurityLibrary
{
    /// <summary>
    /// PlayFair Algorithm, it creates a 5x5 square that holdes all the chars of english alphabet
    /// </summary>
    public class PlayFair : Cryptography
    {
        private string _key;

        public PlayFair()
        {
            this._key = string.Empty;
        }

        public string Key
        {
            get { return _key; }
            set { _key = value; }
        }

        public override int GetID()
        {
            return 3;
        }

        public override CryptographyType GetCryptographyType()
        {
            return CryptographyType.PlayFair;
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
            this._key = this._key.ToLower();
        }
    }
}