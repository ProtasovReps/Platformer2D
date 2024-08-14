using UnityEngine;

public class UserInterface : MonoBehaviour
{
    [SerializeField] private SmoothSliderStatView _healthView;
    [SerializeField] private SmoothTextStatView _walletView;
    [SerializeField] private SliderCooldownView _cooldownAbilityView;
    [SerializeField] private Timer _timer;

    public void Initialize(Player player)
    {
        _healthView.Initialize(player.GetHealthAsRangeable());
        _walletView.Initialize(player.GetWalletAsRangeable());
        _cooldownAbilityView.Initialize(_timer);
    }
}