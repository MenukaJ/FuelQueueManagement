using FuelQueueManagement.models;
using MongoDB.Bson;
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


        public User Get(string id)
        {
            return _users.Find(user => user.Id == id).FirstOrDefault();
        }

        /*public User Update(string id, User user)
        {
            _users.ReplaceOne(user => user.Id == id, user);
            return user;
        }*/

        public User Update(string id, User user)
        {
            _users.ReplaceOne(user => user.Id == id, user);
            return user;
        }


        public User GetByEmail(string email)
        {
            return _users.Find(user => user.Email == email).FirstOrDefault();
        }
    }
}
