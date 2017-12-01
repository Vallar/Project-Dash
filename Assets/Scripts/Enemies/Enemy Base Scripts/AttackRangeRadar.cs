using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRangeRadar : MonoBehaviour {

    private SlowBrute brute;
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        brute = transform.parent.GetComponent<SlowBrute>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            brute.AttackPlayer();
        }
    }
}