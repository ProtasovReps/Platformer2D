using System.Collections;
using UnityEngine;

public class WorldStatView : MonoBehaviour
{
    [SerializeField] private StatView _statView;
    [SerializeField] private float _followSpeed;
    [SerializeField] private Transform _targetPoint;

    private void Update()
    {
        transform.position = _targetPoint.position;
    }

    public void Initialize(IRangeable rangeable, Transform targetPoint)
    {
        _statView.Initialize(rangeable);
        _targetPoint = targetPoint;
    }
}
