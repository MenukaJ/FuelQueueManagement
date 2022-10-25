using FuelQueueManagement.models;
using MongoDB.Bson;
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

        List<FuelQueue> IFuelQueueService.GetByFuelStation(string name)
        {
            
            return _fuelQueue.Find(fuelQueue => fuelQueue.fuelStation.Name == name && fuelQueue.Status == "JOINED").ToList();
            
        }
    }
}
