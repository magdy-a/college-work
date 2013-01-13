namespace SecurityLibrary
{
    /// <summary>
    /// CeaserCipher Algortithm is about shifting every character by number from 1 to 25 character ahead
    /// </summary>
    public class CeaserCipher : Cryptography
    {
        protected int _key;

        public CeaserCipher()
        {
            this._key = 0;
        }

        public int Key
        {
            get { return this._key; }
            set { this._key = value; }
        }

        public override int GetID()
        {
            return 2;
        }

        public override CryptographyType GetCryptographyType()
        {
            return CryptographyType.CeaserCipher;
        }

        public override void Encrypt()
        {
            this._pt = this._pt.ToLower();
            this._ct = string.Empty;

            foreach (char c in this._pt)
            {
                this._ct += HF.getChar((HF.GetIndex(c) + this._key) % NUMENGLISHCHARACTERS);
            }
        }

        public override void Decrypt()
        {
            int tmpIndex = 0;

            this._pt = string.Empty;
            this._ct = this._ct.ToLower();

            foreach (char c in this._ct)
            {
                tmpIndex = (HF.GetIndex(c) - this._key) % NUMENGLISHCHARACTERS;
                if (tmpIndex < 0)
                {
                    tmpIndex = NUMENGLISHCHARACTERS + tmpIndex;
                }
                this._pt += HF.getChar(tmpIndex);
            }
        }
    }
}