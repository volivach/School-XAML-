using System.Threading.Tasks;

namespace StudentsGroup_XAML_.Authentification
{
    interface IEncryptionProvider
    {
        Task<string> Decrypt(string s);
        Task<string> Encrypt(string plainText);
    }
}