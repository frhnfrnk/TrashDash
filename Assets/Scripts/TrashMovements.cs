using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashMovements : MonoBehaviour
{
    public float moveForce = 5f;  // Gaya untuk gerakan sampah
    public float rotationForce = 50f;  // Gaya rotasi untuk efek putaran
    private Rigidbody rb;

    void Start()
    {
        // Ambil komponen Rigidbody pada sampah
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        // Saat sampah bertabrakan, terapkan gaya untuk pergerakan dan rotasi
        if (collision.gameObject.CompareTag("Ground"))
        {
            // Terapkan gaya ke sampah untuk membuatnya bergerak
            Vector3 forceDirection = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized;
            rb.AddForce(forceDirection * moveForce, ForceMode.Impulse);  // Gaya gerakan

            // Terapkan gaya rotasi untuk efek putaran
            rb.AddTorque(new Vector3(Random.Range(-1f, 1f), 1f, Random.Range(-1f, 1f)) * rotationForce, ForceMode.Impulse);  // Gaya rotasi
        }
    }
}
