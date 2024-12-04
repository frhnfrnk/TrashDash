using UnityEngine;

public class FeedbackManager : MonoBehaviour
{
    public static FeedbackManager Instance; // Singleton instance
    public GameObject feedbackTextPrefab; // Prefab untuk teks feedback
    public Transform canvasTransform; // Transform canvas untuk feedback

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this; // Tetapkan instance
        }
        else
        {
            Destroy(gameObject); // Hapus jika sudah ada instance lain
        }
    }

    public void ShowFeedbackText(string message, Vector3 worldPosition, Color textColor)
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
            textComponent.color = textColor;
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
