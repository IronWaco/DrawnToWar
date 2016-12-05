using UnityEngine;
using System.Collections;

public class Zombie : MonoBehaviour 
{
    public int Salud = 100;
    public int DanhoZarpaso = 30;

    NavMeshAgent agente;
    bool atacando;

	void Start () 
    {
        agente = GetComponent<NavMeshAgent>();
        atacando = false;
	}
	
	void Update () 
    {
	
	}

    public void RecibirDisparo(int danho)
    {
        Salud  = Salud -  danho;

        if(Salud < 0) {
            Destroy(agente);

            Rigidbody rb = GetComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.useGravity = true;
            rb.constraints = ~RigidbodyConstraints.FreezeAll;

            rb.AddRelativeTorque(1000f, 0, 0);

            Destroy(rb, 4f);
            Destroy(gameObject, 10f);
            Destroy(this);
        }
    }


    void OnTriggerStay(Collider otro)
    {
        if(otro.tag == "Player" && !atacando) {
            agente.SetDestination(otro.transform.position);
        }
    }


    public void OnCollisionEnter(Collision coll)
    {
        if(coll.collider.tag == "Player") {
            StartCoroutine(Zarpaso(coll.gameObject));    
        }
    }

    IEnumerator Zarpaso(GameObject player)
    {
        atacando = true;
        ControladorSoldado control = player.GetComponent<ControladorSoldado>();
        control.RecibirZarpaso(DanhoZarpaso);

        yield return new WaitForSeconds(1f);

        atacando = false;
    }
}
