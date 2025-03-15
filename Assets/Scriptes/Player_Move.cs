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
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse); //AddForce ���� �ι�° �μ��� Ȯ���� �����Ѵ�.
        }

        //������ �ڿ� ��¦ �������� ������, Update�� �Ʒ��� ������ �ִ� ������ ������� �Է��� �޴� �����̴ϱ�
        if(Input.GetButtonUp("Horizontal")) {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 1.5f, rigid.velocity.y);
        }
        //�ٵ� Down�� ���⿡ ������ ���ɿ� ������ �߻����� ������?
        if(Input.GetButtonDown("Horizontal")) {
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
        }

        //���ߴ� �̹����� �����̴� �̹��� ��ȯ
        if(rigid.velocity.normalized.x == 0) 
            animator.SetBool("IfGo", false);
        else 
            animator.SetBool("IfGo", true);
    }

    void FixedUpdate()
    {
        //ad�� ������ ����
        float h = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        //���� ad��ư�� ��� ������ �ӵ��� ��� �ö󰡴ϱ� ������ �δ� ��
        if(rigid.velocity.x > maxSpeed) 
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        else if(rigid.velocity.x < maxSpeed * (-1)) 
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);

        Debug.DrawRay(rigid.position, Vector3.down, new Color(1, 0, 1)); //ĳ���� �߽ɺ��� ���� �׾������� �غ���

        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, 1, LayerMask.GetMask("Ground"));

        if(rayHit.collider != null) {
            if(rayHit.distance < 0.5f) //���࿡ ĳ���� �߽ɺ��� Raycast ��� �߽ɺ��� �ٸ������� �Ÿ��� �� ���̴�.
                Debug.Log(rayHit.collider.name);
        }
    }
}
