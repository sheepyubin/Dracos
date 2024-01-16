using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Boids/Behavior/Cohesion")]
public class CohesionBehavior : BoidsBehavior
{
    public override Vector2 CalculateMove(BoidsAgent agent, List<Transform> context, Boids boid)
    {
        // ��ó�� ���ٸ� 0�� ��ȯ
        if(context.Count == 0)
        {
            return Vector2.zero;
        }

        Vector2 cohesionMove = Vector2.zero;
        foreach(Transform item in context)
        {
            cohesionMove += (Vector2)item.position;
        }
        cohesionMove /= context.Count;

        cohesionMove -= (Vector2)agent.transform.position;
        return cohesionMove;
    }
}
