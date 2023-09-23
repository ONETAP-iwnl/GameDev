using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector2 moveVector;
    public float speed = 2f;
    public Animator animator;

    private float smoothTime = 0.1f; // Время, за которое достигается "плавность" передвижения
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
        // Интерполируем скорость персонажа для плавного передвижения
        rb.velocity = Vector2.SmoothDamp(rb.velocity, new Vector2(targetVelocityX, rb.velocity.y), ref velocity, smoothTime);

        // Определение направления движения
        if (moveVector.x > 0)
        {
            // Персонаж движется вправо
            transform.localScale = new Vector3(1, 1, 1); // Отображение вправо
            animator.SetBool("IsRunning", true); // Включение анимации бега
        }
        else if (moveVector.x < 0)
        {
            // Персонаж движется влево
            transform.localScale = new Vector3(-1, 1, 1); // Отображение влево
            animator.SetBool("IsRunning", true); // Включение анимации бега
        }
        else
        {
            // Персонаж стоит на месте
            animator.SetBool("IsRunning", false); // Выключение анимации бега
        }
    }
}
