using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float currentTimer;
    public float startTimer = 120;
    public int savon1Count = 0;
    public TMP_Text timer;
    private bool isTimerRunning = false;
    public portail3D portail3D;
    public static GameManager Instance { get; private set; }

    public void Awake(){
        if (Instance  != null && Instance != this)
        {
            Debug.LogError("Une autre instance de PlayerController3d existe déjà !");
            Destroy(gameObject); // Évite les doublons
            return;
        }

        Instance = this;
    }

    public void IncrementTimer(float increment){
        currentTimer+=increment;
        UpdateTimerText();
    }

    void Start()
    {
        currentTimer = startTimer;
        UpdateTimerText();
        StartTimer();
    }   

    private void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(currentTimer / 60f);
        int seconds = Mathf.FloorToInt(currentTimer % 60f);
        timer.text = $"{minutes:00}:{seconds:00}";
    }

    // Update is called once per frame
    void Update()
    {
        if (isTimerRunning)
        {
            // Diminue le temps restant
            currentTimer -= Time.deltaTime;

            // Si le timer atteint zéro, arrête-le
            if (currentTimer <= 0)
            {
                currentTimer = 0;
                StopTimer();
            }

            // Met à jour le texte de l'UI
            UpdateTimerText();
        }
    }

    public void StopTimer()
    {
        isTimerRunning = false;
    }

    public void StartTimer()
    {
        isTimerRunning = true;
    }
}
