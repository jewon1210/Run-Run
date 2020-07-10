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
        COIN,
        HIT,
        FAIL,
        GAMEOVER
    }

    [SerializeField] AudioClip[] _effectClips;
    
    AudioSource _playerEffectSound;
    float _effectVolum = 1.0f;
    bool _bgmLoop = true;

    static Effect_Sound_Script _uniqueInstance;

    public static Effect_Sound_Script _instance
    {
        get { return _uniqueInstance; }
    }
    public float _effectVol
    {
        get { return _effectVolum; }
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
    }

    void Update()
    {
    }

    public void PlayEffectSound(eTypeEffectSound type)
    {
        _playerEffectSound.clip = _effectClips[(int)type];
        _playerEffectSound.volume = _effectVolum;
        _playerEffectSound.loop = false;

        _playerEffectSound.Play();
    }

    public void SoundSlider(float vol)
    {
        _playerEffectSound.volume = vol;
        _effectVolum = vol;
    }
}
