﻿
namespace CloudCustomers.Domain.Domain;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
    public Address Address{ get; set; }
}
