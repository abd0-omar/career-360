using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1;

public class Program
{
    public static void Main(string[] args)
    {
        var txt = "";
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddDbContext<KompanyContext>(op => op.UseLazyLoadingProxies()
            .UseSqlServer(builder.Configuration.GetConnectionString("kompany_con")));

        // reps
        builder.Services.AddScoped<UnitOfWork>();
        // builder.Services.AddScoped<GenericRepository<Employee>>();
        builder.Services.AddScoped<EmployeeRepository>();

        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1",
                new OpenApiInfo
                {
                    Title = "My API - V1",
                    Version = "v1",
                    Description = "A sample API to demo Swashbuckle",
                    TermsOfService = new Uri("https://example.org"),
                    Contact = new OpenApiContact
                    {
                        Name = "ABoood",
                        Email = "abdelrahman.omar.elgendy@gmail.com"
                    },
                }
            );
        });
        builder.Services.AddSwaggerGen(c => { c.EnableAnnotations(); });
        builder.Services.AddAutoMapper(typeof(MappingConfig.MappingConfig));

        builder.Services.AddCors(options =>
        {
            options.AddPolicy(txt,
                builder =>
                {
                    builder.AllowAnyOrigin();
                    builder.AllowAnyMethod();
                    builder.AllowAnyHeader();
                });
        });

        var app = builder.Build();
        app.UseCors(txt);

        // Configure the HTTP request pipeline.
        // if (app.Environment.IsDevelopment())
        // {
        app.UseSwagger();
        app.UseSwaggerUI();
        // }

        // builder.Services.AddEndpointsApiExplorer();
        //

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}