using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    public AudioMixer audioMixer;
    // public Slider slider;

    // private void Start() {
    //     slider.value = -0;
    // }
    public void SetVolume (float volume){
         audioMixer.SetFloat("Volume", volume);
    }
}
