using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoboMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;

    public void Move(Vector2 move)
    {
        rb.velocity = speed * Vector2.Lerp(move.normalized, rb.velocity.normalized, 0.1f);
    }

    public void Look(Vector2 direction)
    {
        rb.SetRotation(rb.rotation + Vector2.SignedAngle(rb.transform.forward, direction));
    }
}
