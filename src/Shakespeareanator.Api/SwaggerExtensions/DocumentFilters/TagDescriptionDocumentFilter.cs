namespace Shakespeareanator.Api
{
    using Swashbuckle.AspNetCore.SwaggerGen;
    using Microsoft.OpenApi.Models;

    internal class TagDescriptionsDocumentFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            swaggerDoc.Tags = new[] {
                new OpenApiTag {
                    Name = "Pokemon",
                    Description = "The Pokemon Endpoints"
                }
            };
        }
    }
}