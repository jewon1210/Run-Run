using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGM_Manager_Script : MonoBehaviour
{
    public enum eTypeBGM
    {
        TITLE = 0,
        INGAME,
        FAIL,
        GAMEOVER
    }
    

    [SerializeField] AudioClip[] _bgmClips;

    AudioSource _playerBGM;

    float _bgmVolum = 1.0f;
    bool _bgmLoop = true;

    public float _bgmVol
    {
        get { return _bgmVolum; }
    }

    static BGM_Manager_Script _uniqueInstance;

    public static BGM_Manager_Script _instance
    {
        get { return _uniqueInstance; }
    }

    void Awake()
    {
        _uniqueInstance = this;
        DontDestroyOnLoad(gameObject);
        _playerBGM = GetComponent<AudioSource>();
    }

    void Start()
    {
        _bgmVolum = PlayerPrefs.GetFloat("_bgmVolum", 1.0f);
    }

    void Update()
    {
    }

    public void PlayBGMSound(eTypeBGM type)
    {
        _playerBGM.clip = _bgmClips[(int)type];
        _playerBGM.volume = _bgmVolum;
        if (type == eTypeBGM.FAIL || type == eTypeBGM.GAMEOVER)
            _playerBGM.loop = false;
        else
            _playerBGM.loop = _bgmLoop;

        _playerBGM.Play();
    }

    public void SoundSlider(float vol)
    {
        _playerBGM.volume = vol;
        _bgmVolum = vol;
    }

    
}
