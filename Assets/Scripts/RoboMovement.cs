using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoboMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed = 5f;

    private Vector2 mostRecentMove = Vector2.zero;
    public void Move(Vector2 move)
    {
        mostRecentMove = move;
    }

    public void Look(Vector2 direction)
    {

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        rb.MoveRotation(angle);
    }

    private void FixedUpdate()
    {
        if (rb.velocity.magnitude <= speed * 1.2f) {
            rb.velocity = mostRecentMove * speed;
        }
    }
}
