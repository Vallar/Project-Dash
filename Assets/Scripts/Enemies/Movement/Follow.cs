using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : EnemyMovement {

    public override void Move(Vector2 _position)
    {
        Vector2 direction = _position - (Vector2)t.position;
        direction = direction.normalized;


        rb.MovePosition(Vector2.Lerp(rb.position, rb.position + (direction * speed * Time.fixedDeltaTime), lerpRate));
    }
}