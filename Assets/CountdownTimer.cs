using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    public Text timerText;
    private float countdownTime = 300f; // Waktu awal 5 menit dalam detik
    private bool isTimerRunning = true;

    void Update()
    {
        if (isTimerRunning)
        {
            if (countdownTime > 0)
            {
                countdownTime -= Time.deltaTime;
                UpdateTimerUI();
            }
            else
            {
                isTimerRunning = false;
                countdownTime = 0;
                UpdateTimerUI();
                // Lakukan sesuatu saat timer mencapai 0, misalnya memunculkan pesan atau menghentikan permainan.
                Debug.Log("Waktu telah habis!");
            }
        }
    }

    void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(countdownTime / 60f);
        int seconds = Mathf.FloorToInt(countdownTime % 60f);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void PauseTimer()
    {
        isTimerRunning = false;
    }

    public void ResumeTimer()
    {
        isTimerRunning = true;
    }

    public void ResetTimer()
    {
        countdownTime = 300f;
        isTimerRunning = true;
        UpdateTimerUI();
    }
}
