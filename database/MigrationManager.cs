using Microsoft.EntityFrameworkCore;

namespace ServicePremise.database
{
    public static class MigrationManager
    {
        public static WebApplication MigrateDatabase(this WebApplication webApp)
        {
            using (var scope = webApp.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider
                    .GetRequiredService<ServiceDbContext>();

                dbContext.Database.Migrate();
            }

            return webApp;
        }
    }
}
