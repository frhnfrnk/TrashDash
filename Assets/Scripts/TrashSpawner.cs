using System.Collections;
using UnityEngine;

public class TrashSpawner : MonoBehaviour
{
    public GameObject[] trashPrefabs;  // Array untuk berbagai jenis sampah
    public float spawnInterval = 2f;   // Interval spawn (detik)
    public Transform spawnPoint;       // Titik posisi spawn yang sudah Anda tentukan
    private bool canSpawn = true;      // Status apakah bisa spawn

    void Start()
    {
        // Mulai Coroutine untuk spawn sampah dengan interval
        StartCoroutine(SpawnTrashWithDelay());
    }

    // Coroutine untuk spawn sampah setiap interval tertentu
    private IEnumerator SpawnTrashWithDelay()
    {
        while (true)  // Loop tak terbatas
        {
            if (canSpawn)
            {
                // Pilih secara acak prefab sampah dari array
                GameObject trashToSpawn = trashPrefabs[Random.Range(0, trashPrefabs.Length)];

                // Tentukan posisi spawn sesuai dengan posisi spawnPoint yang sudah Anda tentukan
                Vector3 spawnPosition = spawnPoint.position;

                // Spawn sampah pada posisi yang diinginkan
                Instantiate(trashToSpawn, spawnPosition, Quaternion.identity);

                // Set canSpawn ke false agar tidak spawn lebih cepat
                canSpawn = false;

                // Tunggu selama spawnInterval detik sebelum spawn lagi
                yield return new WaitForSeconds(spawnInterval);

                // Setelah interval selesai, izinkan spawn lagi
                canSpawn = true;
            }

            // Menunggu sebelum spawn lagi
            yield return null;
        }
    }
}
