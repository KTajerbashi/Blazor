using CleanArchitectureBlazor.Core.Application.Orders;
using CleanArchitectureBlazor.Core.Domain.Orders.Entities;
using CleanArchitectureBlazor.WebApp.Common.BaseApi;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureBlazor.WebApp.Controllers;

public class OrderController : BaseContorller
{
    private readonly IOrderRepository _repository;
    public OrderController(IOrderRepository repository)
    {
        _repository = repository;
    }
    [HttpPost]
    public async Task<IActionResult> Create(string title)
    {
        var entity = await _repository.CreateAsync(new Order(),CancellationToken.None);

        return Ok(entity);
    }

    [HttpPut]
    public async Task<IActionResult> Update()
    {
        await Task.CompletedTask;
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
