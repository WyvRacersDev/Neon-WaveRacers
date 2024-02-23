using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class TimeTrialManagement : MonoBehaviour
{
    public int arrow_index=-1;
    public GameObject[] arrows;
    public GameObject trigger;
    public GameObject finish;


    public GameObject timer;
    public TextMeshProUGUI timerText;
    private float startTime;
    private bool isTimerRunning = false;

    public GameObject arrow_gps;

    public Transform player_spawn;
  
    void Update()
    {
        // Update the timer if it's running
        if (isTimerRunning)
        {

            arrow_gps.SetActive(false);
            float elapsedTime = Time.time - startTime;
            UpdateTimerText(elapsedTime);

            for (int i = 0; i < arrows.Length; i++)
            {
                if (i == arrow_index)
                {
                    arrows[i].gameObject.SetActive(true);

                }
                else
                    arrows[i].gameObject.SetActive(false);

                if (arrow_index > 6)
                    finish.SetActive(true);
                else
                    finish.SetActive(false);
            }
        }

    }

    public void StartTimer(Transform playr)
    {
        // Initialize the timer
        playr.transform.position = player_spawn.position;
        playr.transform.rotation = player_spawn.rotation;

        arrow_index = 0;
        timer.SetActive(true);
        startTime = Time.time;
        isTimerRunning = true;

    }

    void UpdateTimerText(float elapsedTime)
    {
        // Update the timer display
        int minutes = (int)(elapsedTime / 60);
        int seconds = (int)(elapsedTime % 60);
        int milliseconds = (int)((elapsedTime * 1000) % 1000);
        timerText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
    }

    
   public void finish_trial()
    {
        isTimerRunning = false;

        DisplayFinishTime();

        SceneManager.LoadScene("Garage");

        arrow_gps.SetActive(true);
    }
    

    void DisplayFinishTime()
    {
        // Get the elapsed time
        float elapsedTime = Time.time - startTime;

        // Update the timer text to display the final time
        UpdateTimerText(elapsedTime);

        // Optionally, you can provide feedback to the player about their completion time
        Debug.Log("Time trial completed! Your time: " + timerText.text);

        StartCoroutine("endtrial");

        arrow_index = -1;


    }


    IEnumerator endtrial()
    {
        yield return new WaitForSeconds(5);
        timerText.SetActive(false);
        trigger.SetActive(true);
       



    }
}
