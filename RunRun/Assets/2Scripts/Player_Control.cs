using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player_Control : MonoBehaviour
{
    float VelocityX;
    float _nowAngle;
    SpriteRenderer _CharacterModel;
    Animator _aniCtrl;
    Ingame_Manager _GM;


    public enum State_Ani
    {
        IDLE        =0,
        RUN,
        JUMPUP,
        JUMPDOWN,
        HIT
    }

    bool Jump_First;
    bool Jump_Second;
    bool _isDead;
    Rigidbody2D rid2D;
    State_Ani _currentAction;

    public bool _isDeath
    {
        get { return _isDead; }
    }


    void Awake()
    {
        rid2D = GetComponent<Rigidbody2D>();
        _aniCtrl = GetComponent<Animator>();
        Jump_First = true;
        Jump_Second = true;
    }

    void Start()
    {
        _CharacterModel=transform.GetComponent<SpriteRenderer>();//GetChild(0)=>부모오브젝트의 안에 있는 또다른 오브젝트->자식오브젝트 0번째를 찾을 때
        _nowAngle= 0;
        GameObject go = GameObject.Find("Ingame_Manager");
        _GM = go.GetComponent<Ingame_Manager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (Jump_First || Jump_Second))
        {
            rid2D.velocity = new Vector2(0, 6);
            if(rid2D.velocity.y > 0)
                ChangeAction(State_Ani.JUMPUP);
            if (Jump_First)
            {
                Jump_First = false;
                Effect_Sound_Script._instance.PlayEffectSound(Effect_Sound_Script.eTypeEffectSound.JUMP1);
            }
            else
            {
                Jump_Second = false;
                Effect_Sound_Script._instance.PlayEffectSound(Effect_Sound_Script.eTypeEffectSound.JUMP2);
            }
        }
        if (rid2D.velocity.y < 0)
            ChangeAction(State_Ani.JUMPDOWN);
    }

    void LateUpdate()
    {
        if (_isDead)
        {
            AngleUp();
        }     
    }

    void AngleUp()
    {
        //float targetAngle = 0;
        //targetAngle = Mathf.Atan2(rid2D.velocity.y, VelocityX) * Mathf.Rad2Deg; //Atan--> 아크탄젠트 회전각도-> 점프각도 구해주는 식
        //_nowAngle = Mathf.Lerp(_nowAngle, targetAngle, Time.deltaTime * 2);
        if (_nowAngle <= 90)
            _nowAngle += Time.deltaTime * 70;
        _CharacterModel.transform.localRotation = Quaternion.Euler(0, 0, _nowAngle);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        ChangeAction(State_Ani.RUN);
        Jump_First = true;
        Jump_Second = true;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Obstacle")
        {
            ChangeAction(State_Ani.HIT);
            Obstacle_Manager._instance.MovePause();
            Ingame_Manager._instance.isDead();
        }

        if (collision.gameObject.tag == "Coin")
        {
            //_GM.AddPoint(3);
            GameObject go = collision.gameObject;
            Destroy(go);
        }
    }

    void ChangeAction(State_Ani type)
    {
        if (_isDead)
            return;

        _aniCtrl.SetInteger("AniState", (int)type);

        if (type == State_Ani.HIT)
            _isDead = true;

        _currentAction = type;
    }

}
