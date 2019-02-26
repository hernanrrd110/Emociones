using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


public class SliderVolumen : MonoBehaviour
{
    Slider sliderVolumen;
    public AudioMixer audioMixer;
    // Start is called before the first frame update
    void Start()
    {
        sliderVolumen = gameObject.GetComponent<Slider>();
        float volumen;
        audioMixer.GetFloat("volume", out volumen);
        sliderVolumen.value = volumen;

    }

}
