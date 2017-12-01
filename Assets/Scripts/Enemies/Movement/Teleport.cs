using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : EnemyMovement {

    public override void Move(Vector2 _position)
    {
        Vector2 newPosition = (Vector2)GameManager.instance.player.transform.position + Random.insideUnitCircle;
        
        if (newPosition == (Vector2)GameManager.instance.player.transform.position)
        {
            newPosition += new Vector2(0.15f, 0);
        }

        t.position = newPosition;
    }
}