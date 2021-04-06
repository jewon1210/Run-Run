using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Dragon_Script : MonoBehaviour
{
    Animator Dragon_Ani;
    Transform DragonTrans;
    Transform KnightTrans;
    float distance, x, y, z;
    // Start is called before the first frame update
    void Start()
    {
        Dragon_Ani = gameObject.GetComponent<Animator>();
        DragonTrans = gameObject.GetComponent<Transform>();
        KnightTrans = GameObject.Find("Knight_Character").GetComponent<Transform>();
        distance = Vector2.Distance(KnightTrans.position, DragonTrans.position);
        x = KnightTrans.position.x;
        y = KnightTrans.position.y;
        z = KnightTrans.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        Position();
        if (distance < 10.0f)
        {
            ControlAni(1);
            DragonTrans.Translate(x * Time.deltaTime, y * Time.deltaTime, 0);
            if (distance < 2.0f)
                ControlAni(2);
        }
    }

    void ControlAni(int num)
    {
        Dragon_Ani.SetInteger("Drangon_Ani", num);
    }

    void Position()
    {
        distance = Vector2.Distance(KnightTrans.position, gameObject.transform.position);
        x = KnightTrans.position.x;
        y = KnightTrans.position.y;
        z = KnightTrans.position.z;
    }
}
