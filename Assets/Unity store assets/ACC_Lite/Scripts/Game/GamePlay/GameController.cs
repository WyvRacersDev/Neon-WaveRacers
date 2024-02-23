using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

/// <summary>
/// Base class game controller.
/// </summary>
public class GameController :MonoBehaviour
{
	[SerializeField] KeyCode NextCarKey = KeyCode.N;
	[SerializeField] UnityEngine.UI.Button NextCarButton;
	public static GameController Instance;
	public static CarController PlayerCar;
	public static bool RaceIsStarted { get { return true; } }
	public static bool RaceIsEnded { get { return false; } }

	public GameObject arrow;
	

	CarController m_PlayerCar;
	public List<CarController> Cars = new List<CarController>();
	int CurrentCarIndex = 0;

	protected virtual void Awake ()
	{

		StartCoroutine("begin");

		
	}

	void Update () 
	{ 
		if (Input.GetKeyDown (NextCarKey))
		{
			NextCar ();
		}
		if(Input.GetKeyDown(KeyCode.Escape)||(Input.GetKeyDown(KeyCode.Backspace)))
		{
			SceneManager.LoadScene("Game");
		}


	}

	private void NextCar ()
	{
		m_PlayerCar.GetComponent<UserControl> ().enabled = false;
		m_PlayerCar.GetComponent<AudioListener> ().enabled = false;

		CurrentCarIndex = MathExtentions.LoopClamp (CurrentCarIndex + 1, 0, Cars.Count);

		m_PlayerCar = Cars[CurrentCarIndex];
		m_PlayerCar.GetComponent<UserControl> ().enabled = true;
		m_PlayerCar.GetComponent<AudioListener> ().enabled = true;
	}


	IEnumerator begin()
	{
		yield return new WaitForSeconds (1);
        Instance = this;
        //Find all cars in current game.
        Cars.AddRange(GameObject.FindObjectsOfType<CarController>());
        Cars = Cars.OrderBy(c => c.name).ToList();


		foreach(var car in Cars)
		{
			if(!car.Is_AI&&!car.Is_police)
			{

				PlayerCar=car;
				break;
			}


		}

        foreach (var car in Cars)
        {

            var userControl = car.GetComponent<UserControl>();
            var audioListener = car.GetComponent<AudioListener>();

            if ((userControl == null) && (!car.GetComponent<CarController>().Is_AI))
            {
                userControl = car.gameObject.AddComponent<UserControl>();
            }

            if ((audioListener == null) && (!car.GetComponent<CarController>().Is_AI))

            {
                audioListener = car.gameObject.AddComponent<AudioListener>();
            }

            if (!car.GetComponent<CarController>().Is_AI)
                userControl.enabled = false;
            audioListener.enabled = false;
        }

        m_PlayerCar = Cars[0];
        m_PlayerCar.GetComponent<UserControl>().enabled = true;
        m_PlayerCar.GetComponent<AudioListener>().enabled = true;

        if (NextCarButton)
        {
            NextCarButton.onClick.AddListener(NextCar);
        }

		arrow.transform.position= new Vector3 (PlayerCar.transform.position.x, PlayerCar.transform.position.y+5, PlayerCar.transform.position.z);
		
		arrow.transform.SetParent(PlayerCar.transform, true);
		
    }

}

