using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//scenemanage역할



public class Scene_Manager_Script : MonoBehaviour
{
    float delay_check;//화면 넘기기 딜레이 주는 변수
    float time_check;//클릭시 시간저장
    bool Change_Scene;//화면 변경 불값

    [SerializeField] GameObject Loading;//로딩화면 생성

    static Scene_Manager_Script uniqueinstance;

    void Awake()
    {
        uniqueinstance = this;
        DontDestroyOnLoad(gameObject);//안사라지게 해줌
    }
    // Start is called before the first frame update
    void Start()
    {
        Change_Scene = false;
    }

    // Update is called once per frame
    void Update()
    {
        delay_check += Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            Change_Scene = true;
            time_check=delay_check;
        }

        if(delay_check-time_check>=2&&Change_Scene==true)
        {
            SceneManager.LoadScene("Lobby");
            Change_Scene = false;
        }
    }
}