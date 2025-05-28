using DotNet_AWS_Deployment_Demo.Entities;
using Microsoft.EntityFrameworkCore;

namespace DotNet_AWS_Deployment_Demo.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}