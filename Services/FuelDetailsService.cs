using FuelQueueManagement.models;
using MongoDB.Driver;

namespace FuelQueueManagement.Services
{
    public class FuelDetailsService : IFuelDetailsService
    {
        private readonly IMongoCollection<FuelDetails> _fuelDetails;
        public FuelDetailsService(IFuelQueueManagementDataBaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _fuelDetails = database.GetCollection<FuelDetails>(settings.FuelDetailsName);
        }
        public FuelDetails Create(FuelDetails fuelDetails)
        {
            _fuelDetails.InsertOne(fuelDetails);
            return fuelDetails;
        }

        public List<FuelDetails> Get()
        {
            return _fuelDetails.Find(fuelDetails => true).ToList();
        }

        public FuelDetails Get(string id)
        {
            return _fuelDetails.Find(fuelDetails => fuelDetails.Id == id).FirstOrDefault();
        }

        public FuelDetails Update(string id, FuelDetails fuelDetails)
        {
            _fuelDetails.ReplaceOne(fuelDetailsKey => fuelDetailsKey.Id == id, fuelDetails);
            return fuelDetails;
        }

        public void Remove(string id)
        {
            _fuelDetails.DeleteOne(fuelDetails => fuelDetails.Id == id);
        }

        FuelDetails IFuelDetailsService.GetByFuelStatation(string id)
        {
            return _fuelDetails.Find(fuelDetails => fuelDetails.fuelStation.Id == id).FirstOrDefault();
        }
    }
}
