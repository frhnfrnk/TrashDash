using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBottle : MonoBehaviour
{
    public float speed = 5f; // Kecepatan gerakan horizontal
    public float fallSpeed = 5f; // Kecepatan jatuh vertikal
    public float boundaryX = 20f; // Batas kanan conveyor
    public float groundY = 0.6f; // Posisi Y lantai
    public float rotationSpeed = 200f; // Kecepatan rotasi saat jatuh
    private bool isFalling = false; // Status apakah sampah sedang jatuh
    private bool onGround = false; // Status apakah sudah di lantai

    public int penaltyPoints = -50; // Poin yang dikurangi saat jatuh
    public float destroyDelay = 1.5f; // Waktu tunda sebelum objek dihapus
    public AudioClip fallSound; // Efek suara saat jatuh (opsional)

    private AudioSource audioSource; // Komponen AudioSource
    private Quaternion targetRotation; // Rotasi target untuk berbaring
    private ScoreManager scoreManager; // Referensi ke ScoreManager

    void Start()
    {
        // Rotasi target untuk posisi berbaring (90 derajat)
        targetRotation = Quaternion.Euler(0f, 0f, -90f);

        // Ambil AudioSource jika ada
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource is missing on " + gameObject.name);
        }


        // Cari ScoreManager di scene
        scoreManager = FindObjectOfType<ScoreManager>();
        if (scoreManager == null)
        {
            Debug.LogError("ScoreManager not found in the scene!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            Debug.Log("Bottle touched the ground!");
            HandleFall();
        }
    }

    void Update()
    {
        if (!isFalling)
        {
            // Gerakan horizontal
            transform.Translate(Vector3.right * speed * Time.deltaTime);

            // Cek apakah mencapai batas kanan
            if (transform.position.x >= boundaryX)
            {
                isFalling = true; // Aktifkan mode jatuh
            }
        }
        else if (!onGround)
        {
            // Gerakan jatuh vertikal
            transform.Translate(Vector3.right * fallSpeed * Time.deltaTime);

            // Rotasi objek secara bertahap
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    void HandleFall()
    {
        // Kurangi poin melalui ScoreManager
        Debug.Log("HandleFall called!");
        if (scoreManager != null)
        {
            scoreManager.UpdateScore(penaltyPoints);
        }
        FeedbackManager.Instance.ShowFeedbackText(
            "Penalty: -50",
            transform.position,
            Color.red // Warna teks merah untuk penalti
        );

        // Mainkan efek suara jika ada
        if (audioSource != null && fallSound != null)
        {
            audioSource.PlayOneShot(fallSound);
        }

        // Hancurkan objek setelah delay
        Destroy(gameObject, destroyDelay);
    }
}
