using UnityEngine;

public class MovementDima : MonoBehaviour
{
    public Transform player; // Ссылка на игрока, за которым будет следить NPC
    public float speed = 2.0f; // Скорость движения NPC
    
    


    private bool isFollowing = false; // Флаг, указывающий, следует ли NPC за игроком

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isFollowing = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isFollowing = false;
        }
    }

    private void Update()
    {
        if (isFollowing)
        {
            // Вычисляем направление к игроку
            Vector3 direction = (player.position - transform.position).normalized;

            // Перемещаем NPC в направлении игрока с учетом скорости
            transform.position += direction * speed * Time.deltaTime;
        }
    }
}