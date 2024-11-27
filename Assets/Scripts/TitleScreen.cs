using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    void Update()
    {
        // Deteksi input tombol apa pun untuk memulai game
        if (Input.anyKeyDown)
        {
            StartGame();
        }
    }

    void StartGame()
    {
        // Load scene berikutnya (main gameplay)
        SceneManager.LoadScene("MainMenu");
    }
}

