using Basket.API.Entities;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Basket.API.Repositories;

public class BasketRepository(IDistributedCache redis) : IBasketRepository
{
    readonly IDistributedCache _redis = redis 
        ?? throw new ArgumentNullException(nameof(redis));

    async Task IBasketRepository.DeleteBasket(string userName)
        => await _redis.RemoveAsync(userName);

    async Task<ShoppingCart?> IBasketRepository.GetBasket(string userName)
    {
        var basket = await _redis.GetStringAsync(userName);
        if (string.IsNullOrEmpty(basket))
            return null;
        return JsonConvert.DeserializeObject<ShoppingCart>(basket);
    }

    async Task<ShoppingCart> IBasketRepository.UpdateBasket(ShoppingCart basket)
    {
        await _redis.SetStringAsync(basket.UserName, JsonConvert.SerializeObject(basket));
        return basket;
    }

}
