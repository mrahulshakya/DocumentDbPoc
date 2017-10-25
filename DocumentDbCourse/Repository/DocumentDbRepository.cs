using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DocumentDbCourse.Repository
{
    public class DocumentDbRepository<T> : IDocumentDbRepository<T> where T : class
    {
        private readonly IRepositoryConfiguration config;
        private string CollectionId { get; }

        private Uri DocumentCollectionUri { get; }

        public DocumentDbRepository(string collectionId, IRepositoryConfiguration config)
        {
            CollectionId = collectionId;
            this.config = config;
            DocumentCollectionUri = UriFactory.CreateDocumentCollectionUri(config.DatabaseId, collectionId);
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

        async Task<IList<T>> IDocumentDbRepository<T>.GetAsync(Expression<Func<T, bool>> filter)
        {
            IDocumentQuery<T> query = config.DocDbClient.CreateDocumentQuery<T>(DocumentCollectionUri, CollectionId, new FeedOptions
            {
                MaxItemCount = -1,
                EnableCrossPartitionQuery = true
            })
            .Where(filter)
            .AsDocumentQuery();

            List<T> results = new List<T>();
            while (query.HasMoreResults)
            {
                results.AddRange(await query.ExecuteNextAsync<T>());
            }

            return results;
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
                await config.DocDbClient.ReadDocumentCollectionAsync(UriFactory.CreateDocumentCollectionUri(config.DatabaseId, collectionId));
            }
            catch (DocumentClientException e)
            {
                if (e.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    await config.DocDbClient.CreateDocumentCollectionAsync(UriFactory.CreateDatabaseUri(config.DatabaseId), new DocumentCollection { Id = collectionId });
                }
            }
        }
    }
}