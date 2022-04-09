using MongoDB.Driver;
using ShoppingApiRepository.MongoEntity;
namespace ShoppingApiRepository
{
    public class MongoDbContext
    {
        public MongoDbContext()
        { }

        public IMongoCollection<MongoEntityProductModal> Products { get; set; }
    }
}
