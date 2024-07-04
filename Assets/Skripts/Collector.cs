using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField] private WalletView _walletView;

    private Wallet _wallet;

    public void Initialize()
    {
        _wallet = new Wallet();
        _walletView.Initialize(_wallet);
    }

    public void AddMoney(Coin coin)
    {
        coin.Disappear();
        _wallet.AddCoin();
    }

    public void Heal(Food food)
    {
        food.Disappear();
        //_health.Heal
    }
}
