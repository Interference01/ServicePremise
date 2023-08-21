using Microsoft.EntityFrameworkCore;
using ServicePremise.database;
using ServicePremise.middleware;
using ServicePremise.repositories;
using ServicePremise.repositories.ports;

namespace ServicePremise
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddDbContext<ServiceDbContext>(options => options.UseSqlServer(
                builder.Configuration.GetConnectionString("AZURE_SQL_Connection"))
            );

            builder.Services.AddScoped<IPremiseRepository, PremiseRepository>();
            builder.Services.AddScoped<ITypeEquipmentRepository, TypeEquipmentRepository>();
            builder.Services.AddScoped<IContractRepository, ContractRepository>();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider
                    .GetRequiredService<ServiceDbContext>();

                dbContext.Database.Migrate();
            }

            app.UseHttpsRedirection();

            app.UseMiddleware<ApiKeyMiddleware>();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}