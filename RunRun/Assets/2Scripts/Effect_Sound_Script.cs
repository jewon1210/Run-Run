using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    AudioSource _playerEffectSound;
    float _bgmVolum = 1;
    float _effectVolum = 1;
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


}
