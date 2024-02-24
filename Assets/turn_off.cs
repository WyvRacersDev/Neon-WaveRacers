using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turn_off : MonoBehaviour
{
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        StartCoroutine("turning_off");
    }

    IEnumerator turning_off()
    {

        yield return new WaitForSeconds(3);
        this.gameObject.SetActive(false);


    }
}
