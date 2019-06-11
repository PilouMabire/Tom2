using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public bool dontDestroyOnLoad;

    public bool affectReference;

    public static SoundPlayer reference;

    public AudioSource sound;
    public AudioSource sound2;
    public AudioSource sound3;
    public AudioSource sound4;
    public AudioSource sound5;
    public AudioSource sound6;

    public float destroyDelay;

    // Start is called before the first frame update
    void Start()
    {
        if(dontDestroyOnLoad)
        {
            DontDestroyOnLoad(this.gameObject);
            reference = this;
        }
        
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

    public float FadeTime;
    

    public void FadeAway()
    {
        StartCoroutine(FadeOut( sound,  FadeTime));
    }

    IEnumerator FadeOut(AudioSource _sound, float FadeTime)
    {
        if(!affectReference)
        {
            float startVolume = _sound.volume;

            while (_sound.volume > 0)
            {
                _sound.volume -= startVolume * Time.deltaTime / FadeTime;

                yield return null;
            }

            _sound.Stop();
            _sound.volume = startVolume;
        }
        else
        {
            float startVolume = reference.sound.volume;

            while (reference.sound.volume > 0)
            {
                reference.sound.volume -= startVolume * Time.deltaTime / FadeTime;

                yield return null;
            }

            reference.sound.Stop();
            reference.sound.volume = startVolume;
        }
    }

    public void FadeAway2()
    {
        StartCoroutine(FadeOut2(sound2, FadeTime));
    }

    IEnumerator FadeOut2(AudioSource _sound2, float FadeTime)
    {
        if (!affectReference)
        {
            float startVolume = _sound2.volume;

            while (_sound2.volume > 0)
            {
                _sound2.volume -= startVolume * Time.deltaTime / FadeTime;

                yield return null;
            }

            _sound2.Stop();
            _sound2.volume = startVolume;
        }
        else
        {
            float startVolume = reference.sound2.volume;

            while (reference.sound2.volume > 0)
            {
                reference.sound2.volume -= startVolume * Time.deltaTime / FadeTime;

                yield return null;
            }

            reference.sound2.Stop();
            reference.sound2.volume = startVolume;
        }
    }



    public void DestroyThisObjectIn()
    {
        StartCoroutine(DestroyThis());
    }

    IEnumerator DestroyThis()
    {
        yield return new WaitForSeconds(destroyDelay);
        Destroy(this.gameObject);
    }
}
