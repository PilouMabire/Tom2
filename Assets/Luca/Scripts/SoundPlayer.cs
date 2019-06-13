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

    public float FadeTime;
    public float FadeInTime;

    [Header ("Fade In")]
    public float timeToFadeIn = 1;
    //public float volumeMax = 1;


    // Start is called before the first frame update
    void Start()
    {
        if(dontDestroyOnLoad)
        {
            if(reference == null)
            {
                DontDestroyOnLoad(this.gameObject);
                reference = this;
            }
            else
            {
                Destroy(this.gameObject);
            }
                
        }
        
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
            if(reference != null)
            {
                float startVolume = reference.sound.volume;

                while (reference.sound.volume > 0)
                {
                    reference.sound.volume -= startVolume * Time.deltaTime / FadeTime;

                    yield return null;
                }
                reference.sound.Stop();
                reference.sound.volume = startVolume;
                reference = null;
            }
            
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


    public void FadeAway3()
    {
        StartCoroutine(FadeOut3(sound3, FadeTime));
    }

    IEnumerator FadeOut3(AudioSource _sound3, float FadeTime)
    {
        if (!affectReference)
        {
            float startVolume = _sound3.volume;

            while (_sound3.volume > 0)
            {
                _sound3.volume -= startVolume * Time.deltaTime / FadeTime;

                yield return null;
            }

            _sound3.Stop();
            _sound3.volume = startVolume;
        }
        else
        {
            float startVolume = reference.sound3.volume;

            while (reference.sound3.volume > 0)
            {
                reference.sound3.volume -= startVolume * Time.deltaTime / FadeTime;

                yield return null;
            }

            reference.sound3.Stop();
            reference.sound3.volume = startVolume;
        }
    }

    public void FadeAway4()
    {
        StartCoroutine(FadeOut4(sound4, FadeTime));
    }

    IEnumerator FadeOut4(AudioSource _sound4, float FadeTime)
    {
        if (!affectReference)
        {
            float startVolume = _sound4.volume;

            while (_sound4.volume > 0)
            {
                _sound4.volume -= startVolume * Time.deltaTime / FadeTime;

                yield return null;
            }

            _sound4.Stop();
            _sound4.volume = startVolume;
        }
        else
        {
            float startVolume = reference.sound4.volume;

            while (reference.sound4.volume > 0)
            {
                reference.sound4.volume -= startVolume * Time.deltaTime / FadeTime;

                yield return null;
            }

            reference.sound4.Stop();
            reference.sound4.volume = startVolume;
        }
    }

    public void FadeAway5()
    {
        StartCoroutine(FadeOut5(sound5, FadeTime));
    }

    IEnumerator FadeOut5(AudioSource _sound5, float FadeTime)
    {
        if (!affectReference)
        {
            float startVolume = _sound5.volume;

            while (_sound5.volume > 0)
            {
                _sound5.volume -= startVolume * Time.deltaTime / FadeTime;

                yield return null;
            }

            _sound5.Stop();
            _sound5.volume = startVolume;
        }
        else
        {
            float startVolume = reference.sound5.volume;

            while (reference.sound5.volume > 0)
            {
                reference.sound5.volume -= startVolume * Time.deltaTime / FadeTime;

                yield return null;
            }

            reference.sound5.Stop();
            reference.sound5.volume = startVolume;
        }
    }


    public void FadeAway6()
    {
        StartCoroutine(FadeOut6(sound6, FadeTime));
    }

    IEnumerator FadeOut6(AudioSource _sound6, float FadeTime)
    {
        if (!affectReference)
        {
            float startVolume = _sound6.volume;

            while (_sound6.volume > 0)
            {
                _sound6.volume -= startVolume * Time.deltaTime / FadeTime;

                yield return null;
            }

            _sound6.Stop();
            _sound6.volume = startVolume;
        }
        else
        {
            float startVolume = reference.sound6.volume;

            while (reference.sound6.volume > 0)
            {
                reference.sound6.volume -= startVolume * Time.deltaTime / FadeTime;

                yield return null;
            }

            reference.sound6.Stop();
            reference.sound6.volume = startVolume;
        }
    }

    public void FadeIn(AudioSource _audio)
    {
        StartCoroutine(FadeInCoroutine(_audio, FadeInTime));
    }

    IEnumerator FadeInCoroutine(AudioSource sound, float FadeInTime)
    {
        float _volumeMax = sound.volume;
        sound.volume = 0;
        for (int i = 0; i < 20 * timeToFadeIn ; i++)
        {
            sound.volume += 0.05f /timeToFadeIn ;
            if(sound.volume > _volumeMax)
            {
                break;
            }
            yield return new WaitForSeconds(0.05f);
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
