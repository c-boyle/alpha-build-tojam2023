using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoboMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    public Robo Owner { get; set; }

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
        if (Owner.RoboStats.TryGetStatName(StatNames.SPEED, out float speed))
        {
            if (rb.velocity.magnitude <= speed * 1.2f)
            {
                rb.velocity = mostRecentMove * speed;
            }
        } else
        {
            Debug.LogError("RoboMovement has no speed assigned to its robo: " + Owner.name);
        }
        
    }
}
