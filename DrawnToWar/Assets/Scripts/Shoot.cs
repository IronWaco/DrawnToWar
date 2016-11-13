using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {
    public GameObject Bala;

	void Start () {
	
	}
	
	void Update () {
        bool Disparando = Input.GetMouseButtonDown(0);
        if (Disparando)
        {
            GameObject Balas = (GameObject)Instantiate(Bala, transform.position, transform.rotation);
            Destroy(Balas, 5);
        }
	    
	}
}
