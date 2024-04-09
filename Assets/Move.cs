using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float moveSpeed = 5f; // 이동 속도 설정
    public float jumpForce = 10f; // 점프 힘 설정
    private bool isGrounded; // 지면에 있는지 여부 확인
    

    public Animator animator;


   

    void Update()
    {
        // 키보드 입력 받기
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float movement = horizontalInput * moveSpeed * Time.deltaTime;

        transform.Translate(new Vector2(movement, 0));

        // 이동 방향에 따라 캐릭터를 좌우로 회전시킵니다.
        if (horizontalInput > 0)
        {
            animator.SetBool("Run", true);
            transform.localScale = new Vector3(1, 1, 1);

        }
        else if (horizontalInput < 0)
        {
            animator.SetBool("Run", true);
            transform.localScale = new Vector3(-1, 1, 1);

        }
        else
        {
            animator.SetBool("Run", false);

        }

      
       
        

        // 점프 처리
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // 지면에 닿았는지 확인
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
