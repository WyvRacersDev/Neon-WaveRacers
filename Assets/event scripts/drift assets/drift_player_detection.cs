using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class player_detection_drift : MonoBehaviour
{
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Car") && !other.gameObject.GetComponent<CarController>().Is_AI)
        {
            Debug.Log("drift trial possible");
        }

    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Car") && !other.gameObject.GetComponent<CarController>().Is_AI && other.gameObject.GetComponent<CarController>().CurrentSpeed < 1 && other.gameObject.GetComponent<CarController>().CurrentAcceleration == 0)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                GameObject.Find("GameController").GetComponent<drift_management>().StartDriftEvent();
                Debug.Log("drift event started");
                this.gameObject.SetActive(false);
            }

        }
    }





    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Car") && !other.gameObject.GetComponent<CarController>().Is_AI)
        {
            Debug.Log("drift event no more possible");
        }
    }


    // Update is called once per frame

}
