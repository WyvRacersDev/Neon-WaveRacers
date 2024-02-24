using UnityEngine;
using TMPro;
public class drift_management : MonoBehaviour
{
    public float timeLimit = 60f;
    private float currentTime = 0f;
    public bool isEventActive = false; 
    public int driftPoints = 0;

    public GameObject timer;
    public GameObject score;
    public GameObject trigger;
    public TextMeshProUGUI timer_text;
    public TextMeshProUGUI score_text;
    public TextMeshProUGUI highscore_text;
    public int highscore = 0;

    public GameObject arrow_gps;

    public Progress_Managements Progress_Managements;



    private void Start()
    {
        Progress_Managements = GameObject.Find("saveManager").GetComponent<Progress_Managements>();
        highscore = PlayerPrefs.GetInt("DRIFT", 5000);

    }

    void Update()
    {
        if (isEventActive)
        {
            // Update the current time elapsed
           
            score_text.text = "Score: "+driftPoints.ToString();
            currentTime += Time.deltaTime;

            int minutes = (int)(currentTime / 60);
            int seconds = (int)(currentTime % 60);
            int milliseconds = (int)((currentTime * 1000) % 1000);
            timer_text.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);

            // Check if time limit exceeded
            if (currentTime >= timeLimit)
            {
                EndDriftEvent();
            }
        }

    }

    public void AddDriftPoints()
    {
        driftPoints++;
    }

    public void StartDriftEvent()
    {
        arrow_gps.SetActive(false);
        isEventActive = true;
        currentTime = 0f;
        driftPoints = 0;
        highscore_text.text ="Record: "+highscore.ToString();
        score.SetActive(true);
        timer.SetActive(true);
    }

    void EndDriftEvent()
    {
        // End the drift event
        int temp = PlayerPrefs.GetInt("progress");
        isEventActive = false;
        // Additional logic such as calculating rewards, displaying results, etc.
        Debug.Log("Drift event ended. Drift Points: " + driftPoints);

        if(highscore<driftPoints) 
        {
            highscore=driftPoints;
            PlayerPrefs.SetInt("DRIFT", driftPoints);
        }

        if (temp == 4)
        {
            PlayerPrefs.SetInt("progress", temp + 1);
            PlayerPrefs.Save();
            Progress_Managements.progress++;
            Progress_Managements.dialoguecall();
        }
       
        timer_text.text = "0";
        score_text.text = "0";
        arrow_gps.SetActive(true);
        trigger.SetActive(true);
        timer.SetActive(false);
        score.SetActive(false);
        
        // You can add more actions such as displaying results, resetting the scene, etc.
    }
}
