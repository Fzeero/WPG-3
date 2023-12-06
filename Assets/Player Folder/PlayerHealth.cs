using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // Kesehatan maksimum pemain
    private int currentHealth; // Kesehatan saat ini pemain

    private void Start()
    {
        currentHealth = maxHealth; // Mengatur kesehatan awal pemain
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Mengurangi kesehatan pemain sejumlah kerusakan

        if (currentHealth <= 0)
        {
            Die(); // Jika kesehatan pemain habis, panggil metode Die()
        }
    }

    private void Die()
    {
        // Lakukan tindakan yang sesuai ketika pemain mati, misalnya, menampilkan pesan kematian atau mereset permainan
        // Anda dapat menyesuaikan tindakan sesuai kebutuhan permainan Anda.
        Debug.Log("Player mati!");
        // Contoh: GameManager.Instance.GameOver();
    }
}
