using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSpawner : MonoBehaviour
{
    public GameObject[] trashPrefabs; // Array prefab sampah
    public Transform spawnPoint;      // Titik awal spawn
    public float spawnInterval = 2f;  // Interval spawn
    private bool isSpawning = true;   // Status apakah sedang spawn

    void Start()
    {
        // Mulai coroutine untuk spawn sampah
        StartCoroutine(SpawnTrash());
    }

    IEnumerator SpawnTrash()
    {
        while (isSpawning)
        {
            // Spawn sampah baru
            Spawn();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void Spawn()
    {
        // Pilih sampah acak dari array
        int index = Random.Range(0, trashPrefabs.Length);
        Instantiate(trashPrefabs[index], spawnPoint.position, Quaternion.identity);
    }

    public void StopSpawning()
    {
        // Hentikan proses spawn
        isSpawning = false;
    }
}
