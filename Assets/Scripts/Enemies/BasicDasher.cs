using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MovementEffects;

public class BasicDasher : MonoBehaviour {

    private EnemyMovement movement;
    private EnemyStats stats;

    void Awake()
    {
        movement = GetComponent<EnemyMovement>();
        stats = GetComponent<EnemyStats>();

        movement.moveTowardsPlayer = true;
    }


    void Start()
    {
        Timing.RunCoroutine(BeginPursue());
    }

    private IEnumerator<float> BeginPursue()
    {
        yield return Timing.WaitForSeconds(stats.tellTimer + Random.Range(0, 0.35f)); // The extra random time to make sure the enemies don't attack at the same exact time.

        movement.Move(GameManager.instance.player.transform.position);

        yield return Timing.WaitForSeconds(stats.actionRechargeTime);

        Timing.RunCoroutine(BeginPursue());
    }

}