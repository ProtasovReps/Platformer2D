using TMPro;
using UnityEngine;

public class WalletView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private Wallet _wallet;

    public void Initialize(Wallet wallet)
    {
        _wallet = wallet;
        _wallet.AmountChanged += DisplayCoinsAmount;
        
        DisplayCoinsAmount();
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
