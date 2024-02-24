using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Video;

public class RaceManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] arrows;
    public int index_arrow = -1;
    public GameObject[] racers;

    public GameObject arrow_gps;

    public GameObject[] waypoints;

    public Transform player_spawn;
   // public Transform[] startpositions_racers;

    private GameObject trigger;
    public GameObject finish;

    public GameObject AI_final_check_without_player;
    public bool ai_final_check_bool;

    public GameController gameController;

    public List<CarController> Cars;

    public bool isRaceactive;

   
   

    private void Awake()
    {
        trigger = GameObject.Find("Race trigger");
        gameController=GetComponent<GameController>();
    }

    public void StartRace(Transform player)
    {
        ai_final_check_bool = false;
        isRaceactive = true;
        index_arrow = 0;

        arrow_gps.SetActive(false);
        player.GetComponent<Rigidbody>().ResetInertiaTensor();
        player.transform.position=player_spawn.position;
        player.transform.rotation=player_spawn.rotation;
        for ( int i=0; i<racers.Length;i++ ) 
        {
            Instantiate(racers[i]);
        }

        Cars.AddRange(GameObject.FindObjectsOfType<CarController>());
       

     

    }
    public void EndRace()
    {
        arrow_gps.SetActive(true);
        isRaceactive = false;
        trigger.SetActive(true);
        

        index_arrow = -1;
        foreach (var a in arrows)
        {
            a.SetActive(false);
        }

        foreach (CarController a in Cars)
        {

            if(a.Is_AI)
            {
                a.killcar();   
            }
        }
       
        Cars.Clear();

        

        //for (int i = 0; i < racers.Length; i++)
        //{
        //    racers[i].GetComponent<CarController>().reset_car(startpositions_racers[i]);
        //}

    }


    // Update is called once per frame
    void Update()
    {
        if (isRaceactive)
        {
            for (int i = 0; i < arrows.Length; i++)
            {
                if (i == index_arrow)
                {
                    arrows[i].gameObject.SetActive(true);

                }
                else
                    arrows[i].gameObject.SetActive(false);

                if (index_arrow > 5||ai_final_check_bool)
                    finish.SetActive(true);
                else
                    finish.SetActive(false);

            }
        }
    }

   

}
