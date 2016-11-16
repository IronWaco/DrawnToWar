using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Telequinesis : MonoBehaviour 
{
    public float AlzarObjetoSuavidad = 0.05f;
    public GameObject UIIconoAlzable;
    public Transform Lanzador;

    GameObject _posibleObjetoAlzable;
    Rigidbody _objetoAlzadoRigidBody;
    bool _puedeLanzar;
    List<GameObject> _posiblesObjetosAlzables;

    void Start () 
    {
        _puedeLanzar = false;
        _posiblesObjetosAlzables = new List<GameObject>();
	}
	
	void Update () 
    {
        if(Input.GetButtonDown("AlzarObjeto") && _posibleObjetoAlzable != null) // el momento de alzar
        {
            _puedeLanzar = true; 
            _objetoAlzadoRigidBody = _posibleObjetoAlzable.GetComponent<Rigidbody>();
            _objetoAlzadoRigidBody.isKinematic = true;

            _posiblesObjetosAlzables.Remove(_posibleObjetoAlzable);

            _posibleObjetoAlzable.transform.position = Lanzador.position;
            _posibleObjetoAlzable.transform.parent = transform;
            _posibleObjetoAlzable = null;
        }

        if(Input.GetButtonDown("LanzarObjeto") && _puedeLanzar)
        {
            _objetoAlzadoRigidBody.transform.parent.DetachChildren();
            _objetoAlzadoRigidBody.isKinematic = false;
            _objetoAlzadoRigidBody.AddForce(Lanzador.forward * 1000);
            _puedeLanzar = false;

            if(_posiblesObjetosAlzables.Count > 0) 
            {
                _posibleObjetoAlzable = _posiblesObjetosAlzables[0];
            }
        }
            

        // TODO: codificar alzando objeto: coll.transform.position = Vector3.Lerp(coll.transform.position, transform.position, AlzarObjetoSuavidad);
            
    }


    void OnTriggerEnter(Collider coll)
    {
        if(coll.tag=="Alzable")
        {
            if(UIIconoAlzable != null) {
                UIIconoAlzable.SetActive(true);
            }

            if(_posiblesObjetosAlzables.IndexOf(coll.gameObject) == -1) {
                _posiblesObjetosAlzables.Add(coll.gameObject);
                if(_posiblesObjetosAlzables.Count == 1){
                    _posibleObjetoAlzable = coll.gameObject;    
                }
            }


        }
    }


    void OnTriggerExit(Collider coll)
    {
        if(coll.tag=="Alzable")
        {
            if(UIIconoAlzable != null) {
                UIIconoAlzable.SetActive(false);
            }

            if(_posiblesObjetosAlzables.IndexOf(coll.gameObject) != -1) {
                _posiblesObjetosAlzables.Remove(coll.gameObject);

                if(_posiblesObjetosAlzables.Count == 0){
                    _posibleObjetoAlzable = null;
                } else if(coll.gameObject == _posibleObjetoAlzable) {
                    _posibleObjetoAlzable = _posiblesObjetosAlzables[0];
                }
            }
        }
    }


}
