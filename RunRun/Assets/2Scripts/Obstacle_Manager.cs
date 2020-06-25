using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Manager : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 3.0f;
    bool pause;

    static Obstacle_Manager _uniqueInstance;

    public static Obstacle_Manager _instance
    {
        get { return _uniqueInstance; }
    }

    void Awake()
    {
        _uniqueInstance = this;
    }

    void Start()
    {
        pause = false;
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
