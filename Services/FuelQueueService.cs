using FuelQueueManagement.models;
using MongoDB.Driver;

namespace FuelQueueManagement.Services
{
    public class FuelQueueService : IFuelQueueService
    {
        private readonly IMongoCollection<FuelQueue> _fuelQueue;
        public FuelQueueService(IFuelQueueManagementDataBaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _fuelQueue = database.GetCollection<FuelQueue>(settings.FuelQueueName);
        }

        public FuelQueue Create(FuelQueue fuelQueue)
        {
            _fuelQueue.InsertOne(fuelQueue);
            return fuelQueue;
        }

        public List<FuelQueue> Get()
        {
            return _fuelQueue.Find(fuelQueue => true).ToList();
        }

        public FuelQueue Get(string id)
        {
            return _fuelQueue.Find(fuelQueue => fuelQueue.Id == id).FirstOrDefault();
        }

        public FuelQueue Update(string id, FuelQueue fuelQueue)
        {
            _fuelQueue.ReplaceOne(fuelQueueKey => fuelQueueKey.Id == id, fuelQueue);
            return fuelQueue;
        }

        public void Remove(string id)
        {
            _fuelQueue.DeleteOne(fuelQueue => fuelQueue.Id == id);
        }

        public FuelQueue GetByEmail(string email)
        {
            return _fuelQueue.Find(fuelQueue => fuelQueue.user.Email == email).FirstOrDefault();
        }
    }
}
