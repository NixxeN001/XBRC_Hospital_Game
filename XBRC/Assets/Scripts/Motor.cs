using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class Motor : MonoBehaviour
{
	Vector3 _destination;
	GameObject Reception;

	

	private void Start()
	{
		_destination = GameObject.Find("reception").transform.position;
		Move(_destination);
	}

	public void Move(Vector3 point)
	{
		NavMeshAgent agent = GetComponent<NavMeshAgent>();
		agent.destination = point;
	}
}
