using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class race_finish : MonoBehaviour
{
    // Start is called before the first frame update

    RaceManager raceManager;
    Progress_Managements Progress_Managements;
    private void Awake()
    {
        raceManager = GameObject.Find("GameController").GetComponent<RaceManager>();
        Progress_Managements=GameObject.Find("saveManager").GetComponent<Progress_Managements>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!other.GetComponent<CarController>().Is_AI)
        {
            int temp = PlayerPrefs.GetInt("progress");
            Debug.Log("W");
            PlayerPrefs.SetInt("progress", temp + 1);
            PlayerPrefs.Save();
            Progress_Managements.progress++;

        }
        else
        {
            Debug.Log("L");
        }
        
        raceManager.EndRace();
        gameObject.SetActive(false);
    }

}
