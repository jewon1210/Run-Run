using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM_Manager_Script : MonoBehaviour
{
    public enum eTypeBGM
    {
        TITLE = 0,
        INGAME
    }
    

    [SerializeField] AudioClip[] _bgmClips;

    AudioSource _playerBGM;

    float _bgmVolum = 1;
    float _effectVolum = 1;
    bool _bgmLoop = true;

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
    }

    void Update()
    {
    }

    public void PlayBGMSound(eTypeBGM type)
    {
        _playerBGM.clip = _bgmClips[(int)type];
        _playerBGM.volume = _bgmVolum;
        _playerBGM.loop = _bgmLoop;

        _playerBGM.Play();
    }

}
