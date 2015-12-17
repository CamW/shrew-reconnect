using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace com.waldron.shrewReconnect.Shrew
{
    internal static class ShrewConfiguration
    {
        private static string credsFileName;
        private static string propsFileName;
        private static string configFolderName;
        private const string CREDS_FILE = "connection.db";
        private const string PROPS_FILE = "properties.db";
        private const string CONFIG_FOLDER = "ShrewReconnect";

        static ShrewConfiguration()
        {
            configFolderName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                                CONFIG_FOLDER);
            credsFileName = Path.Combine(configFolderName, CREDS_FILE);
            propsFileName = Path.Combine(configFolderName, PROPS_FILE);
            if (!Directory.Exists(configFolderName))
            {
                Directory.CreateDirectory(configFolderName);
            }
        }

        internal static void SaveCredentials(ShrewCredentials credentials)
        {
            DeleteCredentials();
            string serializedCredentials = JsonConvert.SerializeObject(credentials);
            byte[] encryptedData = ProtectedData.Protect(
                Encoding.UTF8.GetBytes(serializedCredentials), null, DataProtectionScope.CurrentUser);
            File.WriteAllBytes(credsFileName, encryptedData);
        }

        internal static void SaveProperties(ShrewProperties properties)
        {
            DeleteProperties();
            string serializedProperties = JsonConvert.SerializeObject(properties);
            byte[] encryptedData = ProtectedData.Protect(
                Encoding.UTF8.GetBytes(serializedProperties), null, DataProtectionScope.CurrentUser);
            File.WriteAllBytes(propsFileName, encryptedData);
        }

        internal static ShrewCredentials LoadCredentials()
        {
            if (File.Exists(credsFileName))
            {
                try
                {
                    byte[] encryotedData = File.ReadAllBytes(credsFileName);
                    string serializedCredentials = Encoding.UTF8.GetString(
                        ProtectedData.Unprotect(
                        encryotedData, null, DataProtectionScope.CurrentUser));
                    ShrewCredentials credentials = JsonConvert.DeserializeObject<ShrewCredentials>(serializedCredentials);
                    return credentials;
                }
                catch (Exception)
                {
                    DeleteCredentials();
                    throw;
                }
            }
            else
            {
                return null;
            }
        }

        internal static ShrewProperties LoadProperties()
        {
            if (File.Exists(propsFileName))
            {
                try
                {
                    byte[] encryotedData = File.ReadAllBytes(propsFileName);
                    string serializedProperties = Encoding.UTF8.GetString(
                        ProtectedData.Unprotect(
                        encryotedData, null, DataProtectionScope.CurrentUser));
                    ShrewProperties properties = JsonConvert.DeserializeObject<ShrewProperties>(serializedProperties);
                    return properties;
                }
                catch (Exception)
                {
                    DeleteProperties();
                    throw;
                }
            }
            else
            {
                return null;
            }
        }

        internal static void DeleteCredentials()
        {
            if (File.Exists(credsFileName))
            {
                File.Delete(credsFileName);
            }
        }

        internal static void DeleteProperties()
        {
            if (File.Exists(propsFileName))
            {
                File.Delete(propsFileName);
            }
        }
    }
}
