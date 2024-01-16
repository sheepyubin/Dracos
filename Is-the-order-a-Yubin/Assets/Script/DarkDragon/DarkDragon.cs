using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public enum DarkDragonState
{
    Idle = 0,       //´ë±â
    TailAttack,     //²¿¸®ÆòÅ¸
    ClawsAttack,    //¹ßÅéÆòÅ¸
    FireCircle,     //¿øÇüºÒ
    EattingMob,     //¸ÔÀÌ ²ø¾î´ç±â±â
    CircleShoot,    //¿øÇüÈ­¿°±¸
    FanShoot        //ºÎÃ¤²ÃÈ­¿°±¸
}
public class DarkDragon : MonoBehaviour
{
    public GameObject prfFire;
    public Transform target;
    Vector3 whereToAtk;
    Vector3 playerPos;


    private DarkDragonState dragonState;

    // Start is called before the first frame update
    private void Awake()
    {
        ChangeState(DarkDragonState.Idle);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1")) ChangeState(DarkDragonState.Idle);
        else if (Input.GetKeyDown("2")) ChangeState(DarkDragonState.TailAttack);
        else if (Input.GetKeyDown("3")) ChangeState(DarkDragonState.ClawsAttack);
        else if (Input.GetKeyDown("4")) ChangeState(DarkDragonState.FireCircle);
        else if (Input.GetKeyDown("5")) ChangeState(DarkDragonState.EattingMob);
        else if (Input.GetKeyDown("6")) ChangeState(DarkDragonState.CircleShoot);
        else if (Input.GetKeyDown("7")) ChangeState(DarkDragonState.FanShoot);

    }
    private void ChangeState(DarkDragonState newState)
    {
        StopCoroutine(dragonState.ToString());
        dragonState = newState;
        StartCoroutine(dragonState.ToString());
    }

    private IEnumerator Idle()
    {
        Debug.Log("ºñÀüÅõ¸ðµå");

        while (true)
        {
            Debug.Log("ÀÌµ¿Áß");
            yield return null;
        }
    }
    private IEnumerator TailAttack()
    {
        Debug.Log("²¿¸®ÆòÅ¸");

        while (true)
        {
            Debug.Log("½Ø¾×");
            ChangeState(DarkDragonState.Idle);
            yield return null;
        }
    }

    private IEnumerator ClawsAttack()
    {
        Debug.Log("¹ßÅéÆòÅ¸");

        while (true)
        {
            Debug.Log("Äá");
            ChangeState(DarkDragonState.Idle);
            yield return null;
        }
    }

    private IEnumerator FireCircle()
    {
        int i = 1;
        Debug.Log("È­¿°");

        while (true)
        {
            if (i == 3) ChangeState(DarkDragonState.Idle); i++;
            Debug.Log("¶Ñ½Ã¶Ñ½Ã");
            yield return new WaitForSeconds(1);
        }
        
    }

    private IEnumerator EattingMob()
    {
        int i = 1;
        Debug.Log("¸ÔÀÌ²ø¾î´ç±â±â");

        while (true)
        {
            if (i == 3) ChangeState(DarkDragonState.Idle); i++;
            Debug.Log("Äí¿Í¾Æ¾Ó");
            yield return new WaitForSeconds(1);
        }
    }

    private IEnumerator CircleShoot()
    {
        int i = 1;
        Debug.Log("¿øÇüÈ­¿°±¸");

        while (true)
        {
            if (i == 3) ChangeState(DarkDragonState.Idle); i++;
            fire();
            Debug.Log("Åäµµµµµ¾");
            yield return new WaitForSeconds(1);
        }
    }

    private IEnumerator FanShoot()
    {
        int i = 1;
        Debug.Log("ºÎÃ¤²ÃÈ­¿°±¸");

        while (true)
        {
            if (i == 3) ChangeState(DarkDragonState.Idle); i++;
            Debug.Log("½¹½¹½¹½¹");
            yield return new WaitForSeconds(1);
        }
    }

    void fire()
    {
        for(int i = 0; i < 10; i++)
        {
            GameObject fire =
                Instantiate(prfFire, transform.position, transform.rotation);
            Rigidbody2D rigid = fire.GetComponent<Rigidbody2D>();
            rigid.AddForce(vector * 10, ForceMode2D.Impulse);
        }
    }

}
