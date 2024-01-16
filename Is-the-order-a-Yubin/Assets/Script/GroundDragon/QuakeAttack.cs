using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuakeAttack : MonoBehaviour
{
    // �̵� ���� ����
    public float speed; // �̵� �ӵ�
    public float lifeTime; // ���� �ð�
    public float angle = 10f; // ���� ���� ����

    // ũ�� �ִϸ��̼� ����
    public Vector3 startSize = new Vector3(0.1f, 0.1f, 1.0f); // ���� ũ��
    public Vector3 targetSize = new Vector3(1.0f, 1.0f, 1.0f); // ��ǥ ũ��

    // ���� �ִϸ��̼� ����
    public Color startColor = new Color(1.0f, 1.0f, 1.0f, 1.0f); // ���� ����
    public Color targetColor = new Color(1.0f, 0.0f, 0.0f, 1.0f); // ��ǥ ����
    public Color finalColor = new Color(0.0f, 0.0f, 0.0f, 0.0f); // ���� ����

    // �ִϸ��̼� ���� �ð� ����
    public float animationDuration = 2.0f; // ũ�� �ִϸ��̼� ���� �ð�
    public float fadeDuration = 2.0f; // ���� ���̵� �ִϸ��̼� ���� �ð�
    public float moveSpeed = 4.0f; // �̵� �ӵ�

    private float elapsedTime = 0.0f; // ��� �ð�

    private Vector3 originalSize; // �ʱ� ũ��
    private Color originalColor; // �ʱ� ����

    private float attackAngle; // ���� ����

    // Start is called before the first frame update
    void Start()
    {
        // ������ �ð��� �°� �����
        Destroy(gameObject, lifeTime);
        attackAngle = Random.Range(-angle, angle);
    }

    // Update is called once per frame
    void Update()
    {
        float z = transform.rotation.eulerAngles.z;
        Vector2 direction = new Vector2(Mathf.Cos(z * Mathf.Deg2Rad + attackAngle), Mathf.Sin(z * Mathf.Deg2Rad + attackAngle));
        GetComponent<Rigidbody2D>().velocity = direction * speed;
        AnimateColor();
        AnimateSize();
    }

    // ���� �ִϸ��̼� �Լ�
    void AnimateColor()
    {
        elapsedTime += Time.deltaTime;

        float t = Mathf.Clamp01(elapsedTime / fadeDuration);
        Color newColor = Color.Lerp(originalColor, targetColor, t);

        SetObjectColor(newColor);
    }

    // ũ�� �ִϸ��̼� �Լ�
    void AnimateSize()
    {
        elapsedTime += Time.deltaTime;


    }

    // ��ü�� ���� ���� �Լ�
    void SetObjectColor(Color newColor)
    {
        Renderer renderer = GetComponent<Renderer>();

        if (renderer != null)
        {
            renderer.material.color = newColor;
        }
        else
        {
            Debug.LogWarning("Renderer not found. Make sure the object has a Renderer component.");
        }
    }
}
