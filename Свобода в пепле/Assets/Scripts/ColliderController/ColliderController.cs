using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderController : MonoBehaviour
{
    private Collider2D col; // Ссылка на компонент Collider2D

    private void Start()
    {
        // Получите ссылку на компонент Collider2D
        col = GetComponent<Collider2D>();

        // Изначально отключите коллайдер
        col.enabled = false;
    }

    public void ActivateCollider()
    {
        // Включите коллайдер
        col.enabled = true;
    }

    public void DeactivateCollider()
    {
        // Отключите коллайдер
        col.enabled = false;
    }
}
