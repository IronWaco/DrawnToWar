using UnityEngine;
using System.Collections;

public class ForWard : MonoBehaviour {

    public float Vel=20f;

	void Start () {
	
	}
	
	void Update () {
        transform.position=transform.forward*Vel+transform.position;

	
	}
}
