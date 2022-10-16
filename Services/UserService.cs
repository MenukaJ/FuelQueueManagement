using FuelQueueManagement.models;
using MongoDB.Driver;

namespace FuelQueueManagement.Services
{
    public class UserService : IUserService
    {
        private readonly IMongoCollection<User> _users;

        public UserService(IFuelQueueManagementDataBaseSettings settings, IMongoClient mongoClient) 
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _users = database.GetCollection<User>(settings.UserCollectionName);
        }

        User IUserService.Create(User user)
        {
            _users.InsertOne(user);
            return user;
        }

        List<User> IUserService.Get()
        {
            return _users.Find(user => true).ToList();
        }

        User IUserService.Update(string id, User user)
        {
            _users.ReplaceOne(user => user.Id == id, user);
            return user;
        }
    }
}
