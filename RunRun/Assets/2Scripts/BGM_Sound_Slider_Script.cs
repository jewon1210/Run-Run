using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGM_Sound_Slider_Script : MonoBehaviour
{
    Slider slider;
    float volume;
    bool OnOff = true;

    void Awake()
    {
        GameObject go = GameObject.FindGameObjectWithTag("BGM");
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
        BGM_Manager_Script._instance.SoundSlider(volume);
    }
    public void SoundOnOff()
    {
        if (OnOff)
            slider.value = 0;
        else
            slider.value = 1.0f;
        BGM_Manager_Script._instance.SoundSlider(slider.value);
    }
}
