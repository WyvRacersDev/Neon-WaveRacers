using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class arrow_behavior : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Car")&& !other.gameObject.GetComponent<CarController>().Is_AI)
        {
            GameObject.Find("GameController").GetComponent<RaceManager>().index_arrow++;
        }
    }

}
