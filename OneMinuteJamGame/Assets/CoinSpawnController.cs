using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawnController : MonoBehaviour
{
    [SerializeField] GameObject coin;
    [SerializeField] float minX, maxX, minY, maxY;

    private void Awake()
    {
        CoinPicker.OnCollect += SpawnCoin;
    }

    private void OnDestroy()
    {
        CoinPicker.OnCollect -= SpawnCoin;
    }

    private void Start()
    {
        SpawnCoin();
    }

    void SpawnCoin()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        Vector3 randomSpawn = new Vector3(randomX, randomY, 0);
        GameObject coinClone = Instantiate(coin);
        coinClone.transform.position = randomSpawn;
    }
}
