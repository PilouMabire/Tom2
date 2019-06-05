using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Sound
{
    public string name;
    public AudioClip clip;
    
}



public class SoundManager : MonoBehaviour
{

    public List<Sound> sounds;
    public List<AudioSource> sources;

    public List<Sound> musicsAndVoices;
    public List<AudioSource> musicAndVoiceSources;
    int soundIndex;
    int musicIndex;

    public static SoundManager Instance;

    // Start is called before the first frame update
    void Start()
    {
        //if(Instance == null)
        //{
        //    Instance = this;
        //    DontDestroyOnLoad(gameObject);
        //}
        //else
        //{
        //    if(Instance == this)
        //    {

        //    }
        //    else
        //    {
        //        Destroy(gameObject);
        //    }
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Play(string name)
    {
        for (int i = 0; i < sounds.Count; i++)
        {
            if(sounds[i].name == name)
            {
                sources[soundIndex].clip = sounds[i].clip;
                break;
            }

        }
        soundIndex++;
        if(soundIndex > 20)
        {
            soundIndex = 0;
        }
    }

    public void PlayLongSound(string name)
    {
        for (int i = 0; i < sounds.Count; i++)
        {
            if (musicsAndVoices[i].name == name)
            {
                musicAndVoiceSources[soundIndex].clip = musicsAndVoices[i].clip;
                break;
            }

        }
        musicIndex++;
        if (musicIndex > 20)
        {
            soundIndex = 0;
        }
    }
}
