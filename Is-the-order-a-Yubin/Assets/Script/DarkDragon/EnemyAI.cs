using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform target;
    float attackDelay;

    Enemy enemy;
    Animator enemyAnimator;
    void Start()
    {
        enemy = GetComponent<Enemy>();
    //    //enemyAnimator = enemy.//enemyAnimator;
    }

    void Update()
    {
        attackDelay -= Time.deltaTime;
        if (attackDelay < 0) attackDelay = 0;

        // Ÿ�ٰ� �ڽ��� �Ÿ��� Ȯ��
        float distance = Vector3.Distance(transform.position, target.position);

        // ���� ������(��Ÿ��)�� 0�� ��, �þ� �����ȿ� ���� ��
        if (attackDelay == 0 && distance <= enemy.fieldOfVision)
        {
            FaceTarget(); // Ÿ�� �ٶ󺸱�

            // ���� �����ȿ� ���� �� ����
            if (distance <= enemy.atkRange)
            {
                AttackTarget();
            }
            else // ���� �ִϸ��̼� ���� ���� �ƴ� �� ����
            {
                    MoveToTarget();
            }
        }
        else // �þ� ���� �ۿ� ���� �� Idle �ִϸ��̼����� ��ȯ
        {
            //enemyAnimator.SetBool("moving", false);
        }
    }

    void MoveToTarget()
    {
        float dir = target.position.x - transform.position.x;
        float dird = target.position.y - transform.position.y;
        dir = (dir < 0) ? -1 : 1;
        transform.Translate(new Vector3(dir, dird) * enemy.moveSpeed * Time.deltaTime);
        //enemyAnimator.SetBool("moving", true);
    }

    void FaceTarget()
    {
        if (target.position.x - transform.position.x < 0) // Ÿ���� ���ʿ� ���� ��
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else // Ÿ���� �����ʿ� ���� ��
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    void AttackTarget()
    {
        target.GetComponent<MoveScript>().nowHp -= enemy.atkDmg;
        //enemyAnimator.SetTrigger("attack"); // ���� �ִϸ��̼� ����
        attackDelay = enemy.atkSpeed; // ������ ����
    }
}
