using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawMoving : MonoBehaviour
{
    Ingame_Manager InG;
    SpriteRenderer _Saw;
    Quaternion quater;
    float SawRotate;


    void Start()
    {
        _Saw = transform.GetComponent<SpriteRenderer>();
        quater = Quaternion.identity;
        SawRotate = 0.0f;
        GameObject go = GameObject.Find("Ingame_Manager");
        InG = go.GetComponent<Ingame_Manager>();
    }

    void Update()
    {
        if(InG._nowGameState == Ingame_Manager.eGameState.PLAY)
        {
            SawRotate += Time.deltaTime * 150;
            _Saw.transform.localRotation = Quaternion.Euler(0, 0, SawRotate);
        }
    }

}
