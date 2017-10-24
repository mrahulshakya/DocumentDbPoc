using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Threading.Tasks;
using System.Web;

namespace DocumentDbCourse.Repository
{
    public class RepositoryConfiguration
    {
         internal static string DatabaseId { get {
            } }
         internal static Uri DatabaseUri { get; private set; }

        internal static SecureString AuthKey { get; private set; }

        internal static ConnectionPolicy Policy { get; private set; }

        internal static IDocumentClient DocDbClient { get; private set; }

        private static async Task CreateDatabaseIfNotExistsAsync()
        {
            try
            {
                await DocDbClient.ReadDatabaseAsync(UriFactory.CreateDatabaseUri(DatabaseId));
            }
            catch (DocumentClientException e)
            {
                if (e.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    await DocDbClient.CreateDatabaseAsync(new Database { Id = DatabaseId });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        public static void Initialize()
        {
            DocDbClient = new DocumentClient(UriFactory.CreateDatabaseUri(DatabaseId), AuthKey, Policy);
            DatabaseUri = UriFactory.CreateDatabaseUri(DatabaseId);
            CreateDatabaseIfNotExistsAsync().Wait();
        }

    }
}