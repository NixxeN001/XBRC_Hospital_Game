using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	bool GameOver = false;
	public GameObject Patient;

	public float maxTime = 15f;
	public float minTime = 7f;

	float Spawn = 2f;

	private void Update()
	{
		

		Spawn -= Time.deltaTime;

		if (Spawn <=0f)
		{
			Instantiate(Patient, GameObject.Find("spawn").transform.position, Quaternion.identity);
			Spawn = Random.Range(minTime, maxTime);
		}
		

	}
}


