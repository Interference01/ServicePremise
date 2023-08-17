using Microsoft.EntityFrameworkCore;
using ServicePremise.database;
using ServicePremise.repositories;
using ServicePremise.repositories.ports;

namespace ServicePremise
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<ServiceDbContext>(options => options.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddTransient<IPremiseRepository, PremiseRepository>();
            builder.Services.AddTransient<ITypeEquipmentRepository, TypeEquipmentRepository>();
            builder.Services.AddTransient<IContractRepository, ContractRepository>();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}