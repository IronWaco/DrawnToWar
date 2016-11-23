using UnityEngine;
using System.Collections;

public class Enemigo : MonoBehaviour 
{
    Animator _anim;

	void Start () {
        _anim = GetComponent<Animator>();
	}
	
	void Update () {
	}

    public void  RecibirGolpe(int cantidadDanho)
    {
        _anim.SetTrigger("Golpe");
    }
}
