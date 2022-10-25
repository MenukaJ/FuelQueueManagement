using FuelQueueManagement.models;

namespace FuelQueueManagement.Services
{
    public interface IFuelQueueService
    {
        FuelQueue Create(FuelQueue fuelQueue);
        FuelQueue Update(string id, FuelQueue fuelQueue);
        List<FuelQueue> Get();
        FuelQueue Get(string id);
        void Remove(String id);
        List<FuelQueue> GetByEmail(string email);
    }
}
