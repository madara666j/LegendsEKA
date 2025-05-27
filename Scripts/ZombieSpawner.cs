using System.Collections;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField] private GameObject zombiePrefab;
    [SerializeField] private Transform player;
    [SerializeField] private float spawnInterval = 15f;
    [SerializeField] private Transform[] spawnPoints;

    private void Start()
    {
        StartCoroutine(SpawnZombies());
    }

    private IEnumerator SpawnZombies()
    {
        while (true)
        {
            SpawnZombie();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnZombie()
    {
        if (spawnPoints.Length == 0) return;

        // Choose a random spawn point
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // Spawn the zombie
        GameObject zombie = Instantiate(zombiePrefab, spawnPoint.position, spawnPoint.rotation);

        // Set the player target for the new zombie
        EnemyController controller = zombie.GetComponent<EnemyController>();
        if (controller != null)
            controller.player = player;

        EnemyNavigation navigation = zombie.GetComponent<EnemyNavigation>();
        if (navigation != null)
            navigation.target = player;
    }
}
