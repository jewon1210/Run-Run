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

    // Start is called before the first frame update
    void Start()
    {
        Setting_button = false;
        Help_button = false;
        Setting_window.rectTransform.anchoredPosition = _positions[0].anchoredPosition;//0,1은 세팅
        Help_window.rectTransform.anchoredPosition = _positions[2].anchoredPosition;//2.3은 헬프

    }
        // Update is called once per frame
   void Update()
   {
        if (Setting_button)
        {
            Move_Setting_Buttons();
        }

        if(Help_button)
        {
            Move_Help_Buttons();
        }
        //Move_Setting_Buttons();
        //Move_Help_Buttons();
   }

    public void Setting_Buttons()//버튼선택시 불값부여
    {
        Setting_button= true;
    }

    public void Help_Buttons()//버튼선택시 불값부여
    { 
        Help_button = true;
    }

    public void Move_Setting_Buttons()
    {
        if (true)
        {
            Setting_window.rectTransform.anchoredPosition = Vector2.Lerp(
                Setting_window.rectTransform.anchoredPosition, _positions[1].anchoredPosition, Time.deltaTime * move_speed);

            if (Vector2.Distance(Setting_window.rectTransform.anchoredPosition,
                                            _positions[1].anchoredPosition) <= 0.2f)
            {
                Setting_window.rectTransform.anchoredPosition = _positions[1].anchoredPosition;
                Setting_button = false;
            }
        }
    }

 

    public void Move_Help_Buttons()
    {
        if (true)
        {
            Help_window.rectTransform.anchoredPosition = Vector2.Lerp(
                Help_window.rectTransform.anchoredPosition, _positions[3].anchoredPosition, Time.deltaTime * move_speed);

            if (Vector2.Distance(Help_window.rectTransform.anchoredPosition,
                                            _positions[3].anchoredPosition) <= 0.2f)
            {
                Help_window.rectTransform.anchoredPosition = _positions[3].anchoredPosition;
                Help_button = false;
            }
        }
    }
}
