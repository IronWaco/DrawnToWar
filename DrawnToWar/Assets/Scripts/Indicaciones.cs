using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Indicaciones : MonoBehaviour {
    
    string M1, M2, M3, M4, M5, M6;
    public Text Texto;
    public float Frecuencia=5f;

	void Start () {
        M1 = "Bienvenido a Drawn To War para moverse utilize WASD o las flechas dirreccionales";
        M2 = "Para correr presione shift mientras se mueve";
        M3 = "Para levantar objetos con telequinesis utilize la letra E";
        M4 = "Para lanzarlos use Q";
        M5 = "Puede saltar corriendo directamente hacia las vallas";
        M6 = "Para atacar utilize el click izquierdo del mouse";
        StartCoroutine("ActualizarTexto");

	
	}
	
	void Update () {
	    
	}
    IEnumerator ActualizarTexto()
    {
        bool Sentinela=true;
        while(Sentinela)
        { 
            Texto.text=M1;
            yield return new WaitForSeconds(Frecuencia);
            Texto.text = M2;
            yield return new WaitForSeconds(Frecuencia);
            Texto.text = M3;
            yield return new WaitForSeconds(Frecuencia);
            Texto.text = M4;
            yield return new WaitForSeconds(Frecuencia);
            Texto.text = M5;
            yield return new WaitForSeconds(Frecuencia);
            Texto.text = M6;
            yield return new WaitForSeconds(Frecuencia);
            Texto.enabled = false;
            Sentinela = false;
            
        }
    }
}
