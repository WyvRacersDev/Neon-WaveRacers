using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] player;
    public GameObject Slow_car;
    public Transform garage_spawn;
    public int index_car;
    


    void Start()
    {
       

        index_car = PlayerPrefs.GetInt("Car_Choice", -1);

        if(index_car == -1)
        {

            Instantiate(Slow_car);

        }
        else
        {
            Instantiate(player[index_car],garage_spawn.position,garage_spawn.rotation);
        }
            
       
        
    }

    // Update is called once per frame
 
}
