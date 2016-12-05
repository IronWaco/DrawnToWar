using UnityEngine;
using System.Collections;

public class ControladorSoldado : MonoBehaviour 
{
	Transform cam;
	Rigidbody rb;

    public int Salud = 100;
    public Animator Anim;

	#region CONFIG PARAMETERS

	public float VelocidadCaminando = 3f;
    public float VelocidadCorriendo = 6f;

	#endregion




	#region UNITY HANDLERS

	void Start () 
	{
		cam = Camera.main.transform;
		rb = GetComponent<Rigidbody> ();
	}



	void FixedUpdate()
	{
		Vector3 forward = (new Vector3 (cam.forward.x, 0, cam.forward.z)).normalized;
		Vector3 right = (new Vector3 (cam.right.x, 0, cam.right.z)).normalized;

		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");

		float magnitude = Mathf.Abs(h) + Mathf.Abs(v);
		magnitude = Mathf.Min(1.0f, magnitude);

		Vector3 dirMagnitude = magnitude * ((forward * v) + (right * h)).normalized;

        float velocidad = 0;
        if(Input.GetKey(KeyCode.LeftShift)) {
            velocidad = VelocidadCorriendo;
        } else {
            velocidad = VelocidadCaminando;
        }

        transform.Translate(dirMagnitude * velocidad * Time.deltaTime, Space.World);    

        if(Anim != null) {
            Anim.SetBool("corriendo", magnitude > 0);
        }
	}

	#endregion



    public void RecibirZarpaso(int danho)
    {
        Salud = Salud - danho;

        GameObject obj = GameObject.FindGameObjectWithTag("Sangre");
        //SangrePantalla sangre = obj.GetComponent<SangrePantalla>();
        //sangre.RecibirZarpaso();
    }

}
