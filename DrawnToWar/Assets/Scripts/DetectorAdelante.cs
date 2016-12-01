using UnityEngine;
using System.Collections;

public class DetectorAdelante : MonoBehaviour 
{
    public enum TipoPersonaje {Enemy, Player};

   
    public TipoPersonaje Tipo;
    public GameObject Personaje;


    void OnTriggerEnter(Collider coll)
    {
        if(coll.tag==Tipo.ToString())
        {
            Personaje = coll.gameObject;
        }
    }

    void OnTriggerExit(Collider coll)
    {
        if(coll.tag==Tipo.ToString())
        {
            Personaje = null;
        }
    }
}
