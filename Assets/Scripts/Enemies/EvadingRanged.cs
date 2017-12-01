using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MovementEffects;

public class EvadingRanged : MonoBehaviour {

    [SerializeField] private float evadingRange = 2f;
    private EnemyMovement movement;
    private EnemyAttack attack;
    private EnemyStats stats;
    private Transform t;

    void Awake()
    {
        movement = GetComponent<EnemyMovement>();
        attack = GetComponent<EnemyAttack>();
        stats = GetComponent<EnemyStats>();
        t = transform;

        movement.moveTowardsPlayer = false;
    }

    void Start()
    {
        Timing.RunCoroutine(StartEnemyCoroutine());
    }

    private IEnumerator<float> StartEnemyCoroutine()
    {
        yield return Timing.WaitForSeconds(stats.tellTimer);

        attack.Attack();

        if (Vector2.Distance(GameManager.instance.player.transform.position, t.position) < evadingRange)
        {
            yield return Timing.WaitForSeconds(stats.tellTimer);

            movement.Move(GameManager.instance.player.transform.position);
        }

        yield return Timing.WaitForSeconds(stats.actionRechargeTime);

        Timing.RunCoroutine(StartEnemyCoroutine());
    }
}