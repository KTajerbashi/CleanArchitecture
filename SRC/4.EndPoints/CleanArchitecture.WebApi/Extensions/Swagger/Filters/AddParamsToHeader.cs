using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace CleanArchitecture.WebApi.Extensions.Swagger.Filters;

public class AddParamsToHeader : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        if (operation.Security == null)
            operation.Security = new List<OpenApiSecurityRequirement>();

        operation.Security.Add(new OpenApiSecurityRequirement()
        {
            {
                new OpenApiSecurityScheme()
                {
                    Name="OAuth2",
                    Scheme= "OAuth2",
                    In = ParameterLocation.Header,
                    Reference = new OpenApiReference()
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "OAuth2"
                    }
                }, new List<string>()
            }
        });
    }
}
