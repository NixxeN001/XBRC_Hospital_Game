using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Audio;


public class AudioManager : MonoBehaviour
{
    
    public Sounds[] soundArry;
    // Start is called before the first frame update
    void Awake()
    {
        foreach (Sounds s in soundArry)
        {
            s._source = gameObject.AddComponent<AudioSource>();
            s._source.clip = s.audclip;
            s._source.outputAudioMixerGroup = s.mixerOutput;

        }
    }

    public void PlaySound(string soundname)
    {
        Sounds s = Array.Find(soundArry, sound => sound.name == soundname);
        s._source.Play();
    }
  
}


