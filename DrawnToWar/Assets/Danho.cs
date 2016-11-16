using UnityEngine;
using System.Collections;

public class Danho : MonoBehaviour {
    public float Danio = 10f;


	void Start () {
	
	}
	
	void Update () {
	
	}

    void OnTriggerStay(Collider C)
    {
        if(C.tag=="Enemy")
        {
            Hit Hit = C.GetComponent<Hit>();
            if(Input.GetKeyDown(KeyCode.Space))
            {
                Hit.HacerDanho(Danio);
            }
        }
    }
}
