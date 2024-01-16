using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Boids/Behavior/Stay In Radius")]
public class StayInRadiusBehavior : BoidsBehavior
{
    public Vector2 center;
    public float radius = 15;
    public override Vector2 CalculateMove(BoidsAgent agent, List<Transform> context, Boids flock)
    {
        Vector2 centerOffset = center - (Vector2)agent.transform.position;
        float t = centerOffset.magnitude / radius;
        if (t < 0.9f)
        {
            return Vector2.zero;
        }

        return centerOffset * t * t;
    }
}
