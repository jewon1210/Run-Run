using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGM_Manager_Script : MonoBehaviour
{
    public enum eTypeBGM
    {
        TITLE = 0,
        INGAME
    }
    

    [SerializeField] AudioClip[] _bgmClips;

    public Slider BGMVolume;
    AudioSource _playerBGM;

    float _bgmVolum = 1.0f;
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
        _bgmVolum = PlayerPrefs.GetFloat("_bgmVolum", 1.0f);
        BGMVolume.value = _bgmVolum;
        _playerBGM.volume = BGMVolume.value;
    }

    void Update()
    {
        if (Scene_Manager_Script.instance.eCurrentScene == Scene_Manager_Script.eSceneState.LOBBY)
        {
            SoundSlider();
        }
    }

    public void PlayBGMSound(eTypeBGM type)
    {
        _playerBGM.clip = _bgmClips[(int)type];
        _playerBGM.volume = _bgmVolum;
        _playerBGM.loop = _bgmLoop;

        _playerBGM.Play();
    }

    public void SoundSlider()
    {
        _playerBGM.volume = BGMVolume.value;
        _bgmVolum = BGMVolume.value;
        PlayerPrefs.SetFloat("_bgmVolum", _bgmVolum);
    }


}
