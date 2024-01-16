using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuakeAttack : MonoBehaviour
{
    // 이동 관련 변수
    public float speed; // 이동 속도
    public float lifeTime; // 생존 시간
    public float angle = 10f; // 공격 각도 범위

    // 크기 애니메이션 변수
    public Vector3 startSize = new Vector3(0.1f, 0.1f, 1.0f); // 시작 크기
    public Vector3 targetSize = new Vector3(1.0f, 1.0f, 1.0f); // 목표 크기

    // 색상 애니메이션 변수
    public Color startColor = new Color(1.0f, 1.0f, 1.0f, 1.0f); // 시작 색상
    public Color targetColor = new Color(1.0f, 0.0f, 0.0f, 1.0f); // 목표 색상
    public Color finalColor = new Color(0.0f, 0.0f, 0.0f, 0.0f); // 최종 색상

    // 애니메이션 지속 시간 변수
    public float animationDuration = 2.0f; // 크기 애니메이션 지속 시간
    public float fadeDuration = 2.0f; // 색상 페이드 애니메이션 지속 시간
    public float moveSpeed = 4.0f; // 이동 속도

    private float elapsedTime = 0.0f; // 경과 시간

    private Vector3 originalSize; // 초기 크기
    private Color originalColor; // 초기 색상

    private float attackAngle; // 공격 각도

    // Start is called before the first frame update
    void Start()
    {
        // 먼지를 시간에 맞게 지운다
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

    // 색상 애니메이션 함수
    void AnimateColor()
    {
        elapsedTime += Time.deltaTime;

        float t = Mathf.Clamp01(elapsedTime / fadeDuration);
        Color newColor = Color.Lerp(originalColor, targetColor, t);

        SetObjectColor(newColor);
    }

    // 크기 애니메이션 함수
    void AnimateSize()
    {
        elapsedTime += Time.deltaTime;


    }

    // 객체의 색상 설정 함수
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
