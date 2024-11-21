using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePizza : MonoBehaviour
{
    public float speed = 5f; // Kecepatan gerakan horizontal
    public float fallSpeed = 5f; // Kecepatan jatuh vertikal
    public float boundaryX = 25f; // Batas kanan conveyor
    public float groundY = 0.6f; // Posisi Y lantai
    public float rotationSpeed = 200f; // Kecepatan rotasi saat jatuh
    private bool isFalling = false; // Status apakah sampah sedang jatuh
    private bool onGround = false; // Status apakah sudah di lantai

    private Quaternion targetRotation; // Rotasi target untuk berbaring

    void Start()
    {
        // Rotasi target untuk posisi berbaring (90 derajat)
        targetRotation = Quaternion.Euler(0f, 0f, -90f);
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

            // Cek jika mencapai lantai
            if (transform.position.y <= groundY)
            {
                // Pastikan posisi botol di lantai
                transform.position = new Vector3(transform.position.x, groundY, transform.position.z);

                // Tetapkan status bahwa botol sudah di lantai
                onGround = true;
            }
        }
        else
        {
            // Botol di lantai, berhenti bergerak
            // Pastikan posisi tetap (tidak bergerak ke negatif tak hingga)
            transform.position = new Vector3(transform.position.x, groundY, transform.position.z);

            // Lanjutkan rotasi jika belum selesai
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
