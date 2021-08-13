using MercadoFrutas.Presentation.WebApi.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace MercadoFrutas.Presentation.WebApi.Extensions
{
   public static class AppExtensions
    {
        public static void UseSwaggerExtension(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Fruta API");
            });
        }
        public static void UseErrorHandlingMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlerMiddleware>();
        }
    }
}