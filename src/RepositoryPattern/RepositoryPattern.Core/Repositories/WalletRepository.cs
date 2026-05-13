using RepositoryPattern.Core.Models;

namespace RepositoryPattern.Core.Repositories;

public class WalletRepository : IWalletRepository
{
    private readonly List<Wallet> _wallets = new();

    public IEnumerable<Wallet> GetAll()
    {
        return _wallets;
    }

    public Wallet? GetById(int id)
    {
        return _wallets
            .FirstOrDefault(w => w.Id == id);
    }

    public void Add(Wallet wallet)
    {
        _wallets.Add(wallet);
    }

    public void Update(Wallet wallet)
    {
        var existingWallet = _wallets
            .FirstOrDefault(w => w.Id == wallet.Id);

        if (existingWallet is not null)
        {
            existingWallet.Name = wallet.Name;
            existingWallet.Currency = wallet.Currency;
            existingWallet.Balance = wallet.Balance;
        }
    }

    public void Delete(int id)
    {
        var wallet = _wallets
            .FirstOrDefault(w => w.Id == id);

        if (wallet is not null)
        {
            _wallets.Remove(wallet);
        }
    }
}