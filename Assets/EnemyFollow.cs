using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform target; // Referensi ke Transform karakter utama (player)
    public float moveSpeed = 3f; // Kecepatan gerak musuh

    private void Update()
    {
        if (target != null)
        {
            // Hitung arah gerak menuju karakter utama
            Vector3 direction = (target.position - transform.position).normalized;

            // Gerakkan musuh ke arah karakter utama dengan kecepatan tertentu
            transform.Translate(direction * moveSpeed * Time.deltaTime);
        }
    }
}
