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

    // Start is called before the first frame update
    void Start()
    {
        
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
}
