using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationInvoice.Data
{
    
    public class IntegrationInvoiceContextFactory : IDesignTimeDbContextFactory<IntegrationInvoiceContext>
    {
        public IntegrationInvoiceContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json")
                 .Build();
            var builder = new DbContextOptionsBuilder<IntegrationInvoiceContext>();
            builder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            return new IntegrationInvoiceContext(builder.Options);
        }
    }
}
