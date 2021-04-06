using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Manager : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 3.0f;
    bool pause;

    void Start()
    {
        pause = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(!pause)
            //오른쪽에서 왼쪽으로 이동
            transform.Translate(Vector3.left * Time.deltaTime * _moveSpeed);
    }

    public void MovePause()
    {
        pause = true;
    }

    public void MoveStart()
    {
        if (Ingame_Manager._instance._isDead)
            return;

        pause = false;
    }

}
