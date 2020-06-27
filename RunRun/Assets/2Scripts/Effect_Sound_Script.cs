using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Effect_Sound_Script : MonoBehaviour
{
    public enum eTypeEffectSound
    {
        BUTTON = 0,
        JUMP1,
        JUMP2,
        COIN
    }

    [SerializeField] AudioClip[] _effectClips;
    
    public Slider effectVolume;
    AudioSource _playerEffectSound;
    float _effectVolum = 1.0f;
    bool _bgmLoop = true;

    static Effect_Sound_Script _uniqueInstance;

    public static Effect_Sound_Script _instance
    {
        get { return _uniqueInstance; }
    }

    void Awake()
    {
        _uniqueInstance = this;
        DontDestroyOnLoad(gameObject);
        _playerEffectSound = GetComponent<AudioSource>();
    }

    void Start()
    {
        _effectVolum = PlayerPrefs.GetFloat("_effectVolum", 1.0f);
        effectVolume.value = _effectVolum;
        _playerEffectSound.volume = effectVolume.value;
    }

    void Update()
    {
        if (Scene_Manager_Script.instance.eCurrentScene == Scene_Manager_Script.eSceneState.LOBBY)
        {
            SoundSlider();
        }
    }

    public void PlayEffectSound(eTypeEffectSound type)
    {
        _playerEffectSound.clip = _effectClips[(int)type];
        _playerEffectSound.volume = _effectVolum;
        _playerEffectSound.loop = false;

        _playerEffectSound.Play();
    }

    public void SoundSlider()
    {
        _playerEffectSound.volume = effectVolume.value;
        _effectVolum = effectVolume.value;
        PlayerPrefs.SetFloat("_effectVolum", _effectVolum);
    }
}
