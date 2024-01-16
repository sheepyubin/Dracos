using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Boids/Behavior/Alignment")]
// ���� ��Ģ
public class AlignmentBehavior : BoidsBehavior
{
    public override Vector2 CalculateMove(BoidsAgent agent, List<Transform> context, Boids boid)
    {
        // �ֺ��� ��ü�� ������ �״�� �̵���
        if (context.Count == 0)
        {
            return agent.transform.up;
        }

        // �̵� ����
        Vector2 alignmentMove = Vector2.zero;

        // �ֺ��� �ִ� ��ü���� ��ġ�� ����
        foreach (Transform item in context)
        {
            alignmentMove += (Vector2)item.transform.up;
        }

        // �ֺ� ��ü���� ��� ���� ���
        alignmentMove /= context.Count;

        // �̵� ���� ��ȯ
        return alignmentMove;
    }
}
