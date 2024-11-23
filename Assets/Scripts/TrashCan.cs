using System.Collections;
using UnityEngine;

public class TrashCan : MonoBehaviour
{
    public ScoreManager scoreManager;          // Referensi ke ScoreManager
    public GameObject feedbackTextPrefab;      // Prefab untuk teks feedback
    public Transform canvasTransform;          // Transform Canvas tempat teks ditampilkan
    public CameraShake cameraShake;            // Referensi ke CameraShake
    public AudioClip correctSound;             // Suara untuk jawaban benar
    public AudioClip wrongSound;               // Suara untuk jawaban salah
    private AudioSource audioSource;           // AudioSource untuk memutar efek suara

    void Start()
    {
        // Ambil komponen AudioSource
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource is missing on " + gameObject.name);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trash"))
        {
            string message = "";                // Pesan yang akan ditampilkan
            int points = 0;                     // Poin yang akan diupdate
            string trashType = other.gameObject.name;

            // Cek jenis sampah dan tong sampah
            if (gameObject.CompareTag("Yellow"))
            {
                if (trashType.Contains("Bottle") || trashType.Contains("PizzaBox") || trashType.Contains("SodaCan"))
                {
                    message = "Correct! +100";
                    points = 100;
                    PlaySound(correctSound); // Mainkan suara benar
                }
                else
                {
                    message = "Wrong! -50";
                    points = -50;
                    PlaySound(wrongSound); // Mainkan suara salah
                    StartCoroutine(cameraShake.Shake(0.3f, 0.2f)); // Panggil efek shake
                }
            }
            else if (gameObject.CompareTag("Blue"))
            {
                if (trashType.Contains("Apple"))
                {
                    message = "Correct! +100";
                    points = 100;
                    PlaySound(correctSound); // Mainkan suara benar
                }
                else
                {
                    message = "Wrong! -50";
                    points = -50;
                    PlaySound(wrongSound); // Mainkan suara salah
                    StartCoroutine(cameraShake.Shake(0.3f, 0.2f)); // Panggil efek shake
                }
            }

            // Update skor
            scoreManager.UpdateScore(points);

            // Tampilkan pesan feedback
            ShowFeedbackText(message, other.transform.position);

            // Hancurkan sampah setelah menunjukkan feedback
            Destroy(other.gameObject);
        }
    }

    void PlaySound(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip); // Mainkan suara sekali
        }
    }

    void ShowFeedbackText(string message, Vector3 worldPosition)
    {
        if (feedbackTextPrefab == null || canvasTransform == null)
        {
            Debug.LogWarning("Feedback Text Prefab or Canvas Transform is missing!");
            return;
        }

        // Buat teks feedback di canvas
        GameObject feedbackText = Instantiate(feedbackTextPrefab, canvasTransform);

        // Atur teks
        var textComponent = feedbackText.GetComponent<UnityEngine.UI.Text>();
        if (textComponent != null)
        {
            textComponent.text = message;
        }
        else
        {
            Debug.LogError("Feedback Text Prefab is missing a Text component!");
            Destroy(feedbackText);
            return;
        }

        // Konversi posisi dunia ke posisi layar
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(worldPosition);
        feedbackText.transform.position = screenPosition;

        // Hapus teks setelah 1.5 detik
        Destroy(feedbackText, 1.5f);
    }
}
