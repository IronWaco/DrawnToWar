using UnityEngine;
using System.Collections;

public class Bala : MonoBehaviour 
{
    public float Velocidad;
    public int CantidadDeDanho = 10;

	void Start () 
    {
	    
	}
	
	
	void Update () 
    {
        transform.Translate(0, 0, Velocidad * Time.deltaTime);
	}


    void OnCollisionEnter(Collision coll)
    {
        Debug.Log(coll.collider.name);

        if(coll.collider.tag == "Zombie"){
            Zombie z = coll.collider.GetComponent<Zombie>();
            if(z != null) {
                z.RecibirDisparo(CantidadDeDanho);
            }
        }


        Destroy(transform.parent.gameObject);
    }
}
