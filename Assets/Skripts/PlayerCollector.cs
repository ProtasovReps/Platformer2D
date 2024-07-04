using UnityEngine;

public class PlayerCollector : MonoBehaviour
{
    [SerializeField] private WalletView _walletView;

    private Wallet _wallet;

    public void Initialize()
    {
        _wallet = new Wallet();
        _walletView.Initialize(_wallet);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coin))
        {
            coin.Hide();
            _wallet.AddCoin();
        }
    }
}
