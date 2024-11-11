using Microsoft.EntityFrameworkCore;
using Seven_up.Services;
using SevenUp.Data;
using SevenUp.Interface;

namespace Seven_up
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            // Configure CORS to allow requests from the Next.js frontend
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowFrontend",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:3000") // Update this if you deploy to production
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                    });
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<drinkDb>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")
                    ?? throw new InvalidOperationException("Connection string not found"));
            });

            builder.Services.AddScoped<IProduct, ProductService>()
                            .AddScoped<ICategory, CategoryService>()
                            .AddScoped<IAdminProduct, AdminProductService>();

            var app = builder.Build();




            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            // Enable CORS
            app.UseCors("AllowFrontend");

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
