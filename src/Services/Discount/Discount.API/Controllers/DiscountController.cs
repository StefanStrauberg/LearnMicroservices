using Discount.API.Entities;
using Discount.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Discount.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class DiscountController(IDiscountRepository repository) : ControllerBase
{
    readonly IDiscountRepository _repository = repository
        ?? throw new ArgumentNullException(nameof(repository));
    
    [HttpGet("{productName}", Name = "GetDiscount")]
    [ProducesResponseType(typeof(Coupon), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetDiscount(string productName)
        => Ok(await _repository.GetDiscount(productName));
    
    [HttpPost]
    [ProducesResponseType(typeof(Coupon), StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateDiscount([FromBody] Coupon coupon)
    {
        await _repository.CreateDiscount(coupon);
        return CreatedAtAction("GetDiscount", new { productName = coupon.ProductName }, coupon);
    }

    [HttpPut]
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    public async Task<IActionResult> UpdateDiscount([FromBody] Coupon coupon)
        => Ok(await _repository.UpdateDiscount(coupon));
    
    [HttpDelete("{productName}", Name = "DeleteDiscount")]
    [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteDiscount(string productName)
        => Ok(await _repository.DeleteDiscount(productName));
}
