namespace FuelQueueManagement.models
{
    public interface IFuelQueueManagementDataBaseSettings
    {
        string UserCollectionName { get; set; }
        string FuelStationName { get; set; }
        string FuelDetailsName { get; set; }
        string FuelQueueName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
