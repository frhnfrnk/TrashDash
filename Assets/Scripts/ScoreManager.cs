using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score = 0; // Variabel untuk menyimpan score
    public Text scoreText; // UI Text untuk menampilkan score

    // Fungsi untuk menambah skor
    public void AddScore(int points)
    {
        score += points; // Menambah score
        UpdateScoreUI(); // Memperbarui tampilan UI
    }

    // Fungsi untuk memperbarui tampilan score
    private void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score.ToString(); // Menampilkan score di UI
    }
}
