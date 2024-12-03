using UnityEngine;

public class Spinner : MonoBehaviour
{
    public float rotationSpeed = 30f;

    private void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}