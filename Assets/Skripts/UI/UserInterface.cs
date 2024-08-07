using UnityEngine;

public class UserInterface : MonoBehaviour
{
    [SerializeField] private SmoothSliderStatView _healthView;
    [SerializeField] private SmoothTextStatView _walletView;

    public void Initialize(Player player)
    {
        _healthView.Initialize(player.GetHealthAsRangeable());
        _walletView.Initialize(player.GetWalletAsRangeable());
    }
}