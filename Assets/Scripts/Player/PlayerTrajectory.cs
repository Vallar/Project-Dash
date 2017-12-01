using UnityEngine;
using System.Collections;

public class PlayerTrajectory : MonoBehaviour
{

    private LineRenderer lr;
    private Transform t; 

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
        t = transform;
    }

    public void DrawTrajectory(Vector2 _endPosition)
    {
        lr.SetPosition(0, t.position);
        lr.SetPosition(1, _endPosition);
    }
}
