using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class car_choice : MonoBehaviour
{
    // Start is called before the first frame update
    public int car_index = 0;

    public GameObject[] cars;
    int start;
    int end;

    public int prog;
    void Start()
    {
        car_index = PlayerPrefs.GetInt("Car_Choice", 0);
       
        prog = PlayerPrefs.GetInt("progress");

        if(prog==1)
        {
            start = 0;
            end = 2;
        }

        if(prog==3)
        {
            start = 2;
            end = 5;
        }

        if (prog > 3)
        {
            start = 0;
            end=cars.Length;

        }

    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.RightArrow)||(Input.GetKeyDown(KeyCode.UpArrow))) 
        {
        car_index++;
        }

        else if (Input.GetKeyDown(KeyCode.LeftArrow) || (Input.GetKeyDown(KeyCode.DownArrow)))
        {
        car_index--;
        }

        if(car_index <start) 
        {
            car_index = end - 1;
        }

        if(car_index>end-1)
        {
            car_index = start;
        }




        if(Input.GetKeyDown(KeyCode.Return)&&(car_index>=0)&&(car_index<end))
        {
            PlayerPrefs.SetInt("Car_Choice", car_index);

            if ((prog == 1) || (prog == 3))
            {
                prog++;
                PlayerPrefs.SetInt("progress", prog);
                PlayerPrefs.Save();
            }
            SceneManager.LoadScene("Game");

            
        }
        update_cars_show();
    }


    void update_cars_show()
    {


            for (int i = start; i < cars.Length; i++)
            {
                if (i == car_index)
                {
                    cars[i].SetActive(true);
                }
                else
                {
                    cars[i].SetActive(false);

                }

            }


        for (int i = 0; i < cars.Length; i++)
        {
            if((i<start)||(i>end))
            {
                cars[i].SetActive(false);


            }

        }

    }





}
