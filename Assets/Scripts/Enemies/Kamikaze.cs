using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MovementEffects;

public class Kamikaze : MonoBehaviour {

    private bool inPlayerRange = false;
    private EnemyStats stats;
    private EnemyMovement movement;
    private Transform t;

    void Awake()
    {
        stats = GetComponent<EnemyStats>();
        movement = GetComponent<EnemyMovement>();
        t = transform;
    }

    void OnEnable()
    {
        inPlayerRange = false;
    }

    void FixedUpdate()
    {
        if (Vector2.Distance(t.position, GameManager.instance.player.transform.position) > stats.attackRange && inPlayerRange == false)
            movement.Move(GameManager.instance.player.transform.position);
        else if (Vector2.Distance(t.position, GameManager.instance.player.transform.position) <= stats.attackRange && inPlayerRange == false)
        {
            inPlayerRange = true;
            Timing.RunCoroutine(KamikazeSelf());
        }
    }


    private IEnumerator<float> KamikazeSelf()
    {
        yield return Timing.WaitForSeconds(stats.tellTimer);

        //TODO: Show explosion with bells and whistles.

        if (Vector2.Distance(t.position, GameManager.instance.player.transform.position) <= stats.attackRange)
            GameManager.instance.player.GetComponent<PlayerStats>().ReduceHealth(stats.damage);
    }

}