
using CloudCustomers.Domain.Domain;

namespace CloudCustomers.UnitTests.Fixtures;

public class UserFixture
{
    public static List<User> GetTestUsers()
    {
        return new List<User>()
        {
            new User
            {
                Id = 1,
                Age = 20,
                Email = "user1@example.com",
                Address = new Address
                {
                    Street = "123 Main St",
                    City = "New York",
                    ZipCode = "10001"
                }
            },
            new User
            {
                Id = 2,
                Age = 25,
                Email = "user2@example.com",
                Address = new Address
                {
                    Street = "456 Elm St",
                    City = "San Francisco",
                    ZipCode = "94110"
                }
            },
            new User
            {
                Id = 3,
                Age = 30,
                Email = "user3@example.com",
                Address = new Address
                {
                    Street = "789 Oak St",
                    City = "Chicago",
                    ZipCode = "60611"
                }
            },
            new User
            {
                Id = 4,
                Age = 35,
                Email = "user4@example.com",
                Address = new Address
                {
                    Street = "321 Maple St",
                    City = "Boston",
                    ZipCode = "02108"
                }
            },
            new User
            {
                Id = 5,
                Age = 40,
                Email = "user5@example.com",
                Address = new Address
                {
                    Street = "654 Pine St",
                    City = "Los Angeles",
                    ZipCode = "90012"
                }
            }
        };
    }
}
