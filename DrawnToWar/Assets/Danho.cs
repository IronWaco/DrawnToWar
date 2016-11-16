using UnityEngine;
using System.Collections;

public class Danho : MonoBehaviour 
{
    public float Cantidad = 10f;

    void OnTriggerStay(Collider coll)
    {
        if(coll.tag=="Enemy")
        {
            Hit Hit = coll.GetComponent<Hit>();
            if(Input.GetKeyDown(KeyCode.Space))
            {
                Hit.HacerDanho(Cantidad);
            }
        }
    }
}
