using System.Collections;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    public GameObject playerPrefab; // Ссылка на Prefab персонажа
    public GameObject newObjectPrefab; // Ссылка на Prefab объекта, который должен появиться
    public float delayBeforeChangeScene = 2f; // Задержка перед сменой сцены
    public string sceneToLoad; // Имя сцены, на которую вы хотите перейти

    private bool hasTriggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !hasTriggered)
        {
            hasTriggered = true;

            // Удаляем текущего персонажа
            Destroy(collision.gameObject);

            // Создаем новый объект через некоторое время
            StartCoroutine(SpawnNewObject());
            Instantiate(newObjectPrefab, transform.position, Quaternion.identity);
            
        }
    }

    private IEnumerator SpawnNewObject()
    {
        yield return new WaitForSeconds(delayBeforeChangeScene);
        UnityEngine.SceneManagement.SceneManager.LoadScene(3);

        // Загружаем новую сцену

    }
}
