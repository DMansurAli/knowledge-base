using RepositoryPattern.Core.Models;

namespace RepositoryPattern.Core.Repositories;

public class WalletRepository : IRepository<Wallet>
{
    private readonly List<Wallet> _wallets = new();

    public IEnumerable<Wallet> GetAll()
    {
        return _wallets;
    }

    public Wallet? GetById(int id)
    {
        return _wallets.FirstOrDefault(p => p.Id == id);
    }

    public void Add(Wallet entity)
    {
        _wallets.Add(entity);
    }

    public void Update(Wallet entity)
    {
        var wallet = _wallets.FirstOrDefault(p => p.Id == entity.Id);

        if (wallet is not null)
        {
            wallet.Name = entity.Name;
            wallet.Currency = entity.Currency;
            wallet.Balance = entity.Balance;
        }
    }

    public void Delete(int id)
    {
        var wallet = _wallets.FirstOrDefault(p => p.Id == id);

        if (wallet is not null)
        {
            _wallets.Remove(wallet);
        }
    }
}