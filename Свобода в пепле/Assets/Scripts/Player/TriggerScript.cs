using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerScript : MonoBehaviour
{
    public Animator playerAnimator; // Ссылка на компонент анимации персонажа
    public string sceneToLoad; // Имя сцены, на которую вы хотите перейти
    private bool hasTriggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !hasTriggered)
        {
            hasTriggered = true;
            playerAnimator.SetTrigger("Fall"); // Запустить анимацию падения
            StartCoroutine(LoadSceneAfterAnimation());
        }
    }

    private IEnumerator LoadSceneAfterAnimation()
    {
        // Ждем завершения анимации падения
        yield return new WaitForSeconds(playerAnimator.GetCurrentAnimatorStateInfo(0).length);

        // Загружаем новую сцену
        SceneManager.LoadScene(3);
    }
}
