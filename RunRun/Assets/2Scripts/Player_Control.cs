using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Control : MonoBehaviour
{
    public enum State_Ani
    {
        IDLE        =0,
        RUN,
        JUMPUP,
        JUMPDOWN,
        HIT
    }

    //[SerializeField] float Movespeed;
    bool Jump_First;
    bool Jump_Second;
    Rigidbody2D rid2D;

    void Awake()
    {
        rid2D = GetComponent<Rigidbody2D>();

        Jump_First = true;
        Jump_Second = true;
    }

    void Start()
    {    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (Jump_First || Jump_Second))
        {
            rid2D.velocity = new Vector2(0, 7);
            if (Jump_First)
                Jump_First = false;
            else
                Jump_Second = false;
        }
    }

    //이후 OnTrigerEnter2D로 바꿀 예정
    void OnCollisionEnter2D(Collision2D collision)
    {
        Jump_First = true;
        Jump_Second = true;
    }

}
