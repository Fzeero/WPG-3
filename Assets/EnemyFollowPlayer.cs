using UnityEngine;

public class EnemyFollowPlayer : MonoBehaviour
{
    public float movementSpeed = 3.0f; // Kecepatan gerakan musuh
    private Transform target; // Referensi ke karakter utama yang akan diikuti

    private void Update()
    {
        if (target != null)
        {
            // Menggerakkan musuh ke arah karakter utama
            Vector3 direction = (target.position - transform.position).normalized;
            transform.position += direction * movementSpeed * Time.deltaTime;

            // Rotasi musuh ke arah karakter utama
            transform.LookAt(target);
        }
    }

    public void SetTarget(Transform newTarget)
    {
        // Method ini digunakan untuk mengatur karakter utama yang akan diikuti oleh musuh
        target = newTarget;
    }
}
