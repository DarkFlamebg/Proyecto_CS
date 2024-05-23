using System.Security.Cryptography;
using System.Text;

namespace ModuloSeguridad
{
    public class Encriptador
    {
        private static readonly string key = "9YuGuMhDJHMva6qe";

        public string Encriptar(string textoPlano)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(key);
                aesAlg.IV = new byte[aesAlg.BlockSize / 8]; // Utiliza un vector de inicialización (IV) seguro

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {

                            if (textoPlano != null)
                            {
                                swEncrypt.Write(textoPlano);
                            }
                            else
                            {
                                return null;
                            }

                        }
                    }

                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }
        public string Desencriptar(string textoCifrado)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(key);
                aesAlg.IV = new byte[aesAlg.BlockSize / 8];

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                if (textoCifrado != null)
                {
                    using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(textoCifrado)))
                    {
                        using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                            {
                                return srDecrypt.ReadToEnd();
                            }
                        }
                    }
                }
                else
                {
                    return null;
                }
            }
        }

    }
}
