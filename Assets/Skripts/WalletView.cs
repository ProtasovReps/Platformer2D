using TMPro;
using UnityEngine;

public class WalletView : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private TextMeshProUGUI _text;

    private void Start() => DisplayCoinsAmount();

    private void OnEnable()
    {
        _wallet.AmountChanged += DisplayCoinsAmount;
    }

    private void OnDisable()
    {
        _wallet.AmountChanged -= DisplayCoinsAmount;
    }

    private void DisplayCoinsAmount()
    {
        _text.text = _wallet.CoinsCount.ToString();
    }
}
