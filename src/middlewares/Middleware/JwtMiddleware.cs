using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Middleware;

public class JwtMiddleware(IJwtBuilder jwtBuilder) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        // Get the token from the Authorization header
        var bearer = context.Request.Headers["Authorization"].ToString();
        var token = bearer.Replace("Bearer ", string.Empty);

        if (!string.IsNullOrEmpty(token))
        {
            // Verify the token using the IJwtBuilder
            var userId = jwtBuilder.ValidateToken(token);
            context.Items["userId"] = userId;
        }

        // Continue processing the request
        await next(context);
    }
}