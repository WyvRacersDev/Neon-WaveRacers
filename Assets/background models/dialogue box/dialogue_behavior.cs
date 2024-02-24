using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogue_behavior : MonoBehaviour
{
    // Start is called before the first frame update


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {

            moveon();
        }
    }
    public void moveon()
    {
        Time.timeScale = 1.0f;
        gameObject.SetActive(false);
    }

}
