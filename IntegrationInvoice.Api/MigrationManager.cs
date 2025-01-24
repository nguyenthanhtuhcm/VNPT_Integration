using IntegrationInvoice.Data;
using Microsoft.EntityFrameworkCore;

namespace IntegrationInvoice.Api
{
    public static class MigrationManager
    {
        public static WebApplication MigrateDatabase(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                using (var context = scope.ServiceProvider.GetRequiredService<IntegrationInvoiceContext>())
                {
                    context.Database.Migrate();
                    new DataSeeder().SeedAsync(context).Wait();
                }
            }
            return app;
        }
    }

}
