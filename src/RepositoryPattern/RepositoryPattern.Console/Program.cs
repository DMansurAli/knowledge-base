using RepositoryPattern.Core.Models;
using RepositoryPattern.Core.Repositories;
using RepositoryPattern.Core.Services;

IRepository<Wallet> repository = new WalletRepository();

var service = new WalletService(repository);

service.SeedData();

var data = service.Get();

foreach (var item in data)
{
    Console.WriteLine($"Id: {item.Id}, Name: {item.Name}, Currency: {item.Currency}, Balance: {item.Balance:C}");
}

Console.WriteLine("\nPress any key to exit...");
Console.ReadKey();