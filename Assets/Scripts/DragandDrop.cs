using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragandDrop : MonoBehaviour
{
    private bool isDragging = false; // Apakah sedang di-drag
    private Vector3 offset;         // Offset saat drag
    private Vector3 screenPoint;    // Titik layar saat mouse pertama kali ditekan

    void OnMouseDown()
    {
        // Saat mouse klik pada objek, simpan posisi offset untuk drag
        screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        isDragging = true;
    }

    void OnMouseUp()
    {
        // Saat mouse dilepas, hentikan drag
        isDragging = false;
    }

    void Update()
    {
        if (isDragging)
        {
            // Menempatkan objek pada posisi baru berdasarkan posisi mouse
            Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 currentWorldPoint = Camera.main.ScreenToWorldPoint(currentScreenPoint) + offset;
            transform.position = currentWorldPoint;
        }
    }
}
