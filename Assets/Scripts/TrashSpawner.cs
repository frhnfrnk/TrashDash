using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSpawner : MonoBehaviour
{
    public GameObject[] trashPrefabs; // Array prefab sampah
    public Transform spawnPoint;      // Titik awal spawn
    public float spawnInterval = 2f;  // Interval spawn normal
    public float waveSpawnInterval = 1.5f; // Interval antar spawn saat wave
    public int waveTrashCount = 20;   // Total jumlah sampah dalam wave
    public float waveDuration = 30f;  // Durasi wave dalam detik
    public float gameDuration = 120f; // Durasi total game dalam detik

    private bool isSpawning = true;   // Status apakah sedang spawn
    private bool inWave = false;      // Status apakah sedang dalam wave
    private float gameTimer = 0f;     // Timer untuk melacak waktu game

    void Start()
    {
        StartCoroutine(SpawnTrash());
    }

    void Update()
    {
        // Perbarui timer game
        gameTimer += Time.deltaTime;

        // Mulai wave jika gameTimer mencapai 1 menit
        if (gameTimer >= 20f && gameTimer < 20f + waveDuration && !inWave)
        {
            StartCoroutine(SpawnWave());
        }

        // Hentikan spawning jika waktu game selesai
        if (gameTimer >= gameDuration)
        {
            StopSpawning();
        }
    }

    IEnumerator SpawnTrash()
    {
        while (isSpawning)
        {
            if (!inWave) // Spawn normal jika tidak dalam wave
            {
                Spawn();
                yield return new WaitForSeconds(spawnInterval);
            }
            else
            {
                yield return null; // Tunggu jika dalam wave
            }
        }
    }

    IEnumerator SpawnWave()
    {
        inWave = true;
        int spawnedCount = 0;

        while (spawnedCount < waveTrashCount)
        {
            Spawn();
            spawnedCount++;
            yield return new WaitForSeconds(waveSpawnInterval);
        }

        inWave = false;
    }

    void Spawn()
    {
        int index = Random.Range(0, trashPrefabs.Length);
        Instantiate(trashPrefabs[index], spawnPoint.position, Quaternion.identity);
    }

    public void StopSpawning()
    {
        isSpawning = false;
    }
}
