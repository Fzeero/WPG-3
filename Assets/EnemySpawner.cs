using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab musuh yang akan di-spawn
    public float spawnRate = 2.0f; // Tingkat spawn (musuh per detik)
    public GameObject spawnArea; // GameObject yang mewakili area spawn musuh
    public int enemyHealth = 100; // Health Point (HP) musuh

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            Vector3 randomSpawnPosition = GetRandomSpawnPosition();

            GameObject newEnemy = Instantiate(enemyPrefab, randomSpawnPosition, Quaternion.identity);

            // Pastikan komponen EnemyHealth sudah ada pada prefab musuh, lalu atur propertinya
            EnemyHealth enemyHealthComponent = newEnemy.GetComponent<EnemyHealth>();
            if (enemyHealthComponent != null)
            {
                enemyHealthComponent.health = enemyHealth; // Set HP musuh
            }
            else
            {
                Debug.LogError("Komponen EnemyHealth tidak ditemukan pada prefab musuh.");
            }

            yield return new WaitForSeconds(1.0f / spawnRate);
        }
    }

    private Vector3 GetRandomSpawnPosition()
    {
        Vector3 spawnAreaSize = spawnArea.transform.localScale;

        float randomX = Random.Range(-spawnAreaSize.x / 2f, spawnAreaSize.x / 2f);
        float randomZ = Random.Range(-spawnAreaSize.z / 2f, spawnAreaSize.z / 2f);

        Vector3 randomSpawnPosition = spawnArea.transform.position + new Vector3(randomX, 0f, randomZ);

        return randomSpawnPosition;
    }
}
