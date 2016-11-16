using UnityEngine;
using System.Collections;

public class Valla : MonoBehaviour 
{
    public float VelocidadSalto = 3;

    void OnTriggerEnter(Collider coll)
    {
        
        if(coll.tag == "Player") 
        {

            NavMeshAgent agente = coll.GetComponent<NavMeshAgent>();
            if(agente.velocity.magnitude >= VelocidadSalto) 
            {
                Debug.Log("Saltar");

                MovimientoBasico mov = coll.GetComponent<MovimientoBasico>();
                mov.Saltar();
            }
        }
    }
}
