using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : EnemyMovement {

    //void OnEnable()
    //{
    //    Move(GameManager.instance.player.transform.position);
    //}

    public override void Move(Vector2 _position)
    {
        Vector2 direction = _position - (Vector2)t.position;
        direction = direction.normalized;

        rb.AddForce(direction * speed);
    }
}