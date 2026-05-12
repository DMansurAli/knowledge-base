using RepositoryPattern.Core.Models;
using RepositoryPattern.Core.Repositories;

namespace RepositoryPattern.Core.Services;

public class WalletService
{
    private readonly IRepository<Wallet> _repository;

    public WalletService(IRepository<Wallet> repository)
    {
        _repository = repository;
    }

    public void SeedData()
    {
        _repository.Add(new Wallet
        {
            Id = 1,
            Name = "Work",
            Currency = "USD",
            Balance = 1200
        });

        _repository.Add(new Wallet
        {
            Id = 2,
            Name = "Personal",
            Currency = "USD",
            Balance = 25
        });
    }


    // GET ALL WALLETS
    public IEnumerable<Wallet> Get()
    {
        return _repository.GetAll();
    }

    // GET WALLET BY ID
    public Wallet? GetById(int id)
    {
        return _repository.GetById(id);
    }

    // ADD WALLET
    public void Create(Wallet wallet)
    {
        _repository.Add(wallet);
    }
}