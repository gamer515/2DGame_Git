using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    public float jump;
    int changeImage;
    Rigidbody2D rigid;
    Animator animator;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(Input.GetButton("Jump")) //���� �ߺ��� ����
        {
            rigid.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
        }    
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        if(h == 0)
        {
            changeImage = Random.Range(-1, 2);
        }
    }
}
