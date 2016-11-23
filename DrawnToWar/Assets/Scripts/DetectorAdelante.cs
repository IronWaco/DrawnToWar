using UnityEngine;
using System.Collections;

public class DetectorAdelante : MonoBehaviour 
{
    public GameObject Enemigo;

    void OnTriggerEnter(Collider coll)
    {
        if(coll.tag=="Enemy")
        {
            Enemigo = coll.gameObject;
        }
    }

    void OnTriggerExit(Collider coll)
    {
        if(coll.tag=="Enemy")
        {
            Enemigo = null;
        }
    }
}
