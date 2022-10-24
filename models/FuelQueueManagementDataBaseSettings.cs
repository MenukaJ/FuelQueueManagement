namespace FuelQueueManagement.models
{
    public class FuelQueueManagementDataBaseSettings : IFuelQueueManagementDataBaseSettings
    {
        public string UserCollectionName { get; set; } = String.Empty;
        public string FuelStationName { get; set; } = String.Empty;
        public string FuelDetailsName { get; set; } = String.Empty;
        public string FuelQueueName { get; set; } = String.Empty;
        public string ConnectionString { get; set; } = String.Empty;
        public string DatabaseName { get; set; } = String.Empty;
    }
}
