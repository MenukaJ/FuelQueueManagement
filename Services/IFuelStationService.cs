using FuelQueueManagement.models;

namespace FuelQueueManagement.Services
{
    public interface IFuelStationService
    {
        FuelStation Create(FuelStation fuelStation);
        FuelStation Update(string id, FuelStation fuelStation);
        List<FuelStation> Get();
        FuelStation Get(string id);
        List<FuelStation> GetByOwnerEmail(string email);
    }
}
