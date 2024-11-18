
using E_commerce.Models;
using E_commerce.Services;

namespace E_commerce
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

          

            builder.Services.Configure<ProductStoreDatabaseSetting>(
    builder.Configuration.GetSection("E_commerceDatabase"));

            builder.Services.Configure<CategoryStoreDatabaseSetting>(
   builder.Configuration.GetSection("E_commerceDatabase"));



            builder.Services.AddSingleton<ProductServices>();
            builder.Services.AddSingleton<CategoryServices>();


            // Add services to the container.

            builder.Services.AddControllers()
    .AddJsonOptions(
        options => options.JsonSerializerOptions.PropertyNamingPolicy = null);

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
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
