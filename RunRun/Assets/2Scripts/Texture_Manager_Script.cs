using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Texture_Manager_Script : MonoBehaviour
{
    float time_Check;//시간 체크해주는 변수
    int num_Text;

    [SerializeField] Text Title_Text;
    [SerializeField] Text Touch_Text;
    [SerializeField] Image Background_Image;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time_Check += Time.deltaTime;
        if (time_Check >= 0.5f)
        {
            time_Check = 0;
            int i = ++num_Text % 2;
            switch (i)
            {
                case 0:
                    Touch_Text.CrossFadeAlpha(0.0f, 0.5f, true);//알파값 설정
                    break;
                case 1:
                    Touch_Text.CrossFadeAlpha(1.0f, 0.5f, true);
                    break;
            }
        }
        if(Input.GetMouseButtonDown(0))
        {
            Background_Image.CrossFadeAlpha(0.0f, 0.5f, true);
        }
    }
}
