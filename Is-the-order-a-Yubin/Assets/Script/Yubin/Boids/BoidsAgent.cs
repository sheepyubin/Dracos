using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class BoidsAgent : MonoBehaviour
{
    Collider2D boidCollider;
    public Collider2D BoidCollider { get { return boidCollider; } }

    private void Start()
    {
        boidCollider = GetComponent<Collider2D>();
    }

    // Move()�� Boid ��ü�� �־��� �ӵ��� �̵���Ű�� �޼���
    // Parameters:
    // - velocity: Boid ��ü�� �̵��� ����� �ӵ��� ��Ÿ���� ����
    public void Move(Vector2 velocity)
    {
        // ��ü�� ������ velocity�� ����
        transform.up = velocity;

        transform.position += (Vector3)velocity * Time.deltaTime;
    }
}
