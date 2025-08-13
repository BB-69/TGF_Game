using System;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject pasueMenuUi  , pauseButton , resumeButton;
    public Boolean isPaused = false;

    
    public void Paused()
    {
        pasueMenuUi.SetActive(true);
        pauseButton.SetActive(false);
        resumeButton.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
    public void Resume()
    {
        pasueMenuUi.SetActive(false);
        pauseButton.SetActive(true);
        resumeButton.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

   

}
