using CleanArchitectureBlazor.Core.Application.Categories;
using CleanArchitectureBlazor.Core.Application.Products;
using CleanArchitectureBlazor.Core.Domain.Products.Entities;
using CleanArchitectureBlazor.Infra.Data.SqlServer.Categories;
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
    public IActionResult GetInfo()
    {
        var res = new
        {
            A = _categoryRepository.ContextId(),
            B = _repository.ContextId(),
        };
        return Ok(res);
    }

    [HttpPost]
    public async Task<IActionResult> Create(long productId, string title, string description, int price, long categoryId)
    {
        //_repository.BeginTransaction();
        try
        {
            await Task.CompletedTask;
            var entity = new Product(productId,title,description,price,categoryId);
            entity.ChangePrice(price + 10);
            entity.ChangePrice(price + 20);
            entity.ChangePrice(price + 30);
            entity.ChangeTitle($"{title}-{entity.Price}");
            //var createResult = await _repository.CreateAsync(entity,CancellationToken.None);
            _repository.Save(entity);
            //_categoryRepository.CommitTransaction();
            return Ok(entity);
        }
        catch (Exception)
        {
            //_repository.RollbackTransaction();
            throw;
        }
    }

    [HttpPost("ChangeTitle")]
    public async Task<IActionResult> ChangeTitle(long productId, string title)
    {
        try
        {
            var entity = await _repository.GetAsync(productId, CancellationToken.None);
            entity.ChangeTitle(title);
            return Ok(entity);
        }
        catch (Exception)
        {

            throw;
        }
    }

    [HttpPost("ChangePrice")]
    public async Task<IActionResult> ChangePrice(long productId, int price)
    {
        try
        {
            var entity = await _repository.GetAsync(productId, CancellationToken.None);
            entity.ChangePrice(price);
            return Ok(entity);
        }
        catch (Exception)
        {

            throw;
        }
    }



    [HttpGet("GetEventSourceingAggregate")]
    public async Task<IActionResult> GetEventSourceingAggregate(long productId)
    {
        try
        {
            await Task.CompletedTask;
            var events = _repository.Get(productId);
            return Ok(events);
        }
        catch (Exception)
        {

            throw;
        }
    }



    [HttpPut]
    public async Task<IActionResult> Update(long productId, string title, int value)
    {
        var entity = await _repository.GetAsync(productId,CancellationToken.None);
        entity.AddDiscount(title, value);
        await _repository.SaveChangeAsync();
        return Ok(entity);
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
