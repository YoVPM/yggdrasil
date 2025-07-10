using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using YoVPM.Yggdrasil.Core.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.Services.AddDbContext<YggdrasilDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("YggdrasilDb"));
});

var app = builder.Build();

app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.Run();
