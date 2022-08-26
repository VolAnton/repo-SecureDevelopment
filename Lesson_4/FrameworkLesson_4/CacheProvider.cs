using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace FrameworkLesson_4
{
    public class CacheProvider
    {
        static byte[] _additionalEntropy = { 3, 2, 1, 6, 7 };

        public void CacheConnections(List<ConnectionString> connections)
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<ConnectionString>));

                MemoryStream memoryStream = new MemoryStream();

                XmlWriter xmlWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);

                xmlSerializer.Serialize(xmlWriter, connections);

                byte[] protectedData = Protect((memoryStream.ToArray()));

                File.WriteAllBytes($"{AppDomain.CurrentDomain.BaseDirectory}data.protected", protectedData);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Serialize data error.\n{e.Message}");
            }
        }

        public List<ConnectionString> GetConnectionFromCache()
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<ConnectionString>));

                byte[] protectedData = File.ReadAllBytes($"{AppDomain.CurrentDomain.BaseDirectory}data.protected");

                byte[] data = Unprotect(protectedData);

                return (List<ConnectionString>)xmlSerializer.Deserialize(new MemoryStream(data));
            }
            catch (Exception e)
            {
                Console.WriteLine($"Deserialize data error");
                return null;
            }
        }

        private byte[] Protect(byte[] data)
        {
            try
            {
                return ProtectedData.Protect(data, _additionalEntropy, DataProtectionScope.LocalMachine);
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("Protected error");
                return null;
            }
        }

        private byte[] Unprotect(byte[] data)
        {
            try
            {
                return ProtectedData.Unprotect(data, _additionalEntropy, DataProtectionScope.LocalMachine);
            }
            catch (CryptographicException e)
            {
                Console.WriteLine($"Unprotected error.\n{e.Message}");
                return null;
            }
        }

    }
}
