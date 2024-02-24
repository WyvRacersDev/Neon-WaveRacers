using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ai_without_player_finish : MonoBehaviour
{
    // Start is called before the first frame update
  public RaceManager raceManager;


    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<CarController>().Is_AI)
        {
            raceManager.ai_final_check_bool = true;
        }
    }


}
