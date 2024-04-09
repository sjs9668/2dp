using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float moveSpeed = 5f; // �̵� �ӵ� ����
    public float jumpForce = 10f; // ���� �� ����
    private bool isGrounded; // ���鿡 �ִ��� ���� Ȯ��
    

    public Animator animator;


   

    void Update()
    {
        // Ű���� �Է� �ޱ�
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float movement = horizontalInput * moveSpeed * Time.deltaTime;

        transform.Translate(new Vector2(movement, 0));

        // �̵� ���⿡ ���� ĳ���͸� �¿�� ȸ����ŵ�ϴ�.
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

      
       
        

        // ���� ó��
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // ���鿡 ��Ҵ��� Ȯ��
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
