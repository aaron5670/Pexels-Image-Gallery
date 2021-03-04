using System;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

namespace PhotoLibraryApplication.helpers
{
    public class AzureVaultHelper
    {
        private readonly string _vaultUri;

        public AzureVaultHelper(string vaultUri)
        {
            _vaultUri = vaultUri;
        }

        /// <summary>
        /// Get Azure Vault secret value by secret name
        /// </summary>
        /// <param name="secretName"></param>
        /// <returns></returns>
        public async Task<string> GetSecretAzureVaultValue(string secretName)
        {
            var client = new SecretClient(new Uri(_vaultUri), new DefaultAzureCredential());

            var secret = await client.GetSecretAsync(secretName);
            return secret.Value.Value;
        }
    }
}