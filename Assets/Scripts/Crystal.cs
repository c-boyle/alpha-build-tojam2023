using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    [SerializeField] private UnityEngine.InputSystem.PlayerInput owner;
    [SerializeField] private int health = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.collider.CompareTag("Crystal"))
        {
            health--;
            if (health <= 0 )
            {
                Destroy(owner.gameObject);
            }
        }
    }

}
