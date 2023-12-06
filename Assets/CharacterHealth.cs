using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CharacterHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    public Slider healthSlider; // Reference ke UI Slider untuk health bar
    public GameObject gameOverPanel; // Reference ke panel Game Over dalam UI
    public UnityEvent onHealthChanged; // Event untuk memberitahukan perubahan pada health

    private bool isDead = false; // Menandakan apakah karakter sudah mati atau belum

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI(); // Memperbarui UI Health pada awal permainan
        HideGameOverUI(); // Menyembunyikan panel Game Over saat permainan dimulai
    }

    public void TakeDamage(int damageAmount)
    {
        if (!isDead)
        {
            currentHealth -= damageAmount;
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

            UpdateHealthUI(); // Memperbarui UI Health setelah menerima damage

            if (currentHealth <= 0)
            {
                Die();
            }
        }
    }

    private void Die()
    {
        isDead = true;
        ShowGameOverUI(); // Menampilkan panel Game Over saat karakter mati
        Time.timeScale = 0f; // Menghentikan waktu permainan saat karakter mati
        // Tindakan lain yang ingin Anda lakukan saat karakter mati, jika ada
        Debug.Log("Karakter telah mati!");
    }

    private void UpdateHealthUI()
    {
        if (healthSlider != null)
        {
            healthSlider.value = (float)currentHealth / maxHealth; // Mengatur nilai UI Slider sesuai health karakter
            onHealthChanged.Invoke(); // Memanggil event untuk memberitahukan perubahan health
        }
    }

    private void ShowGameOverUI()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true); // Menampilkan panel Game Over
        }
    }

    private void HideGameOverUI()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false); // Menyembunyikan panel Game Over
        }
    }
}
