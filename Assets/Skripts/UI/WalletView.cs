using TMPro;
using UnityEngine;

public class WalletView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    
    private Wallet _wallet;

    public void Initialize(Wallet wallet)
    {
        _wallet = wallet;
        _wallet.AmountChanged += DisplayWalletValue;

        DisplayWalletValue();
    }

    private void OnDisable()
    {
        _wallet.AmountChanged -= DisplayWalletValue;
    }

    private void DisplayWalletValue()
    {
        _text.text = _wallet.Value.ToString();
    }
}
