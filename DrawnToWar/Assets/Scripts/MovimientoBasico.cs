using UnityEngine;
using System.Collections;

public class MovimientoBasico : MonoBehaviour 
{
    public float VelocidadMaximaCaminar = 1;
    public float VelocidadMaximaCorrer = 3;
    public float GradosRotacion  = 3;




    public bool corriendo=false;
    public Animator _anim;
//    float Inicial;



    NavMeshAgent _agente;
    
    void Start () {

        _agente = GetComponent<NavMeshAgent>();
        _anim = GetComponent<Animator>();

        //Inicial = Vel;
        //anim = GetComponent<Animator>();
        
	}
	
	void Update () 
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        float velMaxima = VelocidadMaximaCaminar;
        if(Input.GetButton("Correr")){
            velMaxima = VelocidadMaximaCorrer;
        }

        _agente.velocity = transform.forward * (v * velMaxima);

        _anim.SetFloat("Vel",v * velMaxima);

        transform.Rotate(0, h * GradosRotacion, 0);
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

}
