using DocumentDbCourse.Configuration;
using DocumentDbCourse.Extensions;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using System;
using System.Collections.Generic;
using System.Security;
using System.Threading.Tasks;

namespace DocumentDbCourse.Repository
{
    public class RepositoryConfiguration : IRepositoryConfiguration
    {
        const string DataBaseIdKey = "DatabaseId";
        const string CollectionIdsKey = "CollectionIds";
        const string AuthConfigKey = "AuthKey";
        const string EndPointUrlKey = "EndPointUrl";
        const string UserCollectionIdKey = "UserCollectionId";
        const string ProductCollectionIdKey = "ProductCollectionId";

        private readonly string databaseId;
        private readonly Uri databaseUri;
        private readonly SecureString authKey;
        private readonly IDocumentClient docDbClient;
        private readonly string endPointUrl;
        private readonly List<string> collectionIds;
        private readonly string userCollectionId;
        private readonly string productCollectionId;

        public string DatabaseId
        {
            get
            {
                return databaseId;
            }
        }

        public Uri DatabaseUri
        {
            get
            {
                return databaseUri;
            }
        }

        public SecureString AuthKey
        {
            get
            {
                return authKey;
            }
        }

        public IDocumentClient DocDbClient
        {
            get
            {
                return docDbClient;
            }
        }

        public string EndPointUrl
        {
            get
            {
                return endPointUrl;
            }
        }

        public IList<string> CollectionIds
        {
            get
            {
                return collectionIds;
            }
        }

        public string UserCollectionId
        {
            get
            {
                return userCollectionId;
            }
        }

        public string ProductCollectionId
        {
            get
            {
                return productCollectionId;
            }
        }

        private async Task CreateDatabaseIfNotExistsAsync()
        {
            try
            {
                await docDbClient.ReadDatabaseAsync(UriFactory.CreateDatabaseUri(databaseId));
            }
            catch (DocumentClientException e)
            {
                if (e.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    await docDbClient.CreateDatabaseAsync(new Database { Id = databaseId });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public RepositoryConfiguration(IConfigurationReader config)
        {
            try
            {
                databaseId = config.GetValue<string>(DataBaseIdKey);
                databaseUri = UriFactory.CreateDatabaseUri(databaseId);
                endPointUrl = config.GetValue<string>(EndPointUrlKey);
                authKey = config.GetValue<string>(AuthConfigKey).ToSecureString();

                docDbClient = new DocumentClient(new Uri(endPointUrl), authKey);
                userCollectionId = config.GetValue<string>(UserCollectionIdKey);
                productCollectionId = config.GetValue<string>(ProductCollectionIdKey);
                collectionIds = new List<string>
                {
                    userCollectionId , productCollectionId
                };

                CreateDatabaseIfNotExistsAsync().Wait();

            }
            catch (Exception)
            {
                // TODO : Handle exception.
                throw;
            }
        }

    }
}