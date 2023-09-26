using UnityEngine;

public class InteractionController : MonoBehaviour
{
    public KeyCode interactKey = KeyCode.E; // Клавиша для взаимодействия
    public ColliderController targetColliderController; // Ссылка на скрипт ColliderController
    public GameObject petPrefab; // Префаб питомца
    private GameObject currentPet; // Текущий экземпляр питомца

    private void Update()
    {
        // Проверьте, была ли нажата клавиша "E"
        if (Input.GetKeyDown(interactKey))
        {
            // Проверьте, включен ли коллайдер на целевом GameObject
            if (targetColliderController != null)
            {
                // Если коллайдер включен, отключите его; и наоборот
                if (targetColliderController.GetComponent<Collider2D>().enabled)
                {
                    //targetColliderController.DeactivateCollider();

                    
                }
                else
                {
                    targetColliderController.ActivateCollider();

                    // Создайте экземпляр питомца и сделайте его следовать за игроком
                    if (petPrefab != null)
                    {
                        currentPet = Instantiate(petPrefab, petPrefab.transform.position, petPrefab.transform.rotation);
                        // Здесь вы можете добавить логику для сделать питомца следовать за игроком
                    }
                }
            }
        }
    }
}
