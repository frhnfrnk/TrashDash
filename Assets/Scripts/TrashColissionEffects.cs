using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCollisionEffect : MonoBehaviour
{
    public ParticleSystem collisionEffect; // Drag particle system ke sini di Inspector

    // Ini untuk mendeteksi tabrakan
    void OnCollisionEnter(Collision collision)
    {
        // Cek apakah tabrakan terjadi dengan lantai atau permukaan lainnya
        if (collision.gameObject.CompareTag("Ground"))  // Pastikan lantai memiliki tag "Ground"
        {
            // Aktifkan efek partikel
            collisionEffect.Play();

            // Anda bisa menambahkan efek lainnya, seperti suara atau animasi
            Debug.Log("Sampah jatuh ke lantai!");
        }
    }
}
