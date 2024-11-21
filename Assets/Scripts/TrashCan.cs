using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : MonoBehaviour
{
    public ScoreManager scoreManager;  // Referensi ke ScoreManager
    private bool isColliding = false;  // Untuk mengecek apakah objek berada dalam trigger

    void OnTriggerEnter(Collider other)
    {
        // Mengecek jika objek yang masuk adalah sampah dan berada dalam trigger
        if (other.CompareTag("Trash"))
        {
            // Cek tag dari tong sampah
            if (gameObject.CompareTag("Yellow"))
            {
                // Jika sampah masuk ke tong sampah kuning, tambah 100 poin
                scoreManager.AddScore(100);
                Destroy(other.gameObject);
                Debug.Log("Trash added to Yellow Can! +100 Points");
            }
            else if (gameObject.CompareTag("Red"))
            {
                // Jika sampah masuk ke tong sampah merah, kurangi 59 poin
                scoreManager.AddScore(-50);
                Destroy(other.gameObject);
                Debug.Log("Trash added to Red Can! -50 Points");
            }
        }
    }
}
