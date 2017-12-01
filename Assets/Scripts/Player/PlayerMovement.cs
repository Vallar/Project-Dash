using UnityEngine;
using System.Collections;
using MovementEffects;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{
    public bool isMoving = true;

    [SerializeField] private float lerpRate = 0.15f;
    private Vector2 targetPosition;
    private PlayerStats stats;
    private PlayerCollision collision;
    private Rigidbody2D rb;
    private Transform t;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        stats = GetComponent<PlayerStats>();
        collision = GetComponent<PlayerCollision>();
        t = transform;
    }

    public void MovePlayer(Vector2 _position)
    {
        targetPosition = _position;
        Timing.RunCoroutine(MoveCoroutine(_position), "movement");
    }

    public void StopPlayer()
    {
        Timing.KillCoroutines("movement");
        isMoving = false;
    }

    private IEnumerator<float> MoveCoroutine(Vector2 _targetPosition)
    {
        isMoving = true;

        if (Vector2.Distance (_targetPosition, t.position) > stats.range)
        {
            Vector2 offset = targetPosition - (Vector2)t.position;
            offset = Vector2.ClampMagnitude(offset, stats.range);

            targetPosition = (Vector2)t.position + offset;
        }

        while (Vector2.Distance(targetPosition, t.position) > 0.05f)
        {
            collision.DetectWall(targetPosition);
            rb.MovePosition(Vector2.Lerp(t.position, targetPosition, lerpRate));
            yield return Timing.WaitForOneFrame;
        }

        isMoving = false;
    }
}
