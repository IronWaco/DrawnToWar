using UnityEngine;
using System.Collections;

public class Enemigo : MonoBehaviour 
{
    Animator _anim;
    public float _hp;

    void Start () {
        _anim = GetComponent<Animator>();
        _hp = 100;
    }
	
	void Update () {
        if (_hp <= 0)
        {
            _anim.SetTrigger("Muerto");
            Destroy(gameObject, 3);
        }
    }
    void OnTriggerEnter(Collider C)
    {
        if (C.tag == "Alzable")
        {
            _anim.SetTrigger("Golpe");
            Rigidbody rig = C.GetComponent<Rigidbody>();
            _hp = _hp - rig.velocity.magnitude*2f;

        }
    }
    public void HacerDanho(float Danho)
    {
        _hp = _hp - Danho;
    }

    public void  RecibirGolpe(int cantidadDanho)
    {
        _hp = _hp - cantidadDanho;
        _anim.SetTrigger("Golpe");
        
    }
}
