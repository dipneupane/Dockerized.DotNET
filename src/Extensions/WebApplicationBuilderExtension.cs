using DotNet_AWS_Deployment_Demo.Context;
using Microsoft.EntityFrameworkCore;

namespace DotNet_AWS_Deployment_Demo.Extensions
{
    public static class WebApplicationBuilderExtension
    {
        public static async Task InitDatabase(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            if (context.Database.GetPendingMigrations().Any())
            {
                await context.Database.MigrateAsync();
            }
        }
    }
}