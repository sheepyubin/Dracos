using System.Collections;
using UnityEngine;

public class GroundDragonMove : MonoBehaviour
{
    public Transform Player;
    public float speed = 1;
    public double stoppingDistance = 3;

    // ���ݿ� ���� �� ������
    public GameObject stonePrefab;
    public Transform sPoint;
    public float timeBetweenShots;

    private float shotTime;
    // ���� ���� ������ ��Ÿ���� �÷���
    private bool isAttacking = false;

    private float attackInterval = 3f;
    void Update()
    {
        if (Player != null)
        {
            // �÷��̾� �������� ȸ��
            Vector3 directionToPlayer = Player.position - transform.position;
            float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

            // �÷��̾���� �Ÿ� ���
            float distanceToPlayer = Vector3.Distance(transform.position, Player.position);

            // ���� �Ÿ����� �ָ� �ְ� ���� ���� �ƴ� ��쿡�� �̵�
            if (distanceToPlayer > stoppingDistance && !isAttacking)
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
        }
        else
        {
            Debug.LogWarning("Player reference is null. Assign a player to the GroundDragonMove script in the Inspector.");
        }

        // 3�� �������� ���콺 ���� ��ư�� ������ �� ���� �ڷ�ƾ ����
        //attackInterval -= Time.deltaTime;
        if (attackInterval <= 0f && Input.GetMouseButtonDown(0))
        {
            if (Time.time >= shotTime)
            {
                isAttacking = true;
                //�Ѿ� ����
                Instantiate(stonePrefab, transform.position, Quaternion.identity);
                //������ �Ѿ� ������
                shotTime = Time.time + timeBetweenShots;

            }
            isAttacking = false;
        }
    }
}

