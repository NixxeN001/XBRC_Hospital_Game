using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sounds
{
    public string name;

    public AudioClip audclip;

    public AudioMixerGroup mixerOutput;


    [HideInInspector]
    public AudioSource _source;
}
