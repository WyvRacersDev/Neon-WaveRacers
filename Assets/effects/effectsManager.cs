using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effectsManager : MonoBehaviour
{
    // Start is called before the first frame update


    public List<Material> materials;

    public Color startColor;
    public Color endColor; 
    public float duration = 2.0f; 



    void Start()
    {
        StartCoroutine("ChangeEmissionColor");
    }

    

    // Update is called once per frame
  
    IEnumerator ChangeEmissionColor()
    {

        foreach (Material mat in materials)
        {
            float elapsedTime = 0.0f;
            while (elapsedTime < duration)
            {
                float t = elapsedTime / duration;

                Color lerpedColor = Color.Lerp(startColor, endColor, t);

           


                mat.SetColor("_EmissionColor", lerpedColor);

                elapsedTime += Time.deltaTime;

                yield return null;
            }
            float intensity = 1.5f;
    
            mat.SetColor("_EmissionColor", endColor*intensity);
        }
        Color temp = startColor;
        startColor = endColor;
        endColor=temp;

        StartCoroutine("ChangeEmissionColor");

    }

}
