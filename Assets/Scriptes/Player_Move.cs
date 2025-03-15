using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    float Fast_Move = 3f;
    float Base_Move = 1.5f;

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
        PlayerChange();
    }

    void FixedUpdate()
    {
        PlayerMove();
    }

    //�̵�
    void PlayerMove()
    {
        float h = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * h * Base_Move, ForceMode2D.Impulse);
    }

    //����
    void PlayerChange()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Base_Move = Fast_Move;
        }
    }

    //�ٱ�
    void Player_Jump()
    {
        if (Input.GetButton("Jump")) //���� �ߺ��� ����
        {
            rigid.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
        }
    }
}
