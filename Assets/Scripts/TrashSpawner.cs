using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrashSpawner : MonoBehaviour
{
    public GameObject[] trashPrefabs; // Array prefab sampah
    public Transform spawnPoint;      // Titik awal spawn
    public float spawnInterval = 2f;  // Interval spawn normal
    public float waveSpawnInterval = 0.7f; // Interval antar spawn saat wave
    public int waveTrashCount = 20;   // Total jumlah sampah dalam wave
    public float waveDuration = 30f;  // Durasi wave dalam detik
    public float gameDuration = 120f; // Durasi total game dalam detik
    public Text waveText;
    public GameObject pauseScreen;    // Reference to Pause Screen UI

    private bool isSpawning = true;   // Status apakah sedang spawn
    private bool inWave = false;      // Status apakah sedang dalam wave
    private float gameTimer = 0f;     // Timer untuk melacak waktu game
    private bool isPaused = false;    // Status apakah game dalam kondisi pause

    void Start()
    {
        waveText.gameObject.SetActive(false);
        pauseScreen.SetActive(false); // Ensure the pause screen is hidden
        StartCoroutine(SpawnTrash());
    }

    void Update()
    {
        if (isPaused)
            return;

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
        waveText.gameObject.SetActive(true); // Show wave text
        yield return new WaitForSeconds(2f); // Display the text for 2 seconds
        waveText.gameObject.SetActive(false); // Hide wave text
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

    public void TogglePauseGame()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0 : 1; // Pause or resume game
        pauseScreen.SetActive(isPaused); // Show or hide the pause screen
    }
    
    public void ContinueGame()
    {
        isPaused = false;
        Time.timeScale = 1;             // Resume the game
        pauseScreen.SetActive(false);   // Hide the pause screen
    }
}
