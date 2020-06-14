using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player_Control : MonoBehaviour
{
    float VelocityX;
    float _nowAngle;
    SpriteRenderer _CharacterModel;
    
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
    {
        _CharacterModel=transform.GetComponent<SpriteRenderer>();//GetChild(0)=>부모오브젝트의 안에 있는 또다른 오브젝트->자식오브젝트 0번째를 찾을 때
        _nowAngle=_CharacterModel.transform.eulerAngles.z;        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (Jump_First || Jump_Second))
        {
            rid2D.velocity = new Vector2(0, 6);
            if (Jump_First)
                Jump_First = false;
            else
                Jump_Second = false;
        }
    }

    void LateUpdate()
    {
        if (transform.position.y>=-2.5f) {
            AngleUp();
        }
        
    }

    void AngleUp()
    {
        float targetAngle = 0;
        targetAngle = Mathf.Atan2(rid2D.velocity.y, VelocityX) * Mathf.Rad2Deg; //Atan--> 아크탄젠트 회전각도-> 점프각도 구해주는 식
        _nowAngle = Mathf.Lerp(_nowAngle, targetAngle, Time.deltaTime * 2);

        _CharacterModel.transform.localRotation = Quaternion.Euler(0, 0, _nowAngle);
    }

    //이후 OnTrigerEnter2D로 바꿀 예정
    void OnCollisionEnter2D(Collision2D collision)
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);//닿았을때 안밀림
        Jump_First = true;
        Jump_Second = true;
    }
}
