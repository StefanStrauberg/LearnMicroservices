using Catalog.API.Data;
using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Repositories;

class ProductRepository(ICatalogContext context) : IProductRepository
{
    readonly ICatalogContext _context = context 
        ?? throw new ArgumentNullException(nameof(context));

    async Task IProductRepository.CreatProduct(Product product)
        => await _context.Products.InsertOneAsync(product);

    async Task<bool> IProductRepository.DeleteProduct(string id)
    {
        var filter = Builders<Product>.Filter.Eq(x => x.Id, id);
        var updateResult = await _context.Products
                                         .DeleteOneAsync(filter);
        return updateResult.IsAcknowledged 
            && updateResult.DeletedCount > 0;
    }

    async Task<Product> IProductRepository.GetProduct(string id)
        => await _context.Products
                         .Find(x => x.Id == id)
                         .FirstOrDefaultAsync();

    async Task<IEnumerable<Product>> IProductRepository.GetProducts()
        => await _context.Products
                         .Find(x => true)
                         .ToListAsync();

    async Task<IEnumerable<Product>> IProductRepository.GetProductsByCategory(string categoryName)
    {
        var filter = Builders<Product>.Filter
                                      .Eq(x => x.Category, categoryName);
        return await _context.Products
                             .Find(filter)
                             .ToListAsync();
    }

    async Task<IEnumerable<Product>> IProductRepository.GetProductsByName(string name)
    {
        var filter = Builders<Product>.Filter.Eq(x => x.Name, name);
        return await _context.Products
                             .Find(filter)
                             .ToListAsync();
    }

    async Task<bool> IProductRepository.UpdateProduct(Product product)
    {
        var filter = Builders<Product>.Filter.Eq(x => x.Id, product.Id);
        var updateResult = await _context.Products
                                         .ReplaceOneAsync(filter, product);
        return updateResult.IsAcknowledged 
            && updateResult.ModifiedCount > 0;
    }

}
