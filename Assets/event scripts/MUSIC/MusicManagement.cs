using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManagement : MonoBehaviour
{

    #region Attributes

    public List<AudioClip> ganay = new List<AudioClip>();



    private AudioSource musicSource;


    AudioClip currenttrack;

    private float length;

    private Coroutine musicloop;

    private MusicQueue musicqueue;

   

    #region MonoBehavior API

    void Start()
    {
        musicqueue = new MusicQueue(ganay);



        musicSource = GetComponent<AudioSource>();


        StartMusic();
    }



    #endregion

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
          
           StopMUsic();

        }


        if(Input .GetKeyDown(KeyCode.N)) 
        {
           
            skiptrack();


        }


    }

    public void PlayMusicCLip(AudioClip musics)
    {

        musicSource.Stop();
        musicSource.clip = musics;
        musicSource.Play();
       

    }

    public void skiptrack()
    {
        StopCoroutine(musicloop);
        StartMusic();
    }



    public void StopMUsic()
    {


       
            StopCoroutine(musicloop);

      
    }

    public void StartMusic()
    {

        musicloop = StartCoroutine(musicqueue.LoopMusic(this, 0, PlayMusicCLip));



    }


    #endregion
}





public class MusicQueue
{
    private List<AudioClip> clips;

    public MusicQueue(List<AudioClip> clips)
    {
        this.clips = clips;
    }

    public IEnumerator LoopMusic(MonoBehaviour player, float delay, System.Action<AudioClip> playFunction)
    {
        while (true)
        {


            yield return player.StartCoroutine(Run(Randomizedlist(clips), delay, playFunction));
        }

    }



    public IEnumerator Run(List<AudioClip> tracks, float delay,
        System.Action<AudioClip> playFunction)
    {
        foreach (AudioClip clip in tracks)
        {
            playFunction(clip);

            yield return new WaitForSeconds(clip.length + delay);

        }

    }

    public List<AudioClip> Randomizedlist(List<AudioClip> list)
    {

        List<AudioClip> copy = new List<AudioClip>(list);

        int n = copy.Count;

        while (n > 1)
        {

            n--;
            int k = Random.Range(0, n + 1);


            AudioClip value = copy[k];


            copy[k] = copy[n];

            copy[n] = value;







        }



        return copy;


    }





}


