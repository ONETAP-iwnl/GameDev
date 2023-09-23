using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerScript : MonoBehaviour
{
    public Animator playerAnimator; // ������ �� ��������� �������� ���������
    public string sceneToLoad; // ��� �����, �� ������� �� ������ �������
    private bool hasTriggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !hasTriggered)
        {
            hasTriggered = true;
            playerAnimator.SetTrigger("Fall"); // ��������� �������� �������
            StartCoroutine(LoadSceneAfterAnimation());
        }
    }

    private IEnumerator LoadSceneAfterAnimation()
    {
        // ���� ���������� �������� �������
        yield return new WaitForSeconds(playerAnimator.GetCurrentAnimatorStateInfo(0).length);

        // ��������� ����� �����
        SceneManager.LoadScene(3);
    }
}
