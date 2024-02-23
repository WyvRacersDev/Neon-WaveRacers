using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class time_trial_player_detection : MonoBehaviour
{
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Car") && !other.gameObject.GetComponent<CarController>().Is_AI)
        {
            Debug.Log("timetrial possible");
        }

    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Car") && !other.gameObject.GetComponent<CarController>().Is_AI && other.gameObject.GetComponent<CarController>().CurrentSpeed < 1 && other.gameObject.GetComponent<CarController>().CurrentAcceleration == 0)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                GameObject.Find("GameController").GetComponent<TimeTrialManagement>().StartTimer(other.transform);
                Debug.Log("trial started");
                this.gameObject.SetActive(false);
            }

        }
    }





    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Car") && !other.gameObject.GetComponent<CarController>().Is_AI)
        {
            Debug.Log("trial no more possible");
        }
    }


    // Update is called once per frame

}
