using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;
using System.Runtime.Serialization;

namespace API.ActionFilters
{
    public class DocsFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            operation.Parameters ??= new List<OpenApiParameter>();

            ControllerActionDescriptor ActionDescriptor = context.ApiDescription.ActionDescriptor as ControllerActionDescriptor;

            if (ActionDescriptor != null)
            {
                bool allowAll = ActionDescriptor.EndpointMetadata.OfType<AllowAllAttribute>().Any();
                bool allowAnonymous = ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
                bool allowDebugAttribute = ActionDescriptor.EndpointMetadata.OfType<AllowDebugAttribute>().Any();

                if (!allowAll && !allowDebugAttribute)
                {
                    operation.Parameters.Add(new OpenApiParameter
                    {
                        Name = HeadersConstants.AppKey,
                        In = ParameterLocation.Header,
                        Required = true,
                        Schema = new OpenApiSchema
                        {
                            Type = "string"
                        }
                    });
                }
                if (!allowAnonymous && !allowAll)
                {
                    operation.Parameters.Add(new OpenApiParameter
                    {
                        Name = HeadersConstants.AuthorizationToken,
                        In = ParameterLocation.Header,
                        Required = true,
                        Schema = new OpenApiSchema
                        {
                            Type = "string"
                        }
                    });
                }

                operation.Parameters.Add(new OpenApiParameter
                {
                    Name = HeadersConstants.Culture,
                    In = ParameterLocation.Header,
                    Description = "en | ar",
                    Schema = new OpenApiSchema
                    {
                        Type = "string",
                    },
                });
            }
        }
    }

    public class MySwaggerSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (schema?.Properties == null)
            {
                return;
            }

            IEnumerable<PropertyInfo> ignoreDataMemberProperties = context.Type.GetProperties()
                .Where(t => t.GetCustomAttribute<IgnoreDataMemberAttribute>() != null);

            foreach (PropertyInfo ignoreDataMemberProperty in ignoreDataMemberProperties)
            {
                string propertyToHide = schema.Properties.Keys
                    .SingleOrDefault(x => x.ToLower() == ignoreDataMemberProperty.Name.ToLower());

                if (propertyToHide != null)
                {
                    _ = schema.Properties.Remove(propertyToHide);
                }
            }
        }
    }
}
