using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player_detection_race_trigger : MonoBehaviour
{
    // Start is called before the first frame update
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Car")&&!other.gameObject.GetComponent<CarController>().Is_AI)
        {
            Debug.Log("race possible");
        }

    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Car") && !other.gameObject.GetComponent<CarController>().Is_AI&&other.gameObject.GetComponent<CarController>().CurrentSpeed<1&&other.gameObject.GetComponent<CarController>().CurrentAcceleration==0)
        {
            if(Input.GetKeyDown(KeyCode.Return))
            {
                GameObject.Find("GameController").GetComponent<RaceManager>().StartRace(other.transform);
                Debug.Log("race started");
                this.gameObject.SetActive(false);
            }
                 
        }
    }


   


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Car") && !other.gameObject.GetComponent<CarController>().Is_AI)
        {
            Debug.Log("race no more possible");
        }
    }


    // Update is called once per frame

}
