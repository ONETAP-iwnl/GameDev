using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector2 moveVector;
    public float speed = 2f;
    public Animator animator;

    private float smoothTime = 0.1f; // �����, �� ������� ����������� "���������" ������������
    private Vector2 velocity = Vector2.zero;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Walk();
    }

    void Walk()
    {
        moveVector.x = Input.GetAxis("Horizontal");
        float targetVelocityX = moveVector.x * speed;
        // ������������� �������� ��������� ��� �������� ������������
        rb.velocity = Vector2.SmoothDamp(rb.velocity, new Vector2(targetVelocityX, rb.velocity.y), ref velocity, smoothTime);

        // ����������� ����������� ��������
        if (moveVector.x > 0)
        {
            // �������� �������� ������
            transform.localScale = new Vector3(1, 1, 1); // ����������� ������
            animator.SetBool("IsRunning", true); // ��������� �������� ����
        }
        else if (moveVector.x < 0)
        {
            // �������� �������� �����
            transform.localScale = new Vector3(-1, 1, 1); // ����������� �����
            animator.SetBool("IsRunning", true); // ��������� �������� ����
        }
        else
        {
            // �������� ����� �� �����
            animator.SetBool("IsRunning", false); // ���������� �������� ����
        }
    }
}
