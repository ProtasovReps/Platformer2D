using UnityEngine;

public class UserInterface : MonoBehaviour
{
    [SerializeField] private Viewer _walletView;
    [SerializeField] private Viewer _healthView;
    
    public void Initialize()
    {
        _walletView.Initialize();
        _healthView.Initialize();
    }
}