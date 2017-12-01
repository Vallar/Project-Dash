using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MovementEffects;

public class PlayerCollision : MonoBehaviour {

    [SerializeField] private LayerMask layerMask;
    private PlayerMovement movement;
    private PlayerStats stats;
    private Transform t;

    void Awake()
    {
        t = transform;
        movement = GetComponent<PlayerMovement>();
        stats = GetComponent<PlayerStats>();
    }

    public void DetectWall(Vector2 _endPosition)
    {
        Vector2 direction = _endPosition - (Vector2)t.position;
        direction = direction.normalized;

        RaycastHit2D hit = Physics2D.Raycast(t.position, direction, 1, layerMask);
        Debug.DrawLine(t.position, _endPosition, Color.red);

        if (hit)
        {
            //if (hit.transform.CompareTag("Enemy"))
            //    Timing.RunCoroutine(DisableTrigger());
            if (hit.transform.CompareTag("Wall"))
                Timing.RunCoroutine(EnableMovement());
        }
    }

    //private IEnumerator<float> DisableTrigger()
    //{
    //    col.isTrigger = true;

    //    yield return Timing.WaitForSeconds(0.025f);
        
    //    col.isTrigger = true;
    //}

    private IEnumerator<float> EnableMovement()
    {
        yield return Timing.WaitForSeconds(0.025f);

        movement.StopPlayer();
    }

    void OnTriggerEnter2D(Collider2D other)
    { 
        if (other.CompareTag("Enemy") && movement.isMoving)
        {
            other.GetComponent<EnemyStats>().ReduceHealth(stats.damage);
        }
        else if (other.CompareTag("Enemy") && movement.isMoving == false)
        {
            stats.ReduceHealth(other.GetComponent<EnemyStats>().damage);
        }
        else if (other.CompareTag("Hope"))
        {
            GameManager.instance.hope += 1;
            other.gameObject.SetActive(false);
        }
    }
}