using UnityEngine;

public class UserInterface : MonoBehaviour
{
    [SerializeField] private WalletView _walletView;

    private Player _player;

    public void Initialize(Player player)
    {
        _player = player;
        _walletView.Initialize(_player.Wallet);
    }
}