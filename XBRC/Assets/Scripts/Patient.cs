using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Patient : MonoBehaviour
{
	GameObject GM;
	public Image playerhealth;
	

	public bool treated = false;

	public float treatmentTime;
	public float deathTime;

	public float treatmentCost;

	public float maxTime = 40f;
	public float minTime = 20f;

	

	private void Start()
	{
		GM = GameObject.Find("Game Manager");
		treatmentTime = Random.Range(minTime, maxTime);
		treatmentCost = treatmentTime * 1000;
		deathTime = treatmentTime * 3;

		treatmentTime = treatmentTime - (treatmentTime * (GM.GetComponent<Manager>().Effiecency/100));

		
	}

	public bool Treated = false;

	private void Update()
	{
		float dist = Vector3.Distance(GameObject.Find("exit").transform.position, transform.position);

		if (dist <= 3)
		{
			Destroy(gameObject);
		}

		

		deathTime -= Time.deltaTime;

		if ((deathTime<= 0f)&&(!Treated))
		{
			GM.GetComponent<Manager>().StopGame = true;
		}

	}

	public void Pay()
	{
		GM.GetComponent<Manager>().IncMoney(treatmentCost);
		
	}

	public void IncreaseHealth()
    {

    }
	
}
