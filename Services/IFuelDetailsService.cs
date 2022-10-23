using FuelQueueManagement.models;

namespace FuelQueueManagement.Services
{
    public interface IFuelDetailsService
    {
        FuelDetails Create(FuelDetails fuelDetails);
        FuelDetails Update(string id, FuelDetails fuelDetails);
        List<FuelDetails> Get();
        FuelDetails Get(string id);
        void Remove(String id);
    }
}
