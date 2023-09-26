using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    public ColliderController targetColliderController; // Ссылка на скрипт ColliderController

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Проверьте, что объект, вошедший в триггер, является игроком
        if (other.CompareTag("Player"))
        {
            // Включите коллайдер на целевом GameObject
            targetColliderController.ActivateCollider();
        }
    }
}
