using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Move : MonoBehaviour
{
    public int nextMove;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        
        Invoke("Think", 2);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2(nextMove, rb.velocity.y);

        Vector2 frontVec = new Vector2(rb.position.x + nextMove, rb.position.y);
        Debug.DrawRay(frontVec, Vector3.down, new Color(1, 0, 1)); 
        RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down, 1, LayerMask.GetMask("Ground"));
        if(rayHit.collider == null) {
            nextMove = nextMove * -1;
            CancelInvoke();
            Invoke("Think", 2);
        }
    }

    void Think() {
        nextMove = Random.Range(-1, 2); //�� 1�� ���� �ʰ� 2�� �ϴ� �� ��Ȯ�� �˱�

        Invoke("Think", 2);
    }
}
