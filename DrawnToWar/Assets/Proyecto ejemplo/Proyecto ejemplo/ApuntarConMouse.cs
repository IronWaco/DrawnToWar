using UnityEngine;
using System.Collections;

public class ApuntarConMouse : MonoBehaviour 
{
	void Start () 
    {
	    
	}
	
	void Update () 
    {
        Camera cam = Camera.main;

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        RaycastHit [] hits = Physics.RaycastAll(ray);

        for(int i=0;i<hits.Length;i++){
            RaycastHit hit  = hits[i];
            if(hit.collider.gameObject.name == "Piso"){
                Vector3 dif = hit.point - transform.position;
                dif = new Vector3(dif.x, 0, dif.z);

                transform.rotation = Quaternion.LookRotation(dif);
            }
        }
	}
}
