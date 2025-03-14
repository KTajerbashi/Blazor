using CleanArchitectureBlazor.Core.Application.Categories;
using CleanArchitectureBlazor.Core.Application.Products;
using CleanArchitectureBlazor.Core.Domain.Products.Entities;
using CleanArchitectureBlazor.WebApp.Common.BaseApi;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureBlazor.WebApp.Controllers;

public class ProductController : BaseContorller
{
    private readonly IProductRepository _repository;
    private readonly ICategoryRepository _categoryRepository;
    public ProductController(IProductRepository repository, ICategoryRepository categoryRepository)
    {
        _repository = repository;
        _categoryRepository = categoryRepository;
    }

    [HttpGet("GetInfo")]
    public async Task<IActionResult> GetInfo()
    {
        var res = new
        {
            A = _categoryRepository.ContextId(),
            B = _repository.ContextId(),
        };
        return Ok(res);
    }

    [HttpPost]
    public async Task<IActionResult> Create(string title, string description, int price, long categoryId)
    {
        _repository.BeginTransaction();
        try
        {
            var entity = await _repository.CreateAsync(new Product(title,description,price,categoryId),CancellationToken.None);
            _categoryRepository.CommitTransaction();
            return Ok(entity);
        }
        catch (Exception)
        {
            _repository.RollbackTransaction();
            throw;
        }
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
        var entities = await _repository.GetAsync(CancellationToken.None);
        return Ok(entities);
    }
}
