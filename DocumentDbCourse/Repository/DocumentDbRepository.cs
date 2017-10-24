using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Security;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DocumentDbCourse.Repository
{
    public class DocumentDbRepository<T> : IDocumentDbRepository<T> where T : class
    {      
        private string CollectionId { get;  }
        private Uri DatabaseUri  => RepositoryConfiguration.DatabaseUri;
      
        private Uri DocumentCollectionUri { get; }

        private IDocumentClient Client => RepositoryConfiguration.DocDbClient;
        private string DatabaseId => RepositoryConfiguration.DatabaseId;

        private SecureString AuthKey => RepositoryConfiguration.AuthKey;
     
        public DocumentDbRepository(string collectionId)
        {
            CollectionId = collectionId;
            DocumentCollectionUri = UriFactory.CreateDocumentCollectionUri(DatabaseId, collectionId);
            CreateCollectionIfNotExistAsync(collectionId).Wait();
        }

        
        Task IDocumentDbRepository<T>.AddAsync(T entity)
        {
            throw new NotImplementedException();
        }

        Task IDocumentDbRepository<T>.DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<IList<T>> IDocumentDbRepository<T>.GetAsync(Expression<Func<T, bool>> filter)
        {
            throw new NotImplementedException();
        }

        Task<T> IDocumentDbRepository<T>.GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task IDocumentDbRepository<T>.UpdateAsync(int id)
        {
            throw new NotImplementedException();
        }

        private async Task CreateCollectionIfNotExistAsync(string collectionId)
        {
            try
            {
                await Client.ReadDocumentCollectionAsync(UriFactory.CreateDocumentCollectionUri(DatabaseId, collectionId));
            }
            catch (DocumentClientException e)
            {
                if (e.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    await Client.CreateDocumentCollectionAsync(UriFactory.CreateDatabaseUri(DatabaseId), new DocumentCollection { Id = collectionId });
                }
            }
        }
    }
}