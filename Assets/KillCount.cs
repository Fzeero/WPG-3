using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class KillCount : MonoBehaviour
{
    public int maxEnemies = 25;
    private int currentEnemiesKilled = 0;

    public Text killCountText; // Referensi ke UI Text untuk menampilkan kill count

    private void Start()
    {
        UpdateKillCountUI(); // Memperbarui UI Text pada awal permainan
    }

    public void EnemyKilled()
    {
        currentEnemiesKilled++;

        UpdateKillCountUI(); // Memperbarui UI Text setelah setiap musuh mati

        if (currentEnemiesKilled >= maxEnemies)
        {
            ProceedToNextScene();
        }
    }

    private void ProceedToNextScene()
    {
        SceneManager.LoadScene("SceneName");
    }

    private void UpdateKillCountUI()
    {
        // Memperbarui teks pada UI Text untuk menampilkan jumlah musuh yang terbunuh
        if (killCountText != null)
        {
            killCountText.text = "Killed: " + currentEnemiesKilled + " / " + maxEnemies;
        }
    }
}