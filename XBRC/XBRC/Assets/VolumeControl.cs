using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    [SerializeField] string _volumeParameter = "MusicVolumeParameter";
    [SerializeField] AudioMixer _mixer;
    [SerializeField] Slider _slider;
    [SerializeField] float _multiplier = 1.6f;


    // Start is called before the first frame update

    private void Awake()
    {
        _slider.onValueChanged.AddListener(HandleSLiderValueChange);
    }

    private void HandleSLiderValueChange(float value)
    {
        _mixer.SetFloat(_volumeParameter, value*_multiplier);
    }

}
