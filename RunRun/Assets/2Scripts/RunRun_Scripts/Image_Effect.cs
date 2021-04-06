using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Image_Effect : MonoBehaviour
{

    [SerializeField] Image Spacebar_Effect;
    [SerializeField] Image Arrow_Effect;

    float time_Check;//시간 체크해주는 변수
    int num_Text;

    void Start()
    {
        
    }

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
                    Spacebar_Effect.CrossFadeAlpha(0.0f, 0.0f, true);//알파값 설정
                    Arrow_Effect.CrossFadeAlpha(0.0f, 0.0f, true);
                    break;
                case 1:
                    Spacebar_Effect.CrossFadeAlpha(0.7372549f, 0.0f, true);
                    Arrow_Effect.CrossFadeAlpha(1.0f, 0.0f, true);
                    break;
            }
        }
    }
}
