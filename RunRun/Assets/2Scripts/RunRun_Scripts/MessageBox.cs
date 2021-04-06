using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageBox : MonoBehaviour
{
    Text _message;
    

    void Awake()
    {
        _message = GetComponentInChildren<Text>();//이 함수는 나 자신을 먼저 찾아온다.
    }
    public void EnableMessage(bool isOn = false, string msg = "")
    {
        gameObject.SetActive(isOn);
        _message.text = msg;
    }
}

