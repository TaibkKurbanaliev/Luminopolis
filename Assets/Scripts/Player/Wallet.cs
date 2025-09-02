using System;

public class Wallet 
{
    public event Action<int> MoneyChanged;
    public int Money { get; private set; }

    public Wallet()
    {
        Money = 100;
    }

    public Wallet(int money)
    {
        Money = money;
    }

    public void AddMoney(int money)
    {
        if (money <= 0)
        {
            throw new ArgumentException(nameof(money));
        }

        Money += money;
        MoneyChanged?.Invoke(Money);
    }

    public bool TrySpendMoney(int money)
    {
        if (money <= 0)
        {
            throw new ArgumentException(nameof(money));
        }

        if (Money < money)
        {
            return false;
        }

        Money -= money;
        MoneyChanged?.Invoke(Money);
        return true;
    }
}
