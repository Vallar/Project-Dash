using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MovementEffects;

public class PlayerInput : MonoBehaviour {

    [SerializeField] private float slowTimeAmount = 0.25f;
    private PlayerMovement movement;
    private PlayerTrajectory trajectory;
    private PlayerStats stats;
    private Camera mainCamera;
    private Transform t; 

    private void Awake()
    {
        movement = GetComponent<PlayerMovement>();
        t = transform;
        stats = GetComponent<PlayerStats>();
        trajectory = t.GetChild(0).GetComponent<PlayerTrajectory>();
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetButton("Fire1") && movement.isMoving == false)
        {
            Time.timeScale = slowTimeAmount;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;

            Vector2 position = mainCamera.ScreenToWorldPoint(Input.mousePosition);

            trajectory.gameObject.SetActive(true);

            if (Vector2.Distance(position, t.position) > stats.range)
            {
                Vector2 offset = position - (Vector2)t.position;
                offset = Vector2.ClampMagnitude(offset, stats.range);

                position = (Vector2)t.position + offset;
            }

            trajectory.DrawTrajectory(position);
        }

        if (Input.GetButtonUp("Fire1"))
        {
            if (Time.timeScale != 1)
            {
                Time.timeScale = 1;
                Time.fixedDeltaTime = 0.02f;
            }

            trajectory.gameObject.SetActive(false);

            if (movement.isMoving == false)
            {
                Vector2 position = mainCamera.ScreenToWorldPoint(Input.mousePosition);
                movement.MovePlayer(position);
            }
        }
    }
}