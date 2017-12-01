using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MovementEffects;

public class Dash : EnemyMovement {

    
    [SerializeField] private float directPursue; 
    public override void Move(Vector2 _position)
    {
        if (isMoving == false)
        {
            Vector2 targetPosition = GameManager.instance.player.transform.position;
            Timing.RunCoroutine(MoveCoroutine(targetPosition));
        }
    }

    private IEnumerator<float> MoveCoroutine(Vector2 _targetPosition)
    {
        isMoving = true;

        if (Vector2.Distance (_targetPosition, t.position) > range)
        {
            Vector2 offset = _targetPosition - (Vector2)t.position;
            offset = Vector2.ClampMagnitude(offset, range);

            _targetPosition = (Vector2)t.position + offset;
            _targetPosition += Random.insideUnitCircle;
        }
        
        while (Vector2.Distance(_targetPosition, t.position) > 0.05f)
        {
            //collision.DetectWall(_targetPosition);
            if (moveTowardsPlayer == false)
                rb.MovePosition(Vector2.Lerp(t.position, -_targetPosition, lerpRate));
            else
                rb.MovePosition(Vector2.Lerp(t.position, _targetPosition, lerpRate));
                
            yield return Timing.WaitForOneFrame;
        }

        isMoving = false;
    }
}