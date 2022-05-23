using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class SpawnZone : MonoBehaviour
{
    /// <summary>
    /// Enemy to spawn
    /// </summary>
    [SerializeField]
    private GameObject enemy;

    /// <summary>
    /// Walking direction from this spawn
    /// </summary>
    [SerializeField]
    private Vector3 direction;

    [SerializeField]
    private float spawnFrequency;

    /// <summary>
    /// Boundaries of the spawn zone
    /// </summary>
    private Bounds bounds;

    void Start()
    {
        bounds = GetComponent<BoxCollider>().bounds;
    }

    /// <summary>
    /// Spawn enemies until the coroutines are stopped
    /// </summary>
    /// <returns></returns>
    private IEnumerator SpawnAsync()
    {
        while(true)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnFrequency);
        }
    }

    /// <summary>
    /// Start to spawn
    /// </summary>
    public void StartSpawn()
    {
        StartCoroutine(SpawnAsync());
    }

    /// <summary>
    /// Stop spawning
    /// </summary>
    public void StopSpawn()
    {
        StopAllCoroutines();
    }

    /// <summary>
    /// Make one enemy spawn
    /// </summary>
    public void SpawnEnemy()
    {
        // Simple random spawn position in bounds
        float randX = Random.Range(bounds.min.x, bounds.max.x);
        float randY = Random.Range(bounds.min.y, bounds.max.y);
        float randZ = Random.Range(bounds.min.z, bounds.max.z);

        GameObject enemyInstance = Instantiate(enemy, new Vector3(randX, randY, randZ), Quaternion.identity);

        enemyInstance.transform.forward = direction;
    }
}
