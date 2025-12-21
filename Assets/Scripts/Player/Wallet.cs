using System;

public class Wallet 
{
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
        EventBus<MoneyChangeEvent>.Raise(new MoneyChangeEvent { Money = money });
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
        EventBus<MoneyChangeEvent>.Raise(new MoneyChangeEvent { Money = money });
        return true;
    }
}
