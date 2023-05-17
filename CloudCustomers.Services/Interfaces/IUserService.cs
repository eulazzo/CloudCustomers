using CloudCustomers.Domain.Domain;

namespace CloudCustomers.Services.Interfaces;

public interface IUserService
{
    Task<IEnumerable<User>> ListUsers();
}
