using System.Reflection;
using Microsoft.OpenApi.Models;
using Test.Services.Areas.Characters;
using Test.Services.Areas.Characters.Dto;
using TestApi.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAutoMapper(typeof(IEntityDto));

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Test API",
        Description = "An ASP.NET Core Web API",
        TermsOfService = new Uri("https://localhost:5000/terms"),
        Contact = new OpenApiContact()
        {
            Name = "Example contact",
            Url = new Uri("https://localhost:5000/contact")
        },
        License = new OpenApiLicense()
        {
            Name = "Example license",
            Url = new Uri("https://localhost:5000/license")
        }
    });

    var xmlFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFileName));
});

builder.Services.AddTransient<ICharacterService, CharacterService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger(options => options.SerializeAsV2 = true);
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1"));
}

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();