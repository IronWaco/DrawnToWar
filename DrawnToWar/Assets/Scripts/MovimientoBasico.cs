using UnityEngine;
using System.Collections;

public class MovimientoBasico : MonoBehaviour 
{
    public float VelocidadMaximaCaminar = 1;
    public float VelocidadMaximaCorrer = 3;
    public float GradosRotacion  = 3;
    public DetectorAdelante DetectorAdelante;

    public float _hp;


    public bool corriendo=false;
    Animator _anim;



    NavMeshAgent _agente;
    
    void Start () {

        _agente = GetComponent<NavMeshAgent>();
        _anim = GetComponent<Animator>();
        DetectorAdelante = GetComponentInChildren<DetectorAdelante>();
        _hp = 100;
        //Inicial = Vel;
        //anim = GetComponent<Animator>();

    }

    public float Vel;
	
	void Update () 
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        float velMaxima = VelocidadMaximaCaminar;
        if(Input.GetButton("Correr")){
            velMaxima = VelocidadMaximaCorrer;
        }

        if(Input.GetButtonDown("Golpear")){
            _anim.SetTrigger("Golpear");
        }

        _agente.velocity = transform.forward * (v * velMaxima);

        _anim.SetFloat("Vel",v * velMaxima);

        transform.Rotate(0, h * GradosRotacion, 0);
        if(_hp<=0)
        {
            _anim.SetTrigger("Muerto");
            _agente.enabled = false;


        }
    }


    public void Saltar()
    {
        _anim.SetTrigger("Saltar");
        _agente.enabled = false;
        _anim.applyRootMotion = true;
    }


    public void TerminarSaltar()
    {
        _agente.enabled = true;
        _anim.applyRootMotion = false;
    }


    public void RecibirGolpe()
    {
        if(DetectorAdelante.Personaje != null)
        {
            DetectorAdelante.Personaje.GetComponent<Enemigo>().RecibirGolpe(10);
        }
    }
    public void Danho(int D)
    {
        _hp = _hp - D;
        _anim.SetTrigger("Golpeado");

    }


}
