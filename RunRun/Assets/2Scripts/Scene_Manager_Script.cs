﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//scenemanage역할



public class Scene_Manager_Script : MonoBehaviour
{
    float delay_check;//화면 넘기기 딜레이 주는 변수
    float time_check;//클릭시 시간저장
    bool Change_Scene;//화면 변경 불값
    bool Click_once;

    [SerializeField] GameObject Loading;//로딩화면 생성

    static Scene_Manager_Script uniqueinstance;

    public static Scene_Manager_Script instance
    {
        get { return uniqueinstance; }
    }

    void Awake()
    {
        uniqueinstance = this;
        DontDestroyOnLoad(gameObject);//안사라지게 해줌
    }
    // Start is called before the first frame update
    void Start()
    {
        Change_Scene = false;
        Click_once = true;
    }

    // Update is called once per frame
    void Update()
    {
        delay_check += Time.deltaTime;

        if (Input.GetMouseButtonDown(0)&&Click_once)
        {
            Change_Scene = true;
            time_check=delay_check;
            Click_once = false;
            BGM_Manager_Script._instance.PlayBGMSound(BGM_Manager_Script.eTypeBGM.TITLE);
        }

        if ((delay_check-time_check) >= 2.0f && Change_Scene)
        {
            SceneManager.LoadScene("Lobby");
            Change_Scene = false;
        }        
    }


    public void Load_Ingame_Scene()
    {        
        //이후 시간차를 두어 넘어가게 하고 중간에 로딩화면 등을 넣을 예정

        SceneManager.LoadScene("Ingame");
        BGM_Manager_Script._instance.PlayBGMSound(BGM_Manager_Script.eTypeBGM.INGAME);
    }

    public void Restart_Game()
    {
        SceneManager.LoadScene("Ingame");
        BGM_Manager_Script._instance.PlayBGMSound(BGM_Manager_Script.eTypeBGM.INGAME);
    }

    public void Go_Home()
    {
        SceneManager.LoadScene("Lobby");
    }

    public void Quit_Button()
    {

#if UNITY_EDITOR
        //에디터에 play버튼을 끄는 역활
        UnityEditor.EditorApplication.isPlaying = false;
#else
        //빌드에서는 가능하지만 에디터에서는 안된다.
        Application.Quit();
#endif
    }
}