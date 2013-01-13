namespace MD5HashGenerator
{

    /// <summary>
    /// Cryptography Algorithm Interface
    /// </summary>
    public interface ICryptography
    {
        int GetID();

        void Encrypt();

        void Decrypt();
    }
}
