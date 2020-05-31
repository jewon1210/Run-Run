using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu_Select_Scripts : MonoBehaviour
{
    [SerializeField] Image Setting_window;
    [SerializeField] Image Help_window;
    [SerializeField] RectTransform[] _positions;
    float move_speed = 10;//움직임 속도

    bool Setting_button;
    bool Help_button;
    bool Go_to_game;

    // Start is called before the first frame update
    void Start()
    {
        Setting_button = false;
        Help_button = false;
        Setting_window.rectTransform.anchoredPosition = _positions[0].anchoredPosition;//0,1은 세팅
        Help_window.rectTransform.anchoredPosition = _positions[2].anchoredPosition;//2.3은 헬프
        Go_to_game = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (Setting_button)
        {
            Move_Setting_Buttons();
        }
        if (Help_button)
        {
            Move_Help_Buttons();
        }
        //Move_Setting_Buttons();
        //Move_Help_Buttons();

        if (Input.GetKeyDown(KeyCode.Space) && Go_to_game)
        {
            Go_IngameScene();
        }

        if (!Setting_button)
        {
            Move_Setting_Buttons();
        }
        if (!Help_button)
        {
            Move_Help_Buttons();
        }
    }

    public void Setting_Buttons()//버튼선택시 불값부여
    {
        if(!Setting_button)
            Setting_button = true;
        else
            Setting_button = false;
    }

    public void Help_Buttons()//버튼선택시 불값부여
    {
        if (!Help_button)
            Help_button = true;
        else
            Help_button = false;
        
    }

    public void Move_Setting_Buttons()
    {
        if (Setting_button)
        {
            Setting_window.rectTransform.anchoredPosition = Vector2.Lerp(
                Setting_window.rectTransform.anchoredPosition, _positions[1].anchoredPosition, Time.deltaTime * move_speed);

            if (Vector2.Distance(Setting_window.rectTransform.anchoredPosition,
                                            _positions[1].anchoredPosition) <= 0.2f)
            {
                Setting_window.rectTransform.anchoredPosition = _positions[1].anchoredPosition;
            }
        }

        else
        {
            Setting_window.rectTransform.anchoredPosition = Vector2.Lerp(
                Setting_window.rectTransform.anchoredPosition, _positions[0].anchoredPosition, Time.deltaTime * move_speed);

            if (Vector2.Distance(Setting_window.rectTransform.anchoredPosition,
                                            _positions[0].anchoredPosition) <= 0.2f)
            {
                Setting_window.rectTransform.anchoredPosition = _positions[0].anchoredPosition;
            }
        }
    }

    public void Move_Help_Buttons()
    {
        if (Help_button)
        {
            Help_window.rectTransform.anchoredPosition = Vector2.Lerp(
                Help_window.rectTransform.anchoredPosition, _positions[3].anchoredPosition, Time.deltaTime * move_speed);

            if (Vector2.Distance(Help_window.rectTransform.anchoredPosition,
                                            _positions[3].anchoredPosition) <= 0.2f)
            {
                Help_window.rectTransform.anchoredPosition = _positions[3].anchoredPosition;
            }
        }

        else
        {
            Help_window.rectTransform.anchoredPosition = Vector2.Lerp(
                Help_window.rectTransform.anchoredPosition, _positions[2].anchoredPosition, Time.deltaTime * move_speed);

            if (Vector2.Distance(Help_window.rectTransform.anchoredPosition,
                                            _positions[2].anchoredPosition) <= 0.2f)
            {
                Help_window.rectTransform.anchoredPosition = _positions[2].anchoredPosition;
            }
        }
    }

    public void Go_IngameScene()
    {
        Scene_Manager_Script.instance.Load_Ingame_Scene();
    }
    public void Stop_Go_IngameScene()
    {
        Go_to_game = false;
    }
    public void Allow_Go_IngameScene()
    {
        Go_to_game = true;
    }
    public void Exit_Game()
    {
        Scene_Manager_Script.instance.Quit_Button();
    }
}
