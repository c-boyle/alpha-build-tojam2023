using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoboMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;

    private Vector2 mostRecentMove = Vector2.zero;
    /*
     * TODO: Rework movement so that when you get hit you can't move until you slow to a certain speed 
     */
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
        rb.velocity = mostRecentMove * speed;
    }
}
