using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float timeScale = 0.5f; // S�reyi yava�latmak i�in kullan�lan katsay�

    void Update()
    {
        if (TimerManager.Instance.isRunning)
        {
            TimerManager.Instance.elapsedTime += Time.deltaTime * timeScale; // Zaman� g�ncelle ve yava�lat

            // 1.5 dakika = 90 saniye
            if (TimerManager.Instance.elapsedTime >= 90f)
            {
                TimerManager.Instance.isRunning = false; // Saya� durduruluyor
                TimerManager.Instance.elapsedTime = 90f; // Zaman� tam olarak 90 saniyede durduruyoruz
                QuitGame(); // Oyunu kapat
            }

            int minute = Mathf.FloorToInt(TimerManager.Instance.elapsedTime / 60);
            int seconds = Mathf.FloorToInt(TimerManager.Instance.elapsedTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minute, seconds);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            TimerManager.Instance.isRunning = !TimerManager.Instance.isRunning; // Saya� durumu de�i�tirilir
        }
    }

    void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false; // Unity Editor'da oyunu durdur
#else
            Application.Quit(); // Derlenmi� oyunu kapat
#endif
    }
}
