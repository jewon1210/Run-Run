using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Effect_Sound_Slider_Script : MonoBehaviour
{
    Slider slider;
    float volume;
    bool OnOff = true;

    void Awake()
    {
        GameObject go = GameObject.FindGameObjectWithTag("EffectSound");
        slider = go.GetComponent<Slider>();
        volume = 1.0f;
    }

    void Start()
    {
    }

    void Update()
    {
    }
    public void sliderValueChange()
    {
        volume = slider.value;
        Effect_Sound_Script._instance.SoundSlider(volume);
    }
    public void SoundOnOff()
    {
        if (OnOff)
            slider.value = 0;
        else
            slider.value = 1.0f;
        Effect_Sound_Script._instance.SoundSlider(slider.value);
    }

}

