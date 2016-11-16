using UnityEngine;
using System.Collections;

public class Hit : MonoBehaviour {
    public float Hp;

	void Start () {
        Hp = 100;
	}
	
	void Update () {
        if(Hp<=0)
        {
            Destroy(gameObject, 1);
        }
	
	}
    void OnTriggerEnter(Collider C)
    {
        if(C.tag=="Alzable")
        {
            Rigidbody rig = C.GetComponent<Rigidbody>();
            Hp = Hp - rig.velocity.magnitude;
            
        }
    }
    public void HacerDanho(float Danho)
    {
        Hp = Hp - Danho;
    }
}
