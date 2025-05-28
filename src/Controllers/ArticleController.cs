using DotNet_AWS_Deployment_Demo.Dto;
using DotNet_AWS_Deployment_Demo.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotNet_AWS_Deployment_Demo.Controllers;

[ApiController]
[Route("[controller]")]
public class ArticleController : ControllerBase
{
    private readonly IArticleService _articleService;
    public ArticleController(IArticleService articleService)
    {
        _articleService = articleService;
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create(ArticleDto articleDto)
    {
        await _articleService.Create(articleDto);
        return Ok("New article created.");
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var articles = await _articleService.GetAll();
        return Ok(articles);
    }
}