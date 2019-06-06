using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{

    public AudioSource sound;
    public AudioSource sound2;
    public AudioSource sound3;
    public AudioSource sound4;
    public AudioSource sound5;
    public AudioSource sound6;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        sound.Play();
    }
    public void Play2()
    {
        sound2.Play();
    }
    public void Play3()
    {
        sound3.Play();
    }
    public void Play4()
    {
        sound4.Play();
    }
    public void Play5()
    {
        sound5.Play();
    }

    public void Play6()
    {
        sound6.Play();
    }

    public void Stop()
    {
        sound.Stop();
    }
    public void Stop2()
    {
        sound2.Stop();
    }
    public void Stop3()
    {
        sound3.Stop();
    }
    public void Stop4()
    {
        sound4.Stop();
    }
    public void Stop5()
    {
        sound5.Stop();
    }
    public void Stop6()
    {
        sound6.Stop();
    }


}
