using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YoVPM.Yggdrasil.Api;
using YoVPM.Yggdrasil.Api.Extenstion;
using YoVPM.Yggdrasil.Core.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
    options.Conventions.Add(new RoutePrefixConvention(new RouteAttribute("v{version:apiVersion}"))));

builder.Services.AddProblemDetails();

var apiVersioning = builder.Services.AddApiVersioning(options =>
    {
        options.ReportApiVersions = true;
        options.UnsupportedApiVersionStatusCode = 501;
        options.ApiVersionReader = new UrlSegmentApiVersionReader();
    })
    .AddMvc();

builder.AddAppOpenApi(apiVersioning);

builder.Services.AddDbContext<YggdrasilDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("YggdrasilDb"));
});

var app = builder.Build();

app.MapControllers();

app.UseAppOpenApi();

app.Run();
