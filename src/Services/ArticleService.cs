using DotNet_AWS_Deployment_Demo.Context;
using DotNet_AWS_Deployment_Demo.Dto;
using DotNet_AWS_Deployment_Demo.Entities;
using Microsoft.EntityFrameworkCore;

namespace DotNet_AWS_Deployment_Demo.Services
{
    public interface IArticleService
    {
        Task Create(ArticleDto article);
        Task<List<ArticleDto>> GetAll();
    }
    public class ArticleService : IArticleService
    {
        private readonly ApplicationDbContext _dbContext;
        public ArticleService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Create(ArticleDto article)
        {
            _dbContext.Articles.Add(new Article
            {
                Title = article.Title,
                Description = article.Description,
                Category = article.Category
            });
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<ArticleDto>> GetAll()
        {
            var articles = await _dbContext.Articles.ToListAsync();
            return articles.Select(a => new ArticleDto
            {
                Title = a.Title,
                Description = a.Description,
                Category = a.Category
            }).ToList();
        }
    }
}