using UnityEngine;
using System.Collections;

public class MovimientoBasico : MonoBehaviour {

    public float Vel = 10;


    public Animator anim;
    float Inicial;
    
    void Start () {
        Inicial = Vel;
        //anim = GetComponent<Animator>();
        
	}
	
	void Update () {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            Vel = 2*Inicial;
        }
        else
        {
            Vel = Inicial;
        }
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            transform.position = transform.forward * Vel * Time.deltaTime + transform.position;
            anim.SetBool("Moving",true);
            
        }
        else
        { 
            anim.SetBool("Moving", false);
           // anim.SetFloat("Vel", 0);
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            transform.position = -transform.forward * Vel * Time.deltaTime + transform.position;
        }
        if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, Vel, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, -Vel, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = -transform.right * Vel * Time.deltaTime + transform.position;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position = transform.right * Vel * Time.deltaTime + transform.position;
        }
        anim.SetFloat("Vel", Vel);

    }
}
