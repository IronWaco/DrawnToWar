using UnityEngine;
using System.Collections;

public class Enemigo : MonoBehaviour 
{
    Animator _anim;
    NavMeshAgent _agent;
    DetectorAdelante _detectorAdelante;
    public float _hp;
    //public RectTransform UISalud;



    [HideInInspector]
    public bool DandoGolpe;


    void Start () 
    {
        _anim = GetComponent<Animator>();
        _detectorAdelante = GetComponentInChildren<DetectorAdelante>();
        _hp = 100;
        DandoGolpe = false;
        _agent = GetComponent<NavMeshAgent>();
        StartCoroutine(CicloGolpe());
    }


	
	void Update () 
    {
        if (_hp <= 0)
        {
            _agent.enabled = false;
            _anim.SetTrigger("Muerto");
            Destroy(gameObject, 3);
        }

       // UISalud.localScale = new Vector3((_hp/100f), 1, 1);



        HayAlguien = (_detectorAdelante.Personaje != null);
        PuedeDarGolpe = (DandoGolpe == false);
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


    public void DarGolpe(GameObject player)
    {

        
    }

    public bool HayAlguien;
    public bool PuedeDarGolpe;


    IEnumerator CicloGolpe()
    {
        while(true) {
            yield return new WaitUntil( () => {
                return HayAlguien && PuedeDarGolpe;
            });
        
            _anim.SetTrigger("DarGolpe");
        }
    }
    public void Danho()
    {
        if (HayAlguien)
        {
            MovimientoBasico Mb= _detectorAdelante.Personaje.GetComponent<MovimientoBasico>();
            Mb.Danho(10);
        }
    }
}
