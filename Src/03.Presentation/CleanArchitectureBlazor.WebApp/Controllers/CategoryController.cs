using CleanArchitectureBlazor.Core.Application.Categories;
using CleanArchitectureBlazor.WebApp.Common.BaseApi;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureBlazor.WebApp.Controllers;

public class CategoryController : BaseContorller
{
    private readonly ILogger<CategoryController> _logger;
    private readonly ICategoryRepository _repository;
    public CategoryController(ICategoryRepository repository, ILogger<CategoryController> logger)
    {
        _repository = repository;
        _logger = logger;
    }
    [HttpPost]
    public async Task<IActionResult> Create(string title)
    {
        var entity = await _repository.CreateAsync(new Core.Domain.Categories.Entities.Category(title),CancellationToken.None);
        await _repository.SaveChangeAsync();
        return Ok(entity);
    }

    [HttpPut]
    public async Task<IActionResult> Update()
    {
        return Ok($"Updated {10}");
    }

    [HttpDelete("{key}")]
    public async Task<IActionResult> Delete(Guid key)
    {
        await _repository.DeleteAsync(key, CancellationToken.None);
        return Ok($"Deleted {key}");
    }

    [HttpGet("{key}")]
    public async Task<IActionResult> Read(Guid key)
    {
        var entity = await _repository.GetAsync(key,CancellationToken.None);
        return Ok(entity);
    }

    [HttpGet]
    public async Task<IActionResult> ReadAll()
    {
        try
        {
            //throw new Exception("خطای کاربری");
            _logger.LogInformation($"LogInformation => {Guid.NewGuid()}");
            _logger.LogCritical($"LogCritical => {Guid.NewGuid()}");
            _logger.LogDebug($"LogDebug => {Guid.NewGuid()}");
            _logger.LogError($"LogError => {Guid.NewGuid()}");
            _logger.LogTrace($"LogTrace => {Guid.NewGuid()}");
            _logger.LogWarning($"LogWarning => {Guid.NewGuid()}");
            _logger.Log(LogLevel.Information, "123456789");
            var entities = await _repository.GetAsync(CancellationToken.None);
            return Ok(entities);
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Error, ex.Message);
            _logger.Log(LogLevel.Error,ex,"خطای اتفاقی");
            throw;
        }
    }
}
