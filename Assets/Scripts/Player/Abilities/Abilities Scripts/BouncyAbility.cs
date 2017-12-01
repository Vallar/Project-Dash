using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "Abilities/Bouncy")]
public class BouncyAbility : Ability
{
    [SerializeField] private PhysicsMaterial2D bouncyMaterial;
    private Rigidbody2D rb;

    //protected override void Awake()
    //{
    //    base.Awake();
    //    rb = GetComponent<Rigidbody2D>();
    //}

    public void GetRigidBody2D(Rigidbody2D _rb)
    {
        rb = _rb;
    }

    protected override void ApplyEffect()
    {
        if (rb == null)
            Debug.Log("You need to call GetRigidBody2D() on this ability before you an use it!");
        rb.sharedMaterial = bouncyMaterial;
    }
}
