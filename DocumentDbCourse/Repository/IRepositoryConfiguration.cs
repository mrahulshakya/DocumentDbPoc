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
    public interface IRepositoryConfiguration
    {
        string DatabaseId { get; }

        Uri DatabaseUri { get; }

        SecureString AuthKey { get; }
        IDocumentClient DocDbClient { get; }

        string EndPointUrl { get; }

        IList<string> CollectionIds { get; }

        string UserCollectionId { get; }

        string ProductCollectionId { get; }
    }
}