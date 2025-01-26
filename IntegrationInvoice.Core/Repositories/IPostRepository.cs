using IntegrationInvoice.Core.Domain.Content;
using IntegrationInvoice.Core.Models;
using IntegrationInvoice.Core.Models.Content;
using IntegrationInvoice.Core.SeedWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationInvoice.Core.Repositories
{
    public interface IPostRepository : IRepository<Post, Guid>
    {
        Task<List<Post>> GetPopularPostsAsync(int count);
        Task<PagedResult<PostInListDto>> GetPostsPagingAsync(string keyword, Guid? categoryId, int pageIndex = 1, int pageSize = 10);
    }
}
