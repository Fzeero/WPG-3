using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 100;
    private KillCount killCounter; // Referensi ke skrip KillCount

    private void Start()
    {
        // Menemukan dan menyimpan referensi ke skrip KillCount di dalam scene
        killCounter = GameObject.FindObjectOfType<KillCount>();
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Memeriksa apakah skrip KillCount ada sebelum memanggil EnemyKilled()
        if (killCounter != null)
        {
            killCounter.EnemyKilled(); // Memanggil fungsi EnemyKilled() dari skrip KillCount
        }

        Destroy(gameObject);
    }
}
