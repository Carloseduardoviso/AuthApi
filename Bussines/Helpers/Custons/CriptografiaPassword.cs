using System.Text;

namespace Businnes.Helpers.Custons
{
    public class CriptografiaPassword
    {
       public static string Execute(string password){
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            var hash = Blake3.Hasher.Hash(passwordBytes);
            return hash.ToString();
        }
    }
}
