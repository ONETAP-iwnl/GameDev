using System.Collections;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    public GameObject playerPrefab; // ������ �� Prefab ���������
    public GameObject newObjectPrefab; // ������ �� Prefab �������, ������� ������ ���������
    public float delayBeforeChangeScene = 2f; // �������� ����� ������ �����
    public string sceneToLoad; // ��� �����, �� ������� �� ������ �������

    private bool hasTriggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !hasTriggered)
        {
            hasTriggered = true;

            // ������� �������� ���������
            Destroy(collision.gameObject);

            // ������� ����� ������ ����� ��������� �����
            StartCoroutine(SpawnNewObject());
            Instantiate(newObjectPrefab, transform.position, Quaternion.identity);
            
        }
    }

    private IEnumerator SpawnNewObject()
    {
        yield return new WaitForSeconds(delayBeforeChangeScene);
        UnityEngine.SceneManagement.SceneManager.LoadScene(3);

        // ��������� ����� �����

    }
}
