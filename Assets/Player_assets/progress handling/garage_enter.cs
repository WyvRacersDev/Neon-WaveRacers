using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class garage_enter : MonoBehaviour
{
    // Start is called before the first frame update

  
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Car") && !other.gameObject.GetComponent<CarController>().Is_AI)
        {
            Debug.Log("garage enter possible");
        }

    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Car") && !other.gameObject.GetComponent<CarController>().Is_AI)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {

                SceneManager.LoadScene("Garage");

            }

        }
    }





    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Car") && !other.gameObject.GetComponent<CarController>().Is_AI)
        {
            Debug.Log("garage entry no longer possible");
        }
    }


    // Update is called once per frame

}
