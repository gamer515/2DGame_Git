using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    public float maxSpeed;
    public float jumpPower;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator animator;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {   
        if(Input.GetButtonDown("Jump")) {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse); //AddForce 에서 두번째 인수를 확인해 봐야한다.
        }

        //움직임 뒤에 살짝 앞으로의 움직임, Update에 아래의 문장이 있는 이유는 사용자의 입력을 받는 순간이니깐
        if(Input.GetButtonUp("Horizontal")) {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 1.5f, rigid.velocity.y);
        }
        //근데 Down이 여기에 있으면 성능에 문제가 발생하지 않을까?
        if(Input.GetButtonDown("Horizontal")) {
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
        }

        //멈추는 이미지랑 움직이는 이미지 전환
        if(rigid.velocity.normalized.x == 0) 
            animator.SetBool("IfGo", false);
        else 
            animator.SetBool("IfGo", true);
    }

    void FixedUpdate()
    {
        //ad로 움직임 구현
        float h = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        //만약 ad버튼을 계속 누르면 속도가 계속 올라가니깐 제한을 두는 것
        if(rigid.velocity.x > maxSpeed) 
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        else if(rigid.velocity.x < maxSpeed * (-1)) 
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);

        Debug.DrawRay(rigid.position, Vector3.down, new Color(1, 0, 1)); //캐릭터 중심부터 선이 그어지도록 해보기

        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, 1, LayerMask.GetMask("Ground"));

        if(rayHit.collider != null) {
            if(rayHit.distance < 0.5f) //만약에 캐릭터 중심부터 Raycast 라면 중심부터 다리까지의 거리를 뺀 것이다.
                Debug.Log(rayHit.collider.name);
        }
    }
}
