using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjcet : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 3.0f;
    [SerializeField] float _StartPosition = 7.0f;
    [SerializeField] float _EndPosition = -7.0f;
    [SerializeField] float _PositionY = 0.0f;
    GameObject obj;

    void Start()
    {
        obj = GameObject.FindGameObjectWithTag("Obstacle");   
    }

    // Update is called once per frame
    void Update()
    {
        //오른쪽에서 왼쪽으로 이동
        transform.Translate(Vector3.left * Time.deltaTime * _moveSpeed);

        if (transform.position.x <= _EndPosition)
        {
            MoveEnd();
        }
    }

    void MoveEnd()
    {
        transform.Translate(-1 * (_EndPosition - _StartPosition), _PositionY, 0.0f);
    }
}
