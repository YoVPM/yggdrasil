using Asp.Versioning;
using Scalar.AspNetCore;

namespace YoVPM.Yggdrasil.Api.Extenstion;

// https://blog.elijahlopez.ca/posts/aspnet-add-versioning/

internal static class AppOpenApiExtenstion
{
    public static IApplicationBuilder UseAppOpenApi(this WebApplication app)
    {
        app.MapOpenApi().CacheOutput();
        app.MapScalarApiReference(options =>
        {
            options.DefaultFonts = false;
            options.Title = "YoVPM Yggdrasil API Reference";
        });

        if (app.Environment.IsDevelopment())
        {
            app.MapGet("/", () => Results.Redirect("/scalar/v1")).ExcludeFromDescription();
        }

        return app;
    }

    public static IHostApplicationBuilder AddAppOpenApi(
        this IHostApplicationBuilder builder,
        IApiVersioningBuilder? apiVersioning = null)
    {
        if (apiVersioning is null) return builder;

        // the default format will just be ApiVersion.ToString(); for example, 1.0.
        // this will format the version as "'v'major[.minor][-status]"
        apiVersioning.AddApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'VVV";
        });

        // Search code base for [ApiVersion(#.0)]
        string[] versions = ["v1"];
        foreach (var description in versions)
        {
            builder.Services.AddOpenApi(description, options =>
            {
                options.ApplyApiVersionInfo("YoVPM Yggdrasil API", "YoVPM Yggdrasil API Documentation");
                TODO: options.ApplyAuthorizationChecks();
                options.ApplySecuritySchemeDefinitions();
                options.ApplyOperationDeprecatedStatus();
                options.ApplyApiVersionDescription();
                options.ApplySchemaNullableFalse();
            });
        }

        return builder;
    }
}
