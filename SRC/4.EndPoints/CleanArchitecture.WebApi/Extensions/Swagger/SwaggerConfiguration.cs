using CleanArchitecture.WebApi.Extensions.Swagger.Filters;
using CleanArchitecture.WebApi.Extensions.Swagger.Options;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Reflection;

namespace CleanArchitecture.WebApi.Extensions.Swagger;

public static class SwaggerConfiguration
{
    public static IServiceCollection AddSwaggerServiceConfiguration(this IServiceCollection services, IConfiguration configuration, string sectionName)
    {
        var swaggerOption = configuration.GetSection(sectionName).Get<SwaggerOption>();
        if (swaggerOption != null && swaggerOption.SwaggerDoc != null && swaggerOption.Enabled == true)
        {
            services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc(swaggerOption.SwaggerDoc.Name, new OpenApiInfo
                {
                    Title = swaggerOption.SwaggerDoc.Title,
                    Version = swaggerOption.SwaggerDoc.Version
                });
                option.TagActionsBy(api =>
                {
                    if (api.GroupName != null)
                        return new[] { api.GroupName };

                    var controllerActionDescriptor = api.ActionDescriptor as ControllerActionDescriptor;

                    if (controllerActionDescriptor != null)
                        return new[] { controllerActionDescriptor.ControllerName };

                    throw new InvalidOperationException("Unable to determine tag for endpoint.");
                });

                option.DocInclusionPredicate((name, api) => true);
                var oAuthOption = configuration.GetSection("OAuth").Get<SwaggerOAuthOption>();
                if (oAuthOption != null && oAuthOption.Enabled)
                {
                    option.AddSecurityDefinition("OAuth2", new OpenApiSecurityScheme
                    {
                        Name = "Authorization",
                        Description = "OAuth2",
                        BearerFormat = "Bearer <token>",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.OAuth2,
                        Flows = new OpenApiOAuthFlows
                        {
                            AuthorizationCode = new OpenApiOAuthFlow
                            {
                                AuthorizationUrl = new Uri(oAuthOption.AuthorizationUrl),
                                TokenUrl = new Uri(oAuthOption.TokenUrl),
                                Scopes = oAuthOption.Scopes
                            }
                        },
                    }); ;

                    option.OperationFilter<AddParamsToHeader>();
                }
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                //option.IncludeXmlComments(xmlPath);

            });
        }
        return services;
    }

    public static void UseSwaggerUI(this WebApplication app, string sectionName)
    {
        var swaggerOption = app.Configuration
            .GetSection(sectionName)
            .Get<SwaggerOption>();

        if (swaggerOption != null && swaggerOption.SwaggerDoc != null && swaggerOption.Enabled == true)
        {
            app.UseSwagger();
            app.UseSwaggerUI(option =>
            {
                option.DocExpansion(DocExpansion.None);
                option.SwaggerEndpoint(swaggerOption.SwaggerDoc.URL, swaggerOption.SwaggerDoc.Title);
                option.RoutePrefix = swaggerOption.SwaggerDoc.Key;
                option.OAuthUsePkce();
            });
        }
    }
}
