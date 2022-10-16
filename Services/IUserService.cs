using FuelQueueManagement.models;

namespace FuelQueueManagement.Services
{
    public interface IUserService
    {
        User Create(User user);
        User Update(string id, User user);

        List<User> Get();

    }
}
