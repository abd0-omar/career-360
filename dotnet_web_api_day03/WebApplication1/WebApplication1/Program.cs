using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

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
        // builder.Services.AddDbContext<>(// add db context from appsettings.json);
        // builder.configuration.getconnectionstring("connection string name in appsettings.json")
        // op => op مش فاكر الصراحة
        
        // add db context DI
        builder.Services.AddDbContext<CompanyContext>(op =>
            op.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("CompanyCon")));
        
        // to remove cycles, from serilazing objects 
        // مش احسن حل
        // download newton soft json
        // addcotrnoters().addnewtongreferenceloop(op=>)
        // in the models/student.cs class above property you could add [JsonIgnore] to decide not to serialize it
        // 
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull]
        // by default WhenWritingAlways
        //
        // but the best way is to use "DTO"
        
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