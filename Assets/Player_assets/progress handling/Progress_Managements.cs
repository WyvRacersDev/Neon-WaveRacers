using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progress_Managements : MonoBehaviour
{
    // Start is called before the first frame update


    public int progress;

    public GameObject trigger_time_trial; 
    public GameObject trigger_drift_trial;
    public GameObject trigger_garage;
    public GameObject trigger_race;

    public GameObject arrow_gps;

    public Transform target;
    
    void Start()
    {
        progress = PlayerPrefs.GetInt("progress", 0);
    }


     void Update()
    {
        if(progress==0)
        {
            trigger_time_trial.SetActive(false);
            trigger_drift_trial.SetActive(false);
            trigger_garage.SetActive(false);
            target = trigger_race.transform;
        }

        if (progress== 1)
        {
            trigger_garage.SetActive(true);
            target = trigger_garage.transform;
        }
        if(progress ==2)
        {
            
            trigger_time_trial.SetActive(true);
            target = trigger_time_trial.transform;
            
        }
        if(progress==4)
        {
            trigger_drift_trial.SetActive(true);
            target = trigger_drift_trial.transform;
        }
        if(progress >4) 
        {
            trigger_drift_trial.SetActive(true);
            trigger_time_trial.SetActive(true);
            trigger_garage.SetActive(true);
            arrow_gps.SetActive(false);
            target=arrow_gps.transform;
        }
    
        Vector3 direction =target.position-arrow_gps.gameObject.transform.position;


        Debug.DrawRay(arrow_gps.transform.position, direction, Color.green);

       
        Vector3 temp = direction;
        direction.x = -temp.z; 
        direction.z=temp.x;
       
        
        arrow_gps.transform.rotation=Quaternion.LookRotation(-direction);


    }
}
