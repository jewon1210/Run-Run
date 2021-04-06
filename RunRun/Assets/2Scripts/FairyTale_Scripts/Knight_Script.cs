using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight_Script : MonoBehaviour
{
    Transform KnightTrans;
    Rigidbody2D _rid;
    Animator Knight_ani;
    int CurAni; // 0 - idle, 1- walk, 2 - attack,  3 - jumpUp 4- jumpdown

    private void Awake()
    {
        KnightTrans = gameObject.GetComponent<Transform>();
        _rid = gameObject.GetComponent<Rigidbody2D>();
        Knight_ani = gameObject.GetComponent<Animator>();
        CurAni = 0;
    }
    void Start()
    {        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            ControlAni(1);
            KnightTrans.Translate(Vector2.right * Time.deltaTime * 3.0f);
            KnightTrans.rotation = new Quaternion(0, 180, 0, 0);
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            ControlAni(1);
            KnightTrans.Translate(Vector2.right * Time.deltaTime * 3.0f);
            KnightTrans.rotation = new Quaternion(0, 0, 0, 0);
        }

        else if (Input.GetKey(KeyCode.LeftControl))
        {
            ControlAni(2);
        }

        else if (Input.GetKey(KeyCode.LeftAlt))
        {
            _rid.velocity = new Vector2(0, 6);
        }

        else if (_rid.velocity.y > 0)
            ControlAni(3);

        else if (_rid.velocity.y < 0)
            ControlAni(4);

        else
            ControlAni(0);
        
    }


    void ControlAni(int i)
    {
        CurAni = i;
        Knight_ani.SetInteger("Knight_ani", CurAni);
    }
}
