using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefabs;
    public float spawnRate = 1.5f;
    public float spawnRadius = 5f;
    private float spawnTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.GameOver())
        {
            if (GameManager.instance.GetScore() % 10 == 0 && GameManager.instance.GetScore() != 0)
            {
                spawnRate -= Time.deltaTime / 10;
            }
            spawnTimer += Time.deltaTime;
            if (spawnTimer >= spawnRate)
            {
                SpawnEnemy();
                spawnTimer = 0f;
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }
    void SpawnEnemy()
    {
        Vector2 randomPosition = (Vector2)transform.position + Random.insideUnitCircle.normalized * spawnRadius;
        Instantiate(enemyPrefabs, randomPosition, Quaternion.identity);
    }
}
