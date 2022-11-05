using FuelQueueManagement.models;
using MongoDB.Driver;
using ZstdSharp.Unsafe;

namespace FuelQueueManagement.Services
{
    public class FuelStationService : IFuelStationService
    {
        private readonly IMongoCollection<FuelStation> _fuelStation;

        public FuelStationService(IFuelQueueManagementDataBaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _fuelStation = database.GetCollection<FuelStation>(settings.FuelStationName);
        }
        FuelStation IFuelStationService.Create(FuelStation fuelStation)
        {
            _fuelStation.InsertOne(fuelStation);
            return fuelStation;
        }

        List<FuelStation> IFuelStationService.Get()
        {
            return _fuelStation.Find(fuelStation => true).ToList();
        }

        FuelStation IFuelStationService.Get(string id)
        {
            return _fuelStation.Find(fuelStation => fuelStation.Id == id).FirstOrDefault();
        }

        FuelStation IFuelStationService.Update(string id, FuelStation fuelStation)
        {
            _fuelStation.ReplaceOne(fuelStation => fuelStation.Id == id, fuelStation);
            return fuelStation;
        }

        public List<FuelStation> GetByOwnerEmail(string email)
        {
            return _fuelStation.Find(fuelStation => fuelStation.Owner.Email == email).ToList();
        }
    }
}
