using Bogus;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ulti
{
  public class MockData
  {
    public IEnumerable<T> GetMockData<T>(int numbers)
    {
      Randomizer.Seed = new Random();
      //var ordergenerator = new Faker<Order>()
      //  .RuleFor(o => o.Id, Guid.NewGuid)
      //  .RuleFor(o => o.Date, f => f.Date.Past(3))
      //  .RuleFor(o => o.OrderValue, f => f.Finance.Amount(0, 10000))
      //  .RuleFor(o => o.Shipped, f => f.Random.Bool(0.9f));
      var companyGenerator = new Faker<Company>()
          .RuleFor(c => c.Name, f => f.Company.CompanyName())
          .RuleFor(c => c.CreateId, f => f.Random.Number(0, 2))
          .RuleFor(c => c.CreateTime, f => f.Date.Past(3))
          .RuleFor(c => c.LastModifierId, f => f.Random.Number(0, 2))
          .RuleFor(c => c.LastModifyTime, f => f.Date.Past(3));
      //.RuleFor(c => c.Phone, f => f.Phone.PhoneNumber())
      //.RuleFor(c => c.Email, f => f.Internet.Email())
      //.RuleFor(c => c.ContactName, (f, c) => f.Name.FullName())
      //.RuleFor(c => c.Orders, f => ordergenerator.Generate(f.Random.Number(10)).ToList());

      var userGenerator = new Faker<User>()
        .RuleFor(u => u.Name, f => $"{new Bogus.DataSets.Name("zh_CN").LastName()}{new Bogus.DataSets.Name("zh_CN").FirstName()}")
        .RuleFor(u => u.Account, f => f.Random.AlphaNumeric(20))
        .RuleFor(u => u.Password, f => f.Random.AlphaNumeric(20))
        .RuleFor(u => u.Email, f => f.Internet.Email())
        .RuleFor(u => u.Mobile, f => f.Phone.PhoneNumber("13#########"))
        .RuleFor(u => u.CompanyId, f => f.Random.Number(0, 2))
        .RuleFor(u => u.CompanyName, f => f.Company.CompanyName())
        .RuleFor(u => u.Status, f => f.Random.Number(0, 2))
        .RuleFor(u => u.UserType, f => f.Random.Number(0, 2))
        .RuleFor(u => u.LastLoginTime, f => f.Date.Past())
        .RuleFor(u => u.CreateId, f => f.Random.Number(0, 2))
        .RuleFor(u => u.CreateTime, f => f.Date.Past())
        .RuleFor(u => u.LastModifierId, f => f.Random.Number(0, 2))
        .RuleFor(u => u.LastModifyTime, f => f.Date.Past());

      if (typeof(T).Name == "User")
        return (IEnumerable<T>)userGenerator.Generate(numbers);
      return (IEnumerable<T>)companyGenerator.Generate(numbers);

    }
  }
}
