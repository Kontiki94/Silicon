using API_Silicon.Configurations;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<SubscriberRepo>();
builder.Services.AddScoped<CoursesRepository>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
//builder.Services.RegisterJwt(builder.Configuration);
builder.Services.RegisterSwagger();

//// https://swagger.io/docs/specification/authentication/api-keys/
//builder.Services.AddSwaggerGen(c =>
//{
//    c.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
//    {
//        Description = "API Key Authorization",
//        Name = "key",
//        In = ParameterLocation.Query,
//        Type = SecuritySchemeType.ApiKey
//    });

//    c.AddSecurityRequirement(new OpenApiSecurityRequirement
//    {
//        {
//            new OpenApiSecurityScheme
//            {
//                Reference = new OpenApiReference
//                {
//                    Type = ReferenceType.SecurityScheme,
//                    Id = "ApiKey"
//                }
//            }, new string[] {}
//        }
//    });
//});

builder.Services.AddDbContext<DataContext>(x =>
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));

var app = builder.Build();

app.UseCors(x => x.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

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
