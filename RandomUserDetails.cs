using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice
{
    public class RandomUserDetails
    {
        public UserDetails GenerateRandomPerson()
        {
            Random random = new Random();
            var age = random.Next(25, 99);
            var sal = random.Next(10000, 999999);
            var fakeData = new Faker<UserDetails>()
                .RuleFor(c => c.FirstName, f => f.Name.FirstName())
                .RuleFor(c => c.LastName, f => f.Name.LastName())
                .RuleFor(c => c.Email, (f, u) => f.Internet.Email(u.FirstName, u.LastName))
                .RuleFor(c => c.CurrentAddress, f => f.Address.FullAddress())
                .RuleFor(c => c.PermanentAddress, f => f.Address.FullAddress())
                .RuleFor(c => c.Department, f => f.Company.CompanySuffix())
                .RuleFor(c => c.Salary, sal)
                .RuleFor(c => c.Age, age);
            var data = fakeData.Generate();
            return data;
        }
    }
}
