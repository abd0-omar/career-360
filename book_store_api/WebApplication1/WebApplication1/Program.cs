using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using WebApplication1.MapperConfigs;
using WebApplication1.Models;
using WebApplication1.UnitOfWorks;

namespace WebApplication1;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddDbContext<BookStoreContext>(
            op => op.UseLazyLoadingProxies().UseSqlServer(
                builder.Configuration.GetConnectionString("BookCon")
            )
        );
        
        builder.Services.AddSwaggerGen(option =>
        {
            option.SwaggerDoc("v1", new OpenApiInfo()
            {
                Title = "Virtual Book Store",
                Version = "v1",
                Description = "Book Store API",
                TermsOfService = new Uri("https://example.org/"),
                Contact = new OpenApiContact()
                {
                    Email = "abdelrahman.omar.elgendy@gmail.com",
                    Name = "Abdelrahman Omar"
                }
            });

            option.EnableAnnotations();
        });
        
        builder.Services.AddIdentity<IdentityUser, IdentityRole>()
            .AddEntityFrameworkStores<BookStoreContext>();
        builder.Services.AddScoped<UnitOfWork>();
        // not using it
        builder.Services.AddAutoMapper(typeof(MapperConfig));
        
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateLifetime = true,
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey =
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes("welcome to my very secret key very secret key very secret"))
                };
            });
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthentication(); 
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
