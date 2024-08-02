
using Microsoft.EntityFrameworkCore;
using SignalRAPI.DAL;
using SignalRAPI.Hubs;
using SignalRAPI.Model;

namespace SignalRAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped<VisitorService>();

            builder.Services.AddSignalR();
            builder.Services.AddCors(opts => opts.AddPolicy("CorsPolicy",
                builder =>
                {
                    builder.AllowAnyHeader()
                    .AllowAnyMethod()
                    .SetIsOriginAllowed((host) => true)
                    .AllowCredentials();
                }));

            builder.Services.AddDbContext<Context>(opt => 
            opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.UseCors("CorsPolicy");
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();
            app.MapHub<VisitorHub>("/VisitorHub");

            app.Run();
        }
    }
}
