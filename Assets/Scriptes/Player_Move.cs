using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    float fast_Move = 3f;
    float base_Move = 1.5f;
    float current_Move;

    public float jump = 6f;
    int jump_count = 1;
    int changeImage;

    Rigidbody2D rigid;
    Animator animator;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        current_Move = base_Move;
    }

    void Update()
    {
        PlayerChange();
        Player_Jump();
    }

    void FixedUpdate()
    {
        PlayerMove();
    }

    //이동
    void PlayerMove()
    {
        float h = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * h * current_Move, ForceMode2D.Impulse);

        if (rigid.velocity.x > current_Move)
        {
            rigid.velocity = new Vector2(current_Move, rigid.velocity.y);
        }
        else if (rigid.velocity.x < -current_Move)
        {
            rigid.velocity = new Vector2(-current_Move, rigid.velocity.y);
        }
    }

    //변신
    void PlayerChange()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            jump_count = 3;
            if (current_Move == base_Move)
            {
                current_Move = fast_Move;
            }
            else
            {
                current_Move = base_Move;
            }
        }

    }

    //뛰기
    void Player_Jump()
    {
        if (Input.GetButtonDown("Jump") && jump_count > 0) //점프 중복을 제거
        {
            rigid.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
            jump_count -= 1;
            if (jump_count == 0)
            {
                jump_count = 1;
            }
        }
    }
}
