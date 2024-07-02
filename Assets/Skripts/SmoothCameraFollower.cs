using UnityEngine;

public class SmoothCameraFollower : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _followSpeed;

    private void Update() => FollowSmoothly();

    private void FollowSmoothly()
    {
        var targetPosition = new Vector3(_target.position.x, _target.position.y, transform.position.z);
        
        transform.position = Vector3.Lerp(transform.position, targetPosition, _followSpeed * Time.deltaTime);
    }
}
