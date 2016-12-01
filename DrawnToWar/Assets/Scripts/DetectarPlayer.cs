using UnityEngine;
using System.Collections;

public class DetectarPlayer : MonoBehaviour 
{
    NavMeshAgent _agent;
    Animator _anim;

	void Start () {
        _agent = GetComponentInParent<NavMeshAgent>();
        _anim = GetComponentInParent<Animator>();
	}
	
	void Update () {
        _anim.SetFloat("Vel", _agent.speed);
	}


    void OnTriggerStay(Collider C)
    {
        if (C.tag == "Player")
        {
            if(_agent.enabled) {
                _agent.speed = 2;
                _agent.SetDestination(C.transform.position);
            }
        }
    }


    void OnTriggerExit(Collider C)
    {
        if (C.tag == "Player")
        {
            if(_agent.enabled) {
                _agent.SetDestination(transform.position);
                _agent.speed = 0;
            }
        }
    }
}
