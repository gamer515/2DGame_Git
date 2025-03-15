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

    //이동
    void PlayerMove()
    {
        float h = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * h * Base_Move, ForceMode2D.Impulse);
    }

    //변신
    void PlayerChange()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Base_Move = Fast_Move;
        }
    }

    //뛰기
    void Player_Jump()
    {
        if (Input.GetButton("Jump")) //점프 중복을 제거
        {
            rigid.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
        }
    }
}
