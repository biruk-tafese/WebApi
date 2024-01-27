using MongoDB.Driver;
using DriverAppApi.Model;
using Microsoft.Extensions.Options;
using DriverAppApi.Configurations;

namespace DriverAppApi.Service;

public class DriverService
{
     private readonly IMongoCollection<Driver> _driverCollections;

     public DriverService(IOptions<DatabaseSettings> databaseSettings){

       var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);
       var  mongoDb  = mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);

       _driverCollections = mongoDb.GetCollection<Driver>(databaseSettings.Value.CollectionName);

     }

     public async Task<List<Driver>> GetAsync() => await _driverCollections.Find(filter:_ => true).ToListAsync();

   public async Task<Driver> GetAsync(string id)
    {
             var result = await _driverCollections.FindAsync(x => x.Id == id);
            return await result.FirstOrDefaultAsync();
    }

     public async Task CreateAsync(Driver driver) => await _driverCollections.InsertOneAsync(driver);

     public async Task UpdateAsync(Driver driver) => await _driverCollections.ReplaceOneAsync(x=>x.Id == driver.Id,driver);

    public async Task RemoveAsync(string id) => await _driverCollections.DeleteOneAsync(x => x.Id==id);
    }
