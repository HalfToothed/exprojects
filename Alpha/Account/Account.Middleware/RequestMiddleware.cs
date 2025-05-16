using Account.MasterDataLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Account.Middlewares
{
    public class RequestMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IConfiguration configuration, MasterDbContext dbContext)
        {
            var key = context.Request.Host.Port == 44332 ? "postgres1" : "postgres2";

            var cs = dbContext.Databases.FirstOrDefault(c => c.Name == key);

            context.Items["ConnectionString"] = cs.ConnectionString;

            await _next(context);
        }
    }

}
