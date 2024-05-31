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
    [SerializeField] float timeScale = 0.5f; // Süreyi yavaþlatmak için kullanýlan katsayý

    void Update()
    {
        if (TimerManager.Instance.isRunning)
        {
            TimerManager.Instance.elapsedTime += Time.deltaTime * timeScale; // Zamaný güncelle ve yavaþlat

            // 3 dakika = 180 saniye
            if (TimerManager.Instance.elapsedTime >= 180f)
            {
                TimerManager.Instance.isRunning = false; // Sayaç durduruluyor
                TimerManager.Instance.elapsedTime = 180f; // Zamaný tam olarak 180 saniyede durduruyoruz
                QuitGame(); // Oyunu kapat
            }

            int minute = Mathf.FloorToInt(TimerManager.Instance.elapsedTime / 60);
            int seconds = Mathf.FloorToInt(TimerManager.Instance.elapsedTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minute, seconds);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            TimerManager.Instance.isRunning = !TimerManager.Instance.isRunning; // Sayaç durumu deðiþtirilir
        }
    }

    void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false; // Unity Editor'da oyunu durdur
#else
            Application.Quit(); // Derlenmiþ oyunu kapat
#endif
    }
}
