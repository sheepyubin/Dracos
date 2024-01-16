using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirPrf : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("ªË¡¶µ ");
            Destroy(gameObject);
        }
    }

}
