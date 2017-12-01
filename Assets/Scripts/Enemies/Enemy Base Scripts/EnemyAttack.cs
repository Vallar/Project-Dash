using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

    protected EnemyStats stats;
    protected Transform t;
    protected bool isRanged;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        stats = GetComponent<EnemyStats>();
        t = transform;
    }

    public virtual void Attack()
    {
    }
}