using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneShot : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    // Start is called before the first frame update
    void Start()
    {
        // ���� �ð��� �°� �����
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        //�ð� �����Ӱ� speed�� ���� y�� �������� �����δ�
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
}
