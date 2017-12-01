using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MovementEffects;

public class Projectile : MonoBehaviour {

    public int damage;
    public Vector2 targetPosition;
    public bool isPlayerOwner;
    [SerializeField] private float timeToLive = 3f;
    [SerializeField] private float forceAmount = 150f;
    private Rigidbody2D rb;
    private Collider2D col;
    private Transform t;


    void Awake()
    {
        t = transform;
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    void OnEnable()
    {
        col.enabled = true;
        Timing.RunCoroutine(StartDisableSequence());
    }

    public void MoveToTarget()
    {
        Vector2 direction = targetPosition - (Vector2)t.position;
        direction = direction.normalized;

        rb.AddForce(forceAmount * direction);
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (isPlayerOwner)
            if (other.transform.CompareTag("Enemy"))
                other.transform.GetComponent<EnemyStats>().ReduceHealth(damage);
        else
            if (other.transform.CompareTag("Player"))
                other.transform.GetComponent<PlayerStats>().ReduceHealth(damage);

        DisableProjectile();
    }

    private IEnumerator<float> StartDisableSequence()
    {
        yield return Timing.WaitForSeconds(timeToLive);

        DisableProjectile();
    }

    public void DisableProjectile()
    {
        col.enabled = false;
        gameObject.SetActive(false);
        //TODO: Add some effects
    }
}