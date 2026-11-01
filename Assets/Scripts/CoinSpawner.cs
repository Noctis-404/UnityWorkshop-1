using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public GameObject bombPrefab;
    public GameObject goldenCoinPrefab;

    public float spawnInterval = 0.8f;
    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnItem();
            timer = 0f;
        }
    }

    void SpawnItem()
    {
        float x = Random.Range(-8f, 8f);
        Vector3 spawnPos = new Vector3(x, 6f, 0);

        float chance = Random.Range(0f, 100f);
        GameObject objectToSpawn;

        if (chance < 70f) // 70% regular coin
        {
            objectToSpawn = coinPrefab;
        }
        else if (chance < 90f) // 20% bomb
        {
            objectToSpawn = bombPrefab;
        }
        else // 10% golden coin
        {
            objectToSpawn = goldenCoinPrefab;
        }

        if (objectToSpawn != null)
        {
            Instantiate(objectToSpawn, spawnPos, Quaternion.identity);
        }
    }
}