using UnityEngine;
using System.Collections;

public class Disparador : MonoBehaviour 
{
    public bool Disparando;

    public float Frecuencia = 0.2f;
    public GameObject BalaPrototipo;

	void Start () 
    {
        Disparando = false;

        StartCoroutine(Disparar());
	}
	
	void Update () 
    {
        Disparando = Input.GetMouseButton(0);
	}

    IEnumerator Disparar()
    {
        while(true)
        {
            yield return new WaitUntil( () => Disparando);
            yield return new WaitForSeconds(Frecuencia);
            Instantiate(BalaPrototipo, transform.position, transform.rotation);
        }
    }


    public void DispararDesdeAnimacion()
    {
        Instantiate(BalaPrototipo, transform.position, transform.rotation);
    }
}
