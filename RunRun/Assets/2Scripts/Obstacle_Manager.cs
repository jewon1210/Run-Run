﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Manager : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 3.0f;
    [SerializeField] float _StartPosition = 7.0f;
    [SerializeField] float _EndPosition = -7.0f;
    [SerializeField] float _PositionY = 0.0f;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //오른쪽에서 왼쪽으로 이동
        transform.Translate(Vector3.left * Time.deltaTime * _moveSpeed);
    }

    void MoveEnd()
    {

     }
}
