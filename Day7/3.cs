using System;
using System.Collections.Generic;
using System.Linq; 
public class User
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Country { get; set; }
} 
public class UserDirectory
{
    private Dictionary<string, User> _users = new Dictionary<string, User>();
 
    public void AddUser(User user)
    {
        _users[user.Name] = user;
    }
 
    public List<User> GetEligibleUsers()
    {
        return _users.Values
                     .Where(u => u.Age > 59)
                     .ToList();
    }
} 
class Program
{
    static void Main()
    {
        UserDirectory directory = new UserDirectory();
 
        directory.AddUser(new User { Name = "Alice", Age = 65, Country = "USA" });
        directory.AddUser(new User { Name = "Bob", Age = 45, Country = "UK" });
        directory.AddUser(new User { Name = "Charlie", Age = 70, Country = "India" });
 
        List<User> eligibleUsers = directory.GetEligibleUsers();
 
        Console.WriteLine("Eligible Users (Age > 59):");
        foreach (var user in eligibleUsers)
        {
            Console.WriteLine($"{user.Name} - Age: {user.Age}");
        }
    }
}