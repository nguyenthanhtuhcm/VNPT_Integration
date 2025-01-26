using AutoMapper;
using IntegrationInvoice.Core.Domain.Content;
using IntegrationInvoice.Core.Repositories;
using IntegrationInvoice.Core.SeedWorks;
using IntegrationInvoice.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationInvoice.Data.SeedWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IntegrationInvoiceContext _context;
        public IPostRepository Posts { get; private set; }
        public UnitOfWork(IntegrationInvoiceContext context, IMapper mapper)
        {
            _context = context;
            Posts = new PostRepository(context, mapper);
        }
        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
