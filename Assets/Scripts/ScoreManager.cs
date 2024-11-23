using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;  // UI teks untuk skor
    public Text timerText;  // UI teks untuk timer
    private int score = 0;  // Nilai skor
    private float gameTime = 120f; // Waktu permainan dalam detik (2 menit)
    private bool isGameOver = false;

    void Update()
    {
        if (!isGameOver)
        {
            // Kurangi waktu setiap frame
            gameTime -= Time.deltaTime;

            // Perbarui UI Timer
            timerText.text = "Time: " + Mathf.Ceil(gameTime).ToString();

            // Akhiri permainan jika waktu habis
            if (gameTime <= 0f)
            {
                isGameOver = true;
                gameTime = 0f; // Pastikan waktu tidak negatif
                Debug.Log("Game Over!");
                EndGame();
            }
        }
    }

    public void UpdateScore(int points)
    {
        if (!isGameOver)
        {
            // Tambahkan atau kurangi skor
            score += points;
            scoreText.text = "Score: " + score.ToString();
        }
    }

    private void EndGame()
    {
        // Logika ketika permainan selesai
        Debug.Log("Final Score: " + score);
        // Tambahkan logika lain, seperti menampilkan layar akhir permainan
    }
}
