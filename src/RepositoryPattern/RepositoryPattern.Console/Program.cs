using RepositoryPattern.Core.Models;
using RepositoryPattern.Core.Repositories;
using RepositoryPattern.Core.Services;

var service = new WalletService(new WalletRepository());

bool running = true;
while (running)
{

    Console.WriteLine("Choose an option: 1) Show All  2) Get By ID  3) Create 0) Exit");
    var choice = Console.ReadLine();
    switch (choice)
    {
        case "1": // READ ALL
            foreach (var w in service.GetWallets())
                Console.WriteLine($"[{w.Id}] {w.Name} - {w.Balance:C}");
            break;

        case "2": // READ BY ID
            Console.Write("Enter ID: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var wallet = service.GetWalletById(id);
                Console.WriteLine(wallet != null ? $"Found: {wallet.Name}" : "Not Found");
            }
            break;

        case "3": // CREATE
            Console.Write("Enter Name: ");
            var name = Console.ReadLine();
            service.CreateWallet(new Wallet { Name = name, Currency = "USD", Balance = 0 });
            Console.WriteLine("Wallet Created.");
            break;

        case "0":
            running = false;
            Console.WriteLine("Exiting...");
            continue;

        default:
            Console.WriteLine("Invalid option.");
            break;
    }

    Console.WriteLine("\nPress any key to return to menu...");
    Console.ReadKey();
}
