using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField] GameObject pointTeleport;
    public Transform player; // Ссылка на объект игрока
    public Cinemachine.CinemachineVirtualCamera virtualCamera; // Ссылка на вашу Cinemachine камеру

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Загружаем новую сцену по имени sceneToLoad
            SceneManager.LoadScene(4);

            // Выставляем новую позицию для игрока в новой сцене
            // (примечание: это будет работать, только если точка телепортации существует в новой сцене)
            collision.gameObject.transform.position = pointTeleport.transform.position;

            // Обновите цель (Target) вашей Cinemachine камеры, чтобы она следила за игроком
            virtualCamera.Follow = player;
        }
    }
}
