using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Control : MonoBehaviour
{

    float _moveSpeed;
    bool direct;

    void Start()
    {
        _moveSpeed = 0.0f;
        direct = false;
    }

    void Update()
    {
        moving();
    }

    void moving()
    {
        transform.Translate(Vector3.left * Time.deltaTime * _moveSpeed);
        if (transform.position.y >= 0.0f && !direct)
        {
            _moveSpeed = -_moveSpeed;
            direct = true;
        }
        if (transform.position.y <= -2.14f && direct)
        {
            _moveSpeed = -_moveSpeed;
            direct = false;
        }

    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Finish")
        {
            transform.Translate(Vector3.down * Time.deltaTime * _moveSpeed);
        }
    }

    public void isMove()
    {
        _moveSpeed = 2.0f;
    }
    public void isPause()
    {
        _moveSpeed = 0.0f;
    }
}
