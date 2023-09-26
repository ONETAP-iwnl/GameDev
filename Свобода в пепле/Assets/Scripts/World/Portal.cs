using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField] GameObject pointTeleport;
    public Transform player; // ������ �� ������ ������
    public Cinemachine.CinemachineVirtualCamera virtualCamera; // ������ �� ���� Cinemachine ������

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // ��������� ����� ����� �� ����� sceneToLoad
            SceneManager.LoadScene(4);

            // ���������� ����� ������� ��� ������ � ����� �����
            // (����������: ��� ����� ��������, ������ ���� ����� ������������ ���������� � ����� �����)
            collision.gameObject.transform.position = pointTeleport.transform.position;

            // �������� ���� (Target) ����� Cinemachine ������, ����� ��� ������� �� �������
            virtualCamera.Follow = player;
        }
    }
}
