using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GeneralGameManager : MonoBehaviour
{
    public GameObject nivelCompletadoUI, pauseMenu, dialogo, coinCounter;
    public GameObject nivelCompletado;
    int currentCoins = 50;
    public TMP_Text coinCounterText, timerFinal;

    public GameObject m1,m2,m3,m4,m5,m6,m7,m8,m9,m10,m11,m12,m13,m14;

    void Awake()
    {
        nivelCompletado.SetActive(false);
        nivelCompletadoUI.SetActive(false);
        pauseMenu.SetActive(false);


        currentCoins = 100; UpdateCoinCounter();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            //confeti 
            nivelCompletado.SetActive(true);
            PauseTimer();

            
            timerFinal.text = FormatTime(timeElapsed);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            //ganaste 
            nivelCompletadoUI.SetActive(true);

            currentCoins = currentCoins + 50;
            UpdateCoinCounter();
        }

        if (Input.GetMouseButtonDown(0))
        {
            //UpdateCoinCounter();
        }
    }
    void UpdateCoinCounter()
    {
        //currentCoins++;
        coinCounterText.text = currentCoins.ToString();
    }

    public TMP_Text timerText; // Assign in the Inspector
    private float timeElapsed;
    private bool isPaused;

    void Start()
    {
        timeElapsed = 0f;
        isPaused = false;
        StartCoroutine(Timer());
    }

    private IEnumerator Timer()
    {
        while (true)
        {
            if (!isPaused)
            {
                timeElapsed += Time.deltaTime;
                UpdateTimerText();
            }
            yield return null;
        }
    }

    private void UpdateTimerText()
    {
        // Display the timer in minutes:seconds format
        timerText.text = FormatTime(timeElapsed);
    }

    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void PauseTimer()
    {
        isPaused = !isPaused; // Toggle pause state
    }
}
