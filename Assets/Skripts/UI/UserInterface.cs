using UnityEngine;

public class UserInterface : MonoBehaviour
{
    [SerializeField] private Viewer _walletView;
    [SerializeField] private Viewer _healthView;
    [SerializeField] private Viewer _enemy; //Ќе забудить убрать, а то € теб€, дурака, знаю!
    
    public void Initialize()
    {
        _enemy.Initialize();
        _walletView.Initialize();
        _healthView.Initialize();
    }
}