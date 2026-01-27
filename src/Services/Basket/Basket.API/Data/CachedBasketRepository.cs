
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace Basket.API.Data
{
    public class CachedBasketRepository
        (IBasketRepository repository,IDistributedCache cache) 
        : IBasketRepository
    {
        
        public async Task<ShoppingCart> GetBaket(string userName, CancellationToken cancellationToken = default)
        {
            var cahcedBasket = await cache.GetStringAsync(userName, cancellationToken);
            if(!string.IsNullOrEmpty(cahcedBasket)) 
                return JsonSerializer.Deserialize<ShoppingCart>(cahcedBasket)!;

            var basket=await repository.GetBaket(userName, cancellationToken);

            await cache.SetStringAsync(userName,JsonSerializer.Serialize(basket),cancellationToken);
            return basket;
            
        }

        public async Task<ShoppingCart> StoreBasket(ShoppingCart basket, CancellationToken cancellationToken = default)
        {
             await repository.StoreBasket(basket, cancellationToken);

            await cache.SetStringAsync(basket.UserName, JsonSerializer.Serialize(basket), cancellationToken);

            return basket;
        }

        public async Task<bool> DeleteBasket(string userName, CancellationToken cancellationToken = default)
        {
            await repository.DeleteBasket(userName, cancellationToken);

            await cache.RemoveAsync(userName, cancellationToken);

            return true;  

        }
    }
}
