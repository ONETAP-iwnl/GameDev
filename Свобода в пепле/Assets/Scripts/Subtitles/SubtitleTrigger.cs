using UnityEngine;

public class SubtitleTrigger : MonoBehaviour
{
    [SerializeField] private GameObject Canvas;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Проверка, что игрок вошел в зону коллайдера
        {
            Canvas.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Проверка, что игрок покинул зону коллайдера
        {
            Canvas.SetActive(false);
        }
    }
}
