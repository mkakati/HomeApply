using HomeApply.ViewModel.ApiResponse;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Xml;

namespace HomeApply.Common.Cryptography
{
    public class SecurityManager
    {
        public static string Encryption(string strText)
        {
            using (var rsa = new RSACryptoServiceProvider(1024))
            {
                try
                {
                    string publicKeyXml = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot" + "/Keys/publicKey.xml");
                    FromXml(rsa, publicKeyXml);
                    var encryptedData = rsa.Encrypt(Encoding.UTF8.GetBytes(strText), true);
                    var base64Encrypted = Convert.ToBase64String(encryptedData);
                    return base64Encrypted;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    rsa.PersistKeyInCsp = false;
                }
            }
        }

        public static string Decryption(string strText)
        {
            string privateKeyXml = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot" + "/Keys/privateKey.xml");
            using (var rsa = new RSACryptoServiceProvider(1024))
            {
                try
                {
                    FromXml(rsa, privateKeyXml);
                    var resultBytes = Convert.FromBase64String(strText);
                    var decryptedBytes = rsa.Decrypt(resultBytes, true);
                    var decryptedData = Encoding.UTF8.GetString(decryptedBytes);
                    return decryptedData.ToString();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    rsa.PersistKeyInCsp = false;
                }
            }
        }

        private static void FromXml(RSA rsa, string xmlString)
        {
            RSAParameters parameters = new RSAParameters();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlString);

            if (xmlDoc.DocumentElement.Name.Equals(Constants.RsaKeyValue))
            {
                foreach (XmlNode node in xmlDoc.DocumentElement.ChildNodes)
                {
                    switch (node.Name)
                    {
                        case Constants.Modulus: parameters.Modulus = (string.IsNullOrEmpty(node.InnerText) ? null : Convert.FromBase64String(node.InnerText)); break;
                        case Constants.Exponent: parameters.Exponent = (string.IsNullOrEmpty(node.InnerText) ? null : Convert.FromBase64String(node.InnerText)); break;
                        case Constants.P: parameters.P = (string.IsNullOrEmpty(node.InnerText) ? null : Convert.FromBase64String(node.InnerText)); break;
                        case Constants.Q: parameters.Q = (string.IsNullOrEmpty(node.InnerText) ? null : Convert.FromBase64String(node.InnerText)); break;
                        case Constants.DP: parameters.DP = (string.IsNullOrEmpty(node.InnerText) ? null : Convert.FromBase64String(node.InnerText)); break;
                        case Constants.DQ: parameters.DQ = (string.IsNullOrEmpty(node.InnerText) ? null : Convert.FromBase64String(node.InnerText)); break;
                        case Constants.InverseQ: parameters.InverseQ = (string.IsNullOrEmpty(node.InnerText) ? null : Convert.FromBase64String(node.InnerText)); break;
                        case Constants.D: parameters.D = (string.IsNullOrEmpty(node.InnerText) ? null : Convert.FromBase64String(node.InnerText)); break;
                    }
                }
            }
            else
            {
                throw new Exception(Constants.InvalidXMLRSAkey);
            }

            rsa.ImportParameters(parameters);
        }
    }
}
