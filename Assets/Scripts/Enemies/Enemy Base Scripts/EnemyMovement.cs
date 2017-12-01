using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    public bool moveTowardsPlayer = true;
    
    [SerializeField] protected float speed;
    [SerializeField] protected float range = 2.5f;
    [SerializeField] protected float lerpRate = 0.15f;
    protected bool isMoving = false;
    protected Rigidbody2D rb;
    protected EnemyStats stats;
    protected Transform t;
    
    protected void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        stats = GetComponent<EnemyStats>();
        t = transform;
    }

    public virtual void Move(Vector2 _position)
    {
    }    
}