using UnityEngine;
using System.Collections;

public class Parkour : MonoBehaviour {
    public Animator anim;
    public float Fuerza = 100f;

    Rigidbody rig;

    MovimientoBasico Mov;

	void Start () {
        rig=GetComponent<Rigidbody>();

        Mov=GetComponent<MovimientoBasico>();
	}
	
	void Update () {

	    
	}
    void OnTriggerEnter(Collider C)
    {
        if (C.tag == "Valla")
        {
            if(Mov.corriendo)
            {
                anim.SetBool("Saltar", true);
                rig.AddForce(0, Fuerza, 0);
                
            }
            else
                anim.SetBool("Saltar", false);
        }
        
    }
    void OnTriggerExit(Collider C)
    {
        if (C.tag == "Valla")
        {
            if (Mov.corriendo)
            {
 
                anim.SetBool("Saltar", false);
            }
            
        }

    }

}
