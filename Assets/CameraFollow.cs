using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Transform pemain yang akan diikuti
    public Vector3 offset = new Vector3(0f, 10f, -10f); // Jarak dan posisi relatif kamera terhadap pemain
    public float smoothSpeed = 0.125f; // Kecepatan pergerakan kamera

    private void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;

            // Menggunakan Lerp untuk pergerakan yang halus
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;

            transform.LookAt(target.position); // Kamera selalu menghadap pemain
        }
    }
}
