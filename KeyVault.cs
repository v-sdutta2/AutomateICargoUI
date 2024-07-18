using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace iCargoUIAutomation
{
    public class KeyVault
    {
        private readonly string _keyVaultUri;
        private readonly string _clientId;
        private readonly string _clientSecret;
        private readonly string _tenantId;
        private readonly string _cccUsernameSecretName;
        private readonly string _cccPasswordSecretName;
        private readonly string _cgodgUsernameSecretName;
        private readonly string _cgodgPasswordSecretName;

        public KeyVault()
        {
            var configuration = LoadConfiguration();
            _keyVaultUri = configuration["KeyVaultUri"];
            _clientId = configuration["ClientId"];
            _clientSecret = configuration["ClientSecret"];
            _tenantId = configuration["TenantId"];
            _cccUsernameSecretName = configuration["CCCSecretUsername"];
            _cccPasswordSecretName = configuration["CCCSecretPassword"];
            _cgodgUsernameSecretName = configuration["CGODGSecretUsername"];
            _cgodgPasswordSecretName = configuration["CGODGSecretPassword"];
        }

        private IConfiguration LoadConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            return builder.Build();
        }

        public Dictionary<string, string> GetSecrets()
        {
            //var client = new SecretClient(new Uri(_keyVaultUri), new ClientSecretCredential(_tenantId, _clientId, _clientSecret));
            //var client = new SecretClient(new Uri(_keyVaultUri), new DefaultAzureCredential());
            var client = new SecretClient(new Uri(_keyVaultUri), new ManagedIdentityCredential());

            var secrets = new Dictionary<string, string>();

            KeyVaultSecret cccUsername = client.GetSecret(_cccUsernameSecretName);
            secrets.Add("CCC_Username", cccUsername.Value);

            KeyVaultSecret cccPassword = client.GetSecret(_cccPasswordSecretName);
            secrets.Add("CCC_Password", cccPassword.Value);

            KeyVaultSecret cgodgUsername = client.GetSecret(_cgodgUsernameSecretName);
            secrets.Add("CGODG_Username", cgodgUsername.Value);

            KeyVaultSecret cgodgPassword = client.GetSecret(_cgodgPasswordSecretName);
            secrets.Add("CGODG_Password", cgodgPassword.Value);

            return secrets;
        }
    }
}
