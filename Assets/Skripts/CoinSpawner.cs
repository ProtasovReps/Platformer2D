using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;

    private Coin _coin;
    private float _spawnDelay = 10f;

    private void Start() => SpawnCoinsDelayed();

    private void SpawnCoinsDelayed()
    {
        InvokeRepeating(nameof(SpawnCoinAtRandomPoint), 0f, _spawnDelay);
    }

    private void SpawnCoinAtRandomPoint()
    {
        float positionY = transform.position.y + 1.5f;

        if (_coin == null)
            _coin = Instantiate(_coinPrefab);

        _coin.gameObject.SetActive(true);
        _coin.transform.position = new Vector2(GetRandomPositionX(), positionY);
    }

    private float GetRandomPositionX()
    {
        float startPoint = transform.position.x - (transform.lossyScale.x / 2);
        float endPoint = transform.position.x + (transform.lossyScale.x / 2);

        return Random.Range(startPoint, endPoint);
    }
}
