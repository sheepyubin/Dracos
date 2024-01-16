using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �и� ��Ģ
[CreateAssetMenu(menuName = "Boids/Behavior/Separation")]
public class SeparationBehavoior : BoidsBehavior
{
    public override Vector2 CalculateMove(BoidsAgent agent, List<Transform> context, Boids boid)
    {
        // ��ó�� ��ü�� ���ٸ� �������� ����
        if (context.Count == 0)
        {
            return Vector2.zero;
        }

        // �̵� ����
        Vector2 separationMove = Vector2.zero;

        // ��ó�� �ִ� ��ü�� ��
        int nSeparation = 0;

        // �ֺ� ��ü���� �˻��Ͽ� �ൿ ����
        foreach (Transform i in context)
        {
            if (Vector2.SqrMagnitude(i.position - agent.transform.position) < boid.SquareAvoidanceRadius)
            {
                nSeparation++;
                separationMove += (Vector2)(agent.transform.position - i.position);
            }
        }

        // ��ó�� ��ü�� �����ϸ� �̵� ���͸� ��ó ��ü�� ��� �������� ����
        if (nSeparation > 0)
        {
            separationMove /= nSeparation;
        }

        // �̵� ���� ��ȯ
        return separationMove;
    }
}
