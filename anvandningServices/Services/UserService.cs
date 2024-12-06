using System.Diagnostics;
using System.Linq.Expressions;
using anvandningServices.Factories;
using anvandningServices.Helpers;
using anvandningServices.Models;

namespace anvandningServices.Services;


public class UserService
{
    private readonly List<UserEntity> _users = [];

    public bool Create(UserRegistrationForm form)
    {
        try
        {
            UserEntity userEntity = UserFactory.Create(form);
            userEntity.Id = UniqueIdentifierGenerator.GenerateUniqueId();
            userEntity.Password = SecurePasswordGenerator.Generate(form.Password);

            _users.Add(userEntity);
            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }

    public IEnumerable<User> GetAll()
    {
        return _users.Select(UserFactory.Create);
    }

}
