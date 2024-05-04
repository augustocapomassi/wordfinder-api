using WordFinder.Api.Configuration;

namespace WordFinder.Api.Configuration;

public static class ApplicationBuilderExtensions
{
    public static void UseSwagger(this IApplicationBuilder app, IConfiguration configuration)
    {
        app.UseSwagger();
        var basePath = configuration[ApiConstants.ServiceBasePath];

        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint($"{basePath}{ApiConstants.SwaggerUrl}", ApiConstants.SwaggerDesc);
        });
    }

    public static void UsePathBaseFromConfiguration(this IApplicationBuilder app, IConfiguration configuration)
    {
        string? basePath = configuration[ApiConstants.ServiceBasePath];
        app.UsePathBase(new PathString(basePath));
    }
}